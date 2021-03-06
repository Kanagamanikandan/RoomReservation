﻿namespace Reservation.API.Application.Commands
{
    using MediatR;
    using Reservation.Domain.AggregatesModel.ReservationAggregate;
    using Reservation.Domain.SharedKernel;
    using System;
    using System.Collections.Generic;

    public class MakeReservationCommand : IRequest<Reservation>
    {
        public int MeetingRoomId { get; private set; }
        public int EmployeeId { get; private set; }
        public DateTime ReservationDate { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }

        private readonly List<string> _movableResources;
        public IList<string> MovableResources => _movableResources;

        protected MakeReservationCommand() { }
        public MakeReservationCommand(int meetingRoomId,
            int employeeId,
            DateTime reservationDate,
            TimeSpan startTime,
            TimeSpan endTime,
            List<string> movableResources)
        {
            MeetingRoomId = meetingRoomId;
            EmployeeId = employeeId;
            ReservationDate = reservationDate;
            StartTime = startTime;
            EndTime = endTime;
            _movableResources = movableResources;
        }
    }


}
