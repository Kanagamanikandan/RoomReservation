using Reservation.Domain.SeedWork;
using System.Threading.Tasks;

namespace Reservation.Domain.AggregatesModel.MeetingRoomAggregate
{
    public interface IMeetingRoomRepository : IRepository<MeetingRoom>
    {
        MeetingRoom Add(MeetingRoom meetingRoom);

        void Update(MeetingRoom meetingRoom);

        Task<MeetingRoom> GetAsync(int meetingRoomId);
    }
}
