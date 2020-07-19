using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Domain.SharedKernel;
using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
using Reservation.Domain.SeedWork;

namespace Reservation.Domain.AggregatesModel.ReservationAggregate
{
    public class Reservation : Entity, IAggregateRoot
    {
        private int _meetingRoomId;
        public int MeetingRoomId => _meetingRoomId;

        private int _employeeId;
        public int EmployeeId => _employeeId;

        private readonly List<MovableResource> _movableResources = new List<MovableResource>();
        public IReadOnlyCollection<MovableResource> MovableResources => _movableResources;

        protected Reservation() { }

        public Reservation(int meetingRoomId, int employeeId, List<MovableResource> resources)
        {
            _meetingRoomId = meetingRoomId;
            _employeeId = employeeId;
        }
    }
}
