using Reservation.Domain.AbstractModel;

namespace Reservation.Domain.AggregatesModel.ReservationAggregate
{
    public class MovableResource : Resource
    {
        private int _reservationId;
        public int ReservationId => _reservationId;
        
        protected MovableResource() { }
        
        public MovableResource(int reservationId, ResourceType resourceType)
            :base(resourceType)
        {
            _reservationId = reservationId;
        }
    }
}
