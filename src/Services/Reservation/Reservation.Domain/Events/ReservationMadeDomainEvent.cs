using MediatR;
using Reservation.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Reservation.Domain.Events
{
    public class ReservationMadeDomainEvent : INotification
    {
        public int Id { get; }
        public List<string> Resources { get; }

        public ReservationMadeDomainEvent(int id, List<string> resources)
        {
            Id = id;
            Resources = resources;
        }    
    }
}
