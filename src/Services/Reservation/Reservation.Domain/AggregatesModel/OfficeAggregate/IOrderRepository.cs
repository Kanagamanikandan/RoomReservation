using Reservation.Domain.SeedWork;
using System.Threading.Tasks;

namespace Reservation.Domain.AggregatesModel.OfficeAggregate
{
    public interface IfficeRepository:IRepository<Office>
    {
        Office Add(Office office);
        void Update(Office office);
        Task<Office> GetAsync(int officeId);
    }
}
