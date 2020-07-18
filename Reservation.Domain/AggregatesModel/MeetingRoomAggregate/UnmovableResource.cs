using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Domain.AbstractModel;

namespace Reservation.Domain.AggregatesModel.MeetingRoomAggregate
{
    public class UnmovableResource : Resource
    {
        private int _meetingRoomId;
        public int MeetingRoomId => _meetingRoomId;
        
        protected UnmovableResource() { }
        
        public UnmovableResource(int meetingRoomId, ResourceType resourceType)
            : base(resourceType)
        {
            _meetingRoomId = meetingRoomId;
        } 
    }
}
