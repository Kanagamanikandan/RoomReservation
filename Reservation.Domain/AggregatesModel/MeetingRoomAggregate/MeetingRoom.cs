using System.Collections.Generic;
using Reservation.Domain.SeedWork;
using Reservation.Domain.AbstractModel;
using Reservation.Domain.AggregatesModel.ReservationAggregate;

namespace Reservation.Domain.AggregatesModel.MeetingRoomAggregate
{
    public class MeetingRoom : Entity, IAggregateRoot
    {
        private string _roomNumber = "";
        public string RoomNumber => _roomNumber;

        private int _officeId;
        public int OfficeId => _officeId;
        
        private int _capacity;
        public int Capacity => _capacity;

        private int _numberOfChairs;
        public int NumberOfChairs => _numberOfChairs;

        private readonly List<UnmovableResource> _unmovableResources = new List<UnmovableResource>();
        public IReadOnlyCollection<UnmovableResource> UnmovableResources => _unmovableResources;
        protected MeetingRoom()
        { }

        public MeetingRoom(string number, int capacity, int officeId, int numChairs)
        {
            _roomNumber = number;
            _capacity = capacity;
            _officeId = officeId;
            _numberOfChairs = numChairs;
        }
    }
}
