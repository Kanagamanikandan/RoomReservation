using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
using Reservation.Domain.AggregatesModel.OfficeAggregate;
using Reservation.Domain.AggregatesModel.ReservationAggregate;
using Reservation.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Domain.Services
{
    public class ReservationService
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMeetingRoomRepository _meetingRoomRepository;

        public ReservationService(IMeetingRoomRepository meetingRoomRepository,
            IOfficeRepository officeRepository,
            IReservationRepository reservationRepository)
        {
            _meetingRoomRepository = meetingRoomRepository ?? throw new ArgumentNullException(nameof(meetingRoomRepository));
            _officeRepository = officeRepository ?? throw new ArgumentNullException(nameof(_officeRepository));
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }

        public async Task<bool> IsWithinOfficeOpenHours(int meetingRoomId, TimeSpan startTime, TimeSpan endTime)
        {
            var meetingRoom = await _meetingRoomRepository.GetAsync(meetingRoomId);
            var office = await _officeRepository.GetAsync(meetingRoom.OfficeId);

            return startTime >= office.OpenTime && endTime <= office.CloseTime;
        }

        public bool IsMeetingRoomAvailable(int meetingRoomId, DateTime reservationDate, TimeSpan startTime, TimeSpan endTime)
        {
            return _reservationRepository.GetAllAsync().AsEnumerable()
                .Where(r => r.MeetingRoomId == meetingRoomId && r.ReservationDate == reservationDate
                    && ((startTime >= r.StartTime && startTime < r.EndTime) || (endTime >= r.StartTime && endTime < r.EndTime)))
                .Count() == 0;
        }

        public async Task<bool> IsMeetingRoomHasResource(int meetingRoomId, ResourceType resourceType)
        {
            var meetingRoom = await _meetingRoomRepository.GetAsync(meetingRoomId);
            return meetingRoom.UnmovableResources.Where(r => r.ResourceType == resourceType).Count() > 0;
        }
    }
}
