namespace Reservation.Infrastructure.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
    using Reservation.Domain.AggregatesModel.ReservationAggregate;
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
            
            entity.HasOne<MeetingRoom>()
                .WithMany()
                .HasForeignKey("_meetingRoomId");

            var navigation = entity.Metadata.FindNavigation(nameof(Reservation.MovableResources));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
