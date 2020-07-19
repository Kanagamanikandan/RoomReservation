using Microsoft.EntityFrameworkCore;
using Reservation.Domain.AggregatesModel.OfficeAggregate;
using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
using Reservation.Infrastructure.EntityConfigurations;

namespace Reservation.Infrastructure
{
    using MediatR;
    using Reservation.Domain.AggregatesModel.ReservationAggregate;
    using Reservation.Domain.SeedWork;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ReservationContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "reservation";
        public DbSet<Office> Offices { get; set; }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }
        public DbSet<UnmovableResource> UnmovableResources { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MovableResource> MovableResources { get; set; }

        private readonly IMediator _mediator;
        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options) { }

        public ReservationContext(DbContextOptions<ReservationContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


            System.Diagnostics.Debug.WriteLine("ReservationContext::ctor ->" + this.GetHashCode());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OfficeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MeetingRoomEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnmovableResourceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovableResourceEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
