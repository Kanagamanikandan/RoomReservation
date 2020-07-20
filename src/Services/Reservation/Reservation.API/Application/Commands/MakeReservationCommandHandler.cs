using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reservation.API.Application.Commands
{
    using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
    using Reservation.Domain.AggregatesModel.OfficeAggregate;
    using Reservation.Domain.AggregatesModel.ReservationAggregate;
    using Reservation.Domain.Exceptions;

    public class MakeReservationCommandHandler : IRequestHandler<MakeReservationCommand, Reservation>
    {
        private readonly IMediator _mediator;
        private readonly IReservationRepository _reservationRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IMeetingRoomRepository _meetingRoomRepository;
        private readonly ILogger<MakeReservationCommandHandler> _logger;

        public MakeReservationCommandHandler(IMediator mediator,
            IReservationRepository reservationRepository,
            IOfficeRepository officeRepository,
            IMeetingRoomRepository meetingRoomRepository,
            ILogger<MakeReservationCommandHandler> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
            _officeRepository = officeRepository;
            _meetingRoomRepository = meetingRoomRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Reservation> Handle(MakeReservationCommand request, CancellationToken cancellationToken)
        {
            var meetingRoom = await _meetingRoomRepository.GetAsync(request.MeetingRoomId);
            var office = await _officeRepository.GetAsync(meetingRoom.OfficeId);

            if (request.StartTime < office.OpenTime || request.EndTime > office.CloseTime)
                throw new ReservationDomainException("Cannot reserve outside office hours");

            var reservation = new Reservation(
                request.MeetingRoomId,
                request.EmployeeId,
                request.ReservationDate,
                request.StartTime,
                request.EndTime);

            foreach (var resource in request.MovableResources)
            {
                var movableResource = new MovableResource(resource);
                reservation.AddResource(movableResource);
            }

            _logger.LogInformation("----- Making Reservation - Reservation: {@Reservation}", reservation);
            
            _reservationRepository.Add(reservation);

            await _reservationRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);

            return reservation;

        }
    }
}
