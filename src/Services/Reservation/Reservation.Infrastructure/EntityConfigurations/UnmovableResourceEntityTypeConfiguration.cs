using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;

namespace Reservation.Infrastructure.EntityConfigurations
{
    class UnmovableResourceEntityTypeConfiguration : IEntityTypeConfiguration<UnmovableResource>
    {
        public void Configure(EntityTypeBuilder<UnmovableResource> entity)
        {
            entity.ToTable("unmovableResources", ReservationContext.DEFAULT_SCHEMA);

            entity.HasKey(e => e.Id);

            entity.Ignore(e => e.DomainEvents);

            entity.Property(e => e.Id)
                .UseHiLo("unmovableresourcesseq", ReservationContext.DEFAULT_SCHEMA);

            entity.Property<int>("MeetingRoomId")
                .IsRequired(true);
        }
    }
}
