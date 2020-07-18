using Microsoft.EntityFrameworkCore;
using Reservation.Domain.AggregatesModel.OfficeAggregate;
using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
using Reservation.Infrastructure.EntityConfigurations;

namespace Reservation.Infrastructure
{
    using Reservation.Domain.AggregatesModel.ReservationAggregate;
    public class ReservationContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "reservation";
        public DbSet<Office> Offices { get; set; }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }
        public DbSet<UnmovableResource> UnmovableResources { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MovableResource> MovableResources { get; set; }

        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OfficeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MeetingRoomEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnmovableResourceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovableResourceEntityTypeConfiguration());
        }
    }
}
