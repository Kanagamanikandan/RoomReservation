using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "reservation");

            migrationBuilder.CreateSequence(
                name: "meetingRoomseq",
                schema: "reservation",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "orderseq",
                schema: "reservation",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "offices",
                schema: "reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    CloseTime = table.Column<TimeSpan>(nullable: false),
                    OpenTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "meetingRooms",
                schema: "reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    NumberOfChairs = table.Column<int>(nullable: false),
                    OfficeId = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meetingRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_meetingRooms_offices_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "reservation",
                        principalTable: "offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unmovableResources",
                schema: "reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ResourceType = table.Column<int>(nullable: false),
                    MeetingRoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unmovableResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_unmovableResources_meetingRooms_MeetingRoomId",
                        column: x => x.MeetingRoomId,
                        principalSchema: "reservation",
                        principalTable: "meetingRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_meetingRooms_OfficeId",
                schema: "reservation",
                table: "meetingRooms",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_unmovableResources_MeetingRoomId",
                schema: "reservation",
                table: "unmovableResources",
                column: "MeetingRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "unmovableResources",
                schema: "reservation");

            migrationBuilder.DropTable(
                name: "meetingRooms",
                schema: "reservation");

            migrationBuilder.DropTable(
                name: "offices",
                schema: "reservation");

            migrationBuilder.DropSequence(
                name: "meetingRoomseq",
                schema: "reservation");

            migrationBuilder.DropSequence(
                name: "orderseq",
                schema: "reservation");
        }
    }
}
