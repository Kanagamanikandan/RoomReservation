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

            entity.Ignore(b => b.DomainEvents);

            entity.Property(o => o.Id)
                .UseHiLo("orderseq", ReservationContext.DEFAULT_SCHEMA);

            entity.Property<int>("MeetingRoomId")
                .IsRequired(true);
        }
    }
}
