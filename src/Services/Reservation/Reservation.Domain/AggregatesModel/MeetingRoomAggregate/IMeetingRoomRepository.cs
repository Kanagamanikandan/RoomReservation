using Reservation.Domain.SeedWork;

namespace Reservation.Domain.AggregatesModel.MeetingRoomAggregate
{
    public interface IMeetingRoomRepository : IRepository<MeetingRoom>
    {
        MeetingRoom Add(MeetingRoom meetingRoom);

        void Update(MeetingRoom meetingRoom);

        MeetingRoom GetAsync(int meetingRoomId);
    }
}
