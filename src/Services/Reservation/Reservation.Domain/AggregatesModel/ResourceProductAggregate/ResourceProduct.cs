using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain.AggregatesModel.ResourceProductAggregate
{
    class ResourceProduct
    {
        private string _name;
        public string Name => _name;

        private bool _isMovable;
        public bool IsMovable => _isMovable;
    }
}
