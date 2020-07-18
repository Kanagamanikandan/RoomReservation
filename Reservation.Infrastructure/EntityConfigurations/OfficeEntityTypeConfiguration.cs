using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Domain.AggregatesModel.OfficeAggregate;
using System;

namespace Reservation.Infrastructure.EntityConfigurations
{
    class OfficeEntityTypeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> officeConfiguration)
        {
            officeConfiguration.ToTable("offices", ReservationContext.DEFAULT_SCHEMA);

            officeConfiguration.HasKey(o => o.Id);

            officeConfiguration.Ignore(b => b.DomainEvents);

            officeConfiguration.Property(o => o.Id)
                .UseHiLo("orderseq", ReservationContext.DEFAULT_SCHEMA);

            officeConfiguration.Property<string>("_city")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("City")
                .IsRequired(true);

            officeConfiguration.Property<TimeSpan>("_openTime")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("OpenTime")
                .IsRequired(true);

            officeConfiguration.Property<TimeSpan>("_closeTime")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CloseTime")
                .IsRequired(true);
        }
    }
}
