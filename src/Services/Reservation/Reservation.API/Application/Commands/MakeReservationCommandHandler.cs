using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reservation.API.Application.Commands
{
    using Reservation.Domain.AggregatesModel.ReservationAggregate;
    public class MakeReservationCommandHandler : IRequestHandler<MakeReservationCommand, Reservation>
    {
        private readonly IMediator _mediator;
        private readonly IReservationRepository _reservationRepository;
        private readonly ILogger<MakeReservationCommandHandler> _logger;

        public MakeReservationCommandHandler(IMediator mediator,
            IReservationRepository reservationRepository,
            ILogger<MakeReservationCommandHandler> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Reservation> Handle(MakeReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = new Reservation(
                request.MeetingRoomId,
                request.EmployeeId,
                request.ReservationDate,
                request.StartTime,
                request.EndTime);

            foreach (var resource in request.MovableResources)
            {
                reservation.AddResource(new MovableResource(resource));
            }

            _logger.LogInformation("----- Making Reservation - Reservation: {@Reservation}", reservation);
            
            _reservationRepository.Add(reservation);

            await _reservationRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);

            return reservation;

        }
    }
}
