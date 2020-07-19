using Microsoft.EntityFrameworkCore;
using Reservation.Domain.AggregatesModel.OfficeAggregate;
using Reservation.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Infrastructure.Repositories
{
    class OfficeRepository : IOfficeRepository
    {
        private readonly ReservationContext _context;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();
        public OfficeRepository(ReservationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Office Add(Office office)
        {
            return _context.Offices.Add(office).Entity;
        }

        public async Task<Office> GetAsync(int officeId)
        {
            var office = await _context.Offices
                .FirstOrDefaultAsync(o => o.Id == officeId);

            if (office == null)
            {
                office = _context.Offices.Local
                    .FirstOrDefault(o => o.Id == officeId);
            }

            return office;
        }

        public void Update(Office office)
        {
            _context.Entry(office).State = EntityState.Modified;
        }
    }
}
