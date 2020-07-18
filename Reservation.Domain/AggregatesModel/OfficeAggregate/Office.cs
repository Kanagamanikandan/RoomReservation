using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Domain.SeedWork;
namespace Reservation.Domain.AggregatesModel.OfficeAggregate
{
    public class Office : Entity, IAggregateRoot
    {
        private string _city = "";
        public string City => _city;

        private TimeSpan _openTime;
        public TimeSpan OpenTime => _openTime;

        private TimeSpan _closeTime;
        public TimeSpan CloseTime => _closeTime;

        protected Office() { }
        public Office(string city, TimeSpan openTime, TimeSpan closeTime)
        {
            _city = city;
            _openTime = openTime;
            _closeTime = closeTime;
        }
    }
}
