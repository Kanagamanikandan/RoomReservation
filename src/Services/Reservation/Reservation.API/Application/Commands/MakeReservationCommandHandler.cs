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
    using Reservation.Domain.Services;
    using Reservation.Domain.SharedKernel;

    public class MakeReservationCommandHandler : IRequestHandler<MakeReservationCommand, Reservation>
    {
        private readonly IMediator _mediator;
        private readonly IReservationRepository _reservationRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IMeetingRoomRepository _meetingRoomRepository;
        private readonly ReservationService _reservationService;
        private readonly ILogger<MakeReservationCommandHandler> _logger;

        public MakeReservationCommandHandler(IMediator mediator,
            IReservationRepository reservationRepository,
            IOfficeRepository officeRepository,
            IMeetingRoomRepository meetingRoomRepository,
            ReservationService reservationService,
            ILogger<MakeReservationCommandHandler> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
            _officeRepository = officeRepository ?? throw new ArgumentNullException(nameof(officeRepository));
            _meetingRoomRepository = meetingRoomRepository ?? throw new ArgumentNullException(nameof(meetingRoomRepository));
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Reservation> Handle(MakeReservationCommand request, CancellationToken cancellationToken)
        {
            List<MovableResource> movableResources = new List<MovableResource>();
            foreach (var resource in request.MovableResources)
            {

                ResourceType resourceType = (ResourceType)Enum.Parse(typeof(ResourceType), resource);
                movableResources.Add(new MovableResource(resourceType));
            }

            var reservation = await Reservation.CreateReservation(
                request.MeetingRoomId,
                request.EmployeeId,
                request.ReservationDate,
                request.StartTime,
                request.EndTime,
                movableResources,
                _reservationService);


            _logger.LogInformation("----- Making Reservation - Reservation: {@Reservation}", reservation);
            
            _reservationRepository.Add(reservation);

            await _reservationRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);

            return reservation;

        }
    }
}
