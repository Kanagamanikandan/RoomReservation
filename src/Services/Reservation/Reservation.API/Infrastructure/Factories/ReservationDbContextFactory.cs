using Reservation.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Reservation.API.Infrastructure.Factories
{
    public class ReservationDbContextFactory : IDesignTimeDbContextFactory<ReservationContext>
    {
        public ReservationContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ReservationContext>();

            optionsBuilder.UseSqlServer(config["ConnectionString"], sqlServerOptionsAction: o => o.MigrationsAssembly("Reservation.API"));

            return new ReservationContext(optionsBuilder.Options);
        }
    }
}
