using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Domain.AggregatesModel.ReservationAggregate;

namespace Reservation.Infrastructure.EntityConfigurations
{
    public class MovableResourceEntityTypeConfiguration : IEntityTypeConfiguration<MovableResource>
    {
        public void Configure(EntityTypeBuilder<MovableResource> entity)
        {
            entity.ToTable("movableResources", ReservationContext.DEFAULT_SCHEMA);

            entity.HasKey(e => e.Id);

            entity.Ignore(e => e.DomainEvents);

            entity.Property(e => e.Id)
                .UseHiLo("movableresourcesseq", ReservationContext.DEFAULT_SCHEMA);

            entity.Property<int>("ReservationId")
                .IsRequired(true);
        }
    }
}
