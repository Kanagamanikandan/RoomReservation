using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.API.Migrations
{
    public partial class reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                schema: "reservation",
                table: "reservations",
                type: "time(0)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDate",
                schema: "reservation",
                table: "reservations",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                schema: "reservation",
                table: "reservations",
                type: "time(0)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                schema: "reservation",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "ReservationDate",
                schema: "reservation",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "StartTime",
                schema: "reservation",
                table: "reservations");
        }
    }
}
