using Autofac;
using Reservation.Domain.AggregatesModel.ReservationAggregate;
using Reservation.Infrastructure.Repositories;

namespace Reservation.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReservationRepository>()
                .As<IReservationRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
