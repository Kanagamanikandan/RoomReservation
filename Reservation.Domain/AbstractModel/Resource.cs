using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain.AbstractModel
{
    public abstract class Resource
    {
        public ResourceType ResourceType { get; private set; }

        protected Resource() { }
        public Resource(ResourceType resourceType)
        {
            ResourceType = ResourceType;
        }

    }

    public enum ResourceType
    {
        WhiteBoard,
        TelevisionOnMountWithWheels,
        Beamer,
        Chairs
    }
}
