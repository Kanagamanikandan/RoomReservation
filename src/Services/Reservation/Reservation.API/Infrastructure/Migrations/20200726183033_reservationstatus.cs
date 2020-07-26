using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.API.Migrations
{
    public partial class reservationstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                schema: "reservation",
                table: "reservations",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time0");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                schema: "reservation",
                table: "reservations",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time0");

            migrationBuilder.AddColumn<int>(
                name: "ReservationStatus",
                schema: "reservation",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationStatus",
                schema: "reservation",
                table: "reservations");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                schema: "reservation",
                table: "reservations",
                type: "time0",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                schema: "reservation",
                table: "reservations",
                type: "time0",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)");
        }
    }
}
