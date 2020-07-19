using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.API.Migrations
{
    public partial class seedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "reservation",
                table: "offices",
                columns: new[] { "Id", "City", "CloseTime", "OpenTime" },
                values: new object[] { 1, "Amsterdam", new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 30, 0, 0) });

            migrationBuilder.InsertData(
                schema: "reservation",
                table: "offices",
                columns: new[] { "Id", "City", "CloseTime", "OpenTime" },
                values: new object[] { 2, "Berlin", new TimeSpan(0, 20, 0, 0, 0), new TimeSpan(0, 8, 30, 0, 0) });

            migrationBuilder.InsertData(
                schema: "reservation",
                table: "meetingRooms",
                columns: new[] { "Id", "Capacity", "NumberOfChairs", "OfficeId", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 10, 10, 1, "101" },
                    { 2, 20, 20, 1, "102" },
                    { 3, 10, 0, 1, "103" },
                    { 4, 10, 10, 1, "201" },
                    { 5, 20, 20, 1, "202" },
                    { 6, 10, 0, 1, "203" }
                });

            migrationBuilder.InsertData(
                schema: "reservation",
                table: "unmovableResources",
                columns: new[] { "Id", "MeetingRoomId", "ResourceType" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 3 },
                    { 3, 2, 1 },
                    { 4, 3, 1 },
                    { 5, 3, 3 },
                    { 6, 4, 1 },
                    { 7, 5, 1 },
                    { 8, 5, 3 },
                    { 9, 6, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "offices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "unmovableResources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "unmovableResources",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "unmovableResources",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "unmovableResources",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "unmovableResources",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "unmovableResources",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "unmovableResources",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "unmovableResources",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "unmovableResources",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "meetingRooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "meetingRooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "meetingRooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "meetingRooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "meetingRooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "meetingRooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "offices",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
