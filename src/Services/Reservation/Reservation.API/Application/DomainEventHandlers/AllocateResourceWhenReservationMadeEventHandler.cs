using MediatR;
using Microsoft.Extensions.Logging;
using Reservation.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reservation.API.Application.DomainEventHandlers
{
    public class AllocateResourceWhenReservationMadeEventHandler
        : INotificationHandler<ReservationMadeDomainEvent>
    {
        private readonly ILogger<AllocateResourceWhenReservationMadeEventHandler> _logger;

        public AllocateResourceWhenReservationMadeEventHandler(
            ILogger<AllocateResourceWhenReservationMadeEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(ReservationMadeDomainEvent reservationMadeDomainEvent, CancellationToken cancellationToken)
        {
            _logger.LogTrace("Resource allocation is requested for Reservation with Id: {ReservationId}",
                reservationMadeDomainEvent.Id);
            return Task.CompletedTask;
        }
    }
}
