using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Domain.SharedKernel;
using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
using Reservation.Domain.SeedWork;
using System.Linq;
using Reservation.Domain.Exceptions;
using Reservation.Domain.Services;
using System.Threading.Tasks;
using Reservation.Domain.Events;

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

        public ReservationStatus _reservationStatus;
        public ReservationStatus ReservationStatus => _reservationStatus;

        private readonly List<MovableResource> _movableResources = new List<MovableResource>();
        public IReadOnlyCollection<MovableResource> MovableResources => _movableResources;

        protected Reservation() { }

        private Reservation(int meetingRoomId,
            int employeeId,
            DateTime reservationDate,
            TimeSpan startTime,
            TimeSpan endTime,
            List<MovableResource> movableResources)
        {
            _meetingRoomId = meetingRoomId;
            _employeeId = employeeId;
            _reservationDate = reservationDate.Date;
            _startTime = startTime;
            _endTime = endTime;
            _movableResources = movableResources;
            _reservationStatus = ReservationStatus.AwaitingResourceAllocation;

            AddDomainEvent(
                new ReservationMadeDomainEvent(this.Id,
                movableResources.Select(r => r.ResourceType.ToString()).ToList())
                );
        }

        public async static Task<Reservation> CreateReservation(int meetingRoomId,
            int employeeId,
            DateTime reservationDate,
            TimeSpan startTime,
            TimeSpan endTime,
            List<MovableResource> movableResources,
            ReservationService reservationService)
        {
            if (!await reservationService.IsWithinOfficeOpenHours(meetingRoomId, startTime, endTime))
            {
                throw new ReservationDomainException("Cannot reserve outside office hours");
            }

            if (!reservationService.IsMeetingRoomAvailable(meetingRoomId, reservationDate, startTime, endTime))
            {
                throw new ReservationDomainException("Meeting room is not available at this time");
            }

            foreach(var resource in movableResources)
            {
                if (await reservationService.IsMeetingRoomHasResource(meetingRoomId, resource.ResourceType))
                    throw new ReservationDomainException($"{resource.ResourceType.ToString()} is already available in the meeting room");
            }
            return new Reservation(meetingRoomId, employeeId, reservationDate, startTime, endTime, movableResources);
        }
    }
}
