using Reservation.Domain.SeedWork;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Domain.AggregatesModel.ReservationAggregate
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Reservation Add(Reservation reservation);
        void Update(Reservation reservation);
        Task<Reservation> GetAsync(int reservationId);
        IQueryable<Reservation> GetAllAsync();
    }
}
