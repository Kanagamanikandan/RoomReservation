using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Domain.SharedKernel;

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
