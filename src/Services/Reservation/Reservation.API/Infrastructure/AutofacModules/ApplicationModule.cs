using Autofac;
using MediatR;
using Reservation.API.Application.Queries;
using Reservation.Domain.AggregatesModel.ReservationAggregate;
using Reservation.Infrastructure.Repositories;
using System.Reflection;

namespace Reservation.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string connectionString)
        {
            QueriesConnectionString = connectionString;

        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterType<ReservationRepository>()
                .As<IReservationRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new ReservationQueries(QueriesConnectionString))
                .As<IReservationQueries>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });
        }
    }
}
