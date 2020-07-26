using Microsoft.EntityFrameworkCore;
using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
using Reservation.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Infrastructure.Repositories
{
    public class MeetingRoomRepository : IMeetingRoomRepository
    {
        private readonly ReservationContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public MeetingRoomRepository(ReservationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public MeetingRoom Add(MeetingRoom meetingRoom)
        {
            return _context.MeetingRooms.Add(meetingRoom).Entity;
        }

        public async Task<MeetingRoom> GetAsync(int meetingRoomId)
        {
            var meetingRoom = await _context.MeetingRooms
                .FirstOrDefaultAsync(m => m.Id == meetingRoomId);

            if (meetingRoom == null)
            {
                meetingRoom = _context.MeetingRooms.Local
                    .FirstOrDefault(m => m.Id == meetingRoomId);
            }

            if (meetingRoom != null)
            {
                await _context.Entry(meetingRoom)
                    .Collection(i => i.UnmovableResources).LoadAsync();
            }

            return meetingRoom;
        }

        public void Update(MeetingRoom meetingRoom)
        {
            _context.Entry(meetingRoom).State = EntityState.Modified;
        }
    }
}
