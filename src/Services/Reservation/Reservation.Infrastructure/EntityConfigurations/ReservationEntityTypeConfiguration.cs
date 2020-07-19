namespace Reservation.Infrastructure.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
    using Reservation.Domain.AggregatesModel.ReservationAggregate;
    using System;

    class ReservationEntityTypeConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> entity)
        {
            entity.ToTable("reservations", ReservationContext.DEFAULT_SCHEMA);

            entity.HasKey(e => e.Id);

            entity.Ignore(e => e.DomainEvents);

            entity.Property(e => e.Id)
                .UseHiLo("reservationseq", ReservationContext.DEFAULT_SCHEMA);

            entity.Property<int>("_meetingRoomId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MeetingRoomId")
                .IsRequired(true);

            entity.Property<int>("_employeeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("EmployeeId")
                .IsRequired(true);

            entity.Property<DateTime>("_reservationDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ReservationDate")
                .HasColumnType("date")
                .IsRequired(true);

            entity.Property<TimeSpan>("_startTime")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("StartTime")
                .HasColumnType("time(0)")
                .IsRequired(true);

            entity.Property<TimeSpan>("_endTime")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("EndTime")
                .HasColumnType("time(0)")
                .IsRequired(true);

            entity.HasOne<MeetingRoom>()
                .WithMany()
                .HasForeignKey("_meetingRoomId");

            var navigation = entity.Metadata.FindNavigation(nameof(Reservation.MovableResources));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
