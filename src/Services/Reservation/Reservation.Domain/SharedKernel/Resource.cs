using Reservation.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain.SharedKernel
{
    public abstract class Resource : Entity
    {
        public ResourceType ResourceType { get; private set; }

        protected Resource() { }
        public Resource(ResourceType resourceType)
        {
            ResourceType = resourceType;
        }

    }

    public enum ResourceType
    {
        WhiteBoard = 1,
        TelevisionOnMountWithWheels,
        Beamer,
    }
}
