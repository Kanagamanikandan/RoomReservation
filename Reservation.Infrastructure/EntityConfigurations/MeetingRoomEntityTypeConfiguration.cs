using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
using Reservation.Domain.AggregatesModel.OfficeAggregate;
using System.Collections.Concurrent;

namespace Reservation.Infrastructure.EntityConfigurations
{
    class MeetingRoomEntityTypeConfiguration : IEntityTypeConfiguration<MeetingRoom>
    {
        public void Configure(EntityTypeBuilder<MeetingRoom> meetingRoomConfiguration)
        {
            meetingRoomConfiguration.ToTable("meetingRooms", ReservationContext.DEFAULT_SCHEMA);

            meetingRoomConfiguration.HasKey(m => m.Id);

            meetingRoomConfiguration.Ignore(b => b.DomainEvents);

            meetingRoomConfiguration.Property(m => m.Id)
                .UseHiLo("meetingRoomseq", ReservationContext.DEFAULT_SCHEMA);

            meetingRoomConfiguration.Property<string>("_roomNumber")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("RoomNumber")
                .IsRequired(true);

            meetingRoomConfiguration.Property<int>("_officeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("OfficeId")
                .IsRequired(true);

            meetingRoomConfiguration.Property<int>("_capacity")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Capacity")
                .IsRequired(true);

            meetingRoomConfiguration.Property<int>("_numberOfChairs")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("NumberOfChairs")
                .IsRequired(true);

            meetingRoomConfiguration.HasOne<Office>()
                .WithMany()
                .HasForeignKey("_officeId");

            var navigation = meetingRoomConfiguration.Metadata.FindNavigation(nameof(MeetingRoom.UnmovableResources));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
