﻿using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Domain.AbstractModel;
using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
using Reservation.Domain.SeedWork;

namespace Reservation.Domain.AggregatesModel.ReservationAggregate
{
    public class Reservation:Entity
    {
        private int _meetingRoomId;
        public int MeetingRoomId => _meetingRoomId;
        
        private readonly List<Resource> _movableResources = new List<Resource>();
        public IReadOnlyCollection<Resource> Resources => _movableResources;
        
        protected Reservation() { }
        
        public Reservation(MeetingRoom meetingRoom, List<Resource> resources)
        {
            _meetingRoomId = meetingRoom.Id;
        }
    }
}
