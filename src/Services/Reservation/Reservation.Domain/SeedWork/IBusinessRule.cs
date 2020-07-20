using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain.SeedWork
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
