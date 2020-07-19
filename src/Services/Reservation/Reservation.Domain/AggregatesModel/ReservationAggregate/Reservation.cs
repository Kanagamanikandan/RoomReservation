using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Domain.SharedKernel;
using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
using Reservation.Domain.SeedWork;
using System.Linq;
using Reservation.Domain.Exceptions;

namespace Reservation.Domain.AggregatesModel.ReservationAggregate
{
    public class Reservation : Entity, IAggregateRoot
    {
        private int _meetingRoomId;
        public int MeetingRoomId => _meetingRoomId;

        private int _employeeId;
        public int EmployeeId => _employeeId;

        private DateTime _reservationDate;
        public DateTime ReservationDate => _reservationDate;

        private TimeSpan _startTime;
        public TimeSpan StartTime => _startTime;

        private TimeSpan _endTime;
        public TimeSpan EndTime => _endTime;

        private readonly List<MovableResource> _movableResources = new List<MovableResource>();
        public IReadOnlyCollection<MovableResource> MovableResources => _movableResources;

        protected Reservation() { }

        public Reservation(int meetingRoomId,
            int employeeId,
            DateTime reservationDate,
            TimeSpan startTime,
            TimeSpan endTime)
        {
            _meetingRoomId = meetingRoomId;
            _employeeId = employeeId;
            _reservationDate = reservationDate.Date;
            _startTime = startTime;
            _endTime = endTime;
        }

        public void AddResource(MovableResource movableResource)
        {
            if (_movableResources.Where(r => r.ResourceType == movableResource.ResourceType).Count() > 0)
                throw new ReservationDomainException("Cannot add duplicate resources");

            _movableResources.Add(movableResource);
        }
    }
}
