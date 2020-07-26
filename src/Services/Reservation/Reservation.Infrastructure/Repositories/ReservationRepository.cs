namespace Reservation.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Reservation.Domain.AggregatesModel.ReservationAggregate;
    using Reservation.Domain.SeedWork;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ReservationRepository(ReservationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Reservation Add(Reservation reservation)
        {
            return _context.Reservations.Add(reservation).Entity;
        }

        public async Task<Reservation> GetAsync(int reservationId)
        {
            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(r => r.Id == reservationId);
            
            if (reservation == null)
            {
                reservation = _context.Reservations.Local
                    .FirstOrDefault(r => r.Id == reservationId);
            }

            if (reservation != null)
            {
                await _context.Entry(reservation)
                    .Collection(i => i.MovableResources).LoadAsync();
            }

            return reservation;
        }

        public IQueryable<Reservation> GetAllAsync()
        {
            return _context.Reservations.AsQueryable();
        }
        public void Update(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
        }
    }
}
