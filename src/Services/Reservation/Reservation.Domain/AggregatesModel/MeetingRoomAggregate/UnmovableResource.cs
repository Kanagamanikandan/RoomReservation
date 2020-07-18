using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Domain.AbstractModel;

namespace Reservation.Domain.AggregatesModel.MeetingRoomAggregate
{
    public class UnmovableResource : Resource
    {
        protected UnmovableResource() { }
        
        public UnmovableResource(ResourceType resourceType)
            : base(resourceType)
        {
            
        } 
    }
}
