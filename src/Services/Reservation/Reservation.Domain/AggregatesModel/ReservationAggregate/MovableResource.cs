using Reservation.Domain.SharedKernel;

namespace Reservation.Domain.AggregatesModel.ReservationAggregate
{
    public class MovableResource : Resource
    {    
        protected MovableResource() { }
        
        public MovableResource(ResourceType resourceType)
            :base(resourceType)
        {
        }
    }
}
