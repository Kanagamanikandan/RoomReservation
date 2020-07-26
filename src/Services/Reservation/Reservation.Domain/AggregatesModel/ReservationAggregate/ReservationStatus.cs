using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain.AggregatesModel.ReservationAggregate
{
    public enum ReservationStatus
    {
        AwaitingResourceAllocation = 1,
        ResourceAllocationSuccess,
        ResourceAllocationFailed
    }
}
