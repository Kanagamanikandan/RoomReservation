﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservation.Infrastructure;

namespace Reservation.API.Migrations
{
    [DbContext(typeof(ReservationContext))]
    [Migration("20200719131341_seedInitialData")]
    partial class seedInitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:reservation.meetingRoomseq", "'meetingRoomseq', 'reservation', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:reservation.movableresourcesseq", "'movableresourcesseq', 'reservation', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:reservation.officeseq", "'officeseq', 'reservation', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:reservation.reservationseq", "'reservationseq', 'reservation', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:reservation.unmovableresourcesseq", "'unmovableresourcesseq', 'reservation', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reservation.Domain.AggregatesModel.MeetingRoomAggregate.MeetingRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "meetingRoomseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "reservation")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("_capacity")
                        .HasColumnName("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("_numberOfChairs")
                        .HasColumnName("NumberOfChairs")
                        .HasColumnType("int");

                    b.Property<int>("_officeId")
                        .HasColumnName("OfficeId")
                        .HasColumnType("int");

                    b.Property<string>("_roomNumber")
                        .IsRequired()
                        .HasColumnName("RoomNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("_officeId");

                    b.ToTable("meetingRooms","reservation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            _capacity = 10,
                            _numberOfChairs = 10,
                            _officeId = 1,
                            _roomNumber = "101"
                        },
                        new
                        {
                            Id = 2,
                            _capacity = 20,
                            _numberOfChairs = 20,
                            _officeId = 1,
                            _roomNumber = "102"
                        },
                        new
                        {
                            Id = 3,
                            _capacity = 10,
                            _numberOfChairs = 0,
                            _officeId = 1,
                            _roomNumber = "103"
                        },
                        new
                        {
                            Id = 4,
                            _capacity = 10,
                            _numberOfChairs = 10,
                            _officeId = 1,
                            _roomNumber = "201"
                        },
                        new
                        {
                            Id = 5,
                            _capacity = 20,
                            _numberOfChairs = 20,
                            _officeId = 1,
                            _roomNumber = "202"
                        },
                        new
                        {
                            Id = 6,
                            _capacity = 10,
                            _numberOfChairs = 0,
                            _officeId = 1,
                            _roomNumber = "203"
                        });
                });

            modelBuilder.Entity("Reservation.Domain.AggregatesModel.MeetingRoomAggregate.UnmovableResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "unmovableresourcesseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "reservation")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("MeetingRoomId")
                        .HasColumnType("int");

                    b.Property<int>("ResourceType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeetingRoomId");

                    b.ToTable("unmovableResources","reservation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MeetingRoomId = 1,
                            ResourceType = 1
                        },
                        new
                        {
                            Id = 2,
                            MeetingRoomId = 1,
                            ResourceType = 3
                        },
                        new
                        {
                            Id = 3,
                            MeetingRoomId = 2,
                            ResourceType = 1
                        },
                        new
                        {
                            Id = 4,
                            MeetingRoomId = 3,
                            ResourceType = 1
                        },
                        new
                        {
                            Id = 5,
                            MeetingRoomId = 3,
                            ResourceType = 3
                        },
                        new
                        {
                            Id = 6,
                            MeetingRoomId = 4,
                            ResourceType = 1
                        },
                        new
                        {
                            Id = 7,
                            MeetingRoomId = 5,
                            ResourceType = 1
                        },
                        new
                        {
                            Id = 8,
                            MeetingRoomId = 5,
                            ResourceType = 3
                        },
                        new
                        {
                            Id = 9,
                            MeetingRoomId = 6,
                            ResourceType = 1
                        });
                });

            modelBuilder.Entity("Reservation.Domain.AggregatesModel.OfficeAggregate.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "officeseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "reservation")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("_city")
                        .IsRequired()
                        .HasColumnName("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("_closeTime")
                        .HasColumnName("CloseTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("_openTime")
                        .HasColumnName("OpenTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("offices","reservation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            _city = "Amsterdam",
                            _closeTime = new TimeSpan(0, 17, 0, 0, 0),
                            _openTime = new TimeSpan(0, 8, 30, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            _city = "Berlin",
                            _closeTime = new TimeSpan(0, 20, 0, 0, 0),
                            _openTime = new TimeSpan(0, 8, 30, 0, 0)
                        });
                });

            modelBuilder.Entity("Reservation.Domain.AggregatesModel.ReservationAggregate.MovableResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "movableresourcesseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "reservation")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("ResourceType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("movableResources","reservation");
                });

            modelBuilder.Entity("Reservation.Domain.AggregatesModel.ReservationAggregate.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "reservationseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "reservation")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("_employeeId")
                        .HasColumnName("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("_meetingRoomId")
                        .HasColumnName("MeetingRoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("_meetingRoomId");

                    b.ToTable("reservations","reservation");
                });

            modelBuilder.Entity("Reservation.Domain.AggregatesModel.MeetingRoomAggregate.MeetingRoom", b =>
                {
                    b.HasOne("Reservation.Domain.AggregatesModel.OfficeAggregate.Office", null)
                        .WithMany()
                        .HasForeignKey("_officeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Reservation.Domain.AggregatesModel.MeetingRoomAggregate.UnmovableResource", b =>
                {
                    b.HasOne("Reservation.Domain.AggregatesModel.MeetingRoomAggregate.MeetingRoom", null)
                        .WithMany("UnmovableResources")
                        .HasForeignKey("MeetingRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Reservation.Domain.AggregatesModel.ReservationAggregate.MovableResource", b =>
                {
                    b.HasOne("Reservation.Domain.AggregatesModel.ReservationAggregate.Reservation", null)
                        .WithMany("MovableResources")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Reservation.Domain.AggregatesModel.ReservationAggregate.Reservation", b =>
                {
                    b.HasOne("Reservation.Domain.AggregatesModel.MeetingRoomAggregate.MeetingRoom", null)
                        .WithMany()
                        .HasForeignKey("_meetingRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
