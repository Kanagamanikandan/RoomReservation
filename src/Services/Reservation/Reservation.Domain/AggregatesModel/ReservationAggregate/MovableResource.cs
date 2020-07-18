﻿using Reservation.Domain.AbstractModel;

namespace Reservation.Domain.AggregatesModel.ReservationAggregate
{
    public class MovableResource : Resource
    {    
        protected MovableResource() { }
        
        public MovableResource(int reservationId, ResourceType resourceType)
            :base(resourceType)
        {
        }
    }
}