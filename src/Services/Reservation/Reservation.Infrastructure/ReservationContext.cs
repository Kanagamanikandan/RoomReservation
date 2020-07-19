using Microsoft.EntityFrameworkCore;
using Reservation.Domain.AggregatesModel.OfficeAggregate;
using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
using Reservation.Infrastructure.EntityConfigurations;

namespace Reservation.Infrastructure
{
    using MediatR;
    using Reservation.Domain.AggregatesModel.ReservationAggregate;
    using Reservation.Domain.SeedWork;
    using Reservation.Domain.SharedKernel;
    using System;
    using System.Collections.Generic;
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

            // TODO: should be extracted outside of dbcontext
            modelBuilder.Entity<Office>().HasData(
                new Office("Amsterdam", new TimeSpan(08,30,00), new TimeSpan(17,00,00)) { Id = 1},
                new Office("Berlin", new TimeSpan(08, 30, 00), new TimeSpan(20, 00, 00)) { Id = 2 }
            );

            modelBuilder.Entity<MeetingRoom>().HasData(
                new MeetingRoom("101", 10, 1, 10) { Id = 1 },
                new MeetingRoom("102", 20, 1, 20) { Id = 2 },
                new MeetingRoom("103", 10, 1, 0) { Id = 3 },
                new MeetingRoom("201", 10, 1, 10) { Id = 4 },
                new MeetingRoom("202", 20, 1, 20) { Id = 5 },
                new MeetingRoom("203", 10, 1, 0) { Id = 6 }
            );

            modelBuilder.Entity<UnmovableResource>().HasData(
                new { Id = 1, ResourceType = ResourceType.WhiteBoard, MeetingRoomId = 1 },
                new { Id = 2, ResourceType = ResourceType.Beamer, MeetingRoomId = 1 },

                new { Id = 3, ResourceType = ResourceType.WhiteBoard, MeetingRoomId = 2 },

                new { Id = 4, ResourceType = ResourceType.WhiteBoard, MeetingRoomId = 3 },
                new { Id = 5, ResourceType = ResourceType.Beamer, MeetingRoomId = 3 },

                new { Id = 6, ResourceType = ResourceType.WhiteBoard, MeetingRoomId = 4 },

                new { Id = 7, ResourceType = ResourceType.WhiteBoard, MeetingRoomId = 5 },
                new { Id = 8, ResourceType = ResourceType.Beamer, MeetingRoomId = 5 },

                new { Id = 9, ResourceType = ResourceType.WhiteBoard, MeetingRoomId = 6 }
            );
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
