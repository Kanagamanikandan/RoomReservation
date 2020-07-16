using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Reservation.Domain.SeedWork
{
    public abstract class Entity
    {
        int _Id;
        public virtual int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private List<INotification> _domainEvents = new List<INotification>();
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(INotification @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
