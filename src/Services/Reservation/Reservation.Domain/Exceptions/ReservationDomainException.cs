using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain.Exceptions
{
    public class ReservationDomainException : Exception
    {
        public ReservationDomainException()
        { }

        public ReservationDomainException(string message)
            :base(message)
        { }

        public ReservationDomainException(string message, Exception innerException)
            :base(message, innerException)
        { }
    }
}
