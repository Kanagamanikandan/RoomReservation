using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.API.Migrations
{
    public partial class EntityConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "orderseq",
                schema: "reservation");

            migrationBuilder.CreateSequence(
                name: "movableresourcesseq",
                schema: "reservation",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "officeseq",
                schema: "reservation",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "reservationseq",
                schema: "reservation",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "unmovableresourcesseq",
                schema: "reservation",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "reservations",
                schema: "reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    MeetingRoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservations_meetingRooms_MeetingRoomId",
                        column: x => x.MeetingRoomId,
                        principalSchema: "reservation",
                        principalTable: "meetingRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movableResources",
                schema: "reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ResourceType = table.Column<int>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movableResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movableResources_reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalSchema: "reservation",
                        principalTable: "reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movableResources_ReservationId",
                schema: "reservation",
                table: "movableResources",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_MeetingRoomId",
                schema: "reservation",
                table: "reservations",
                column: "MeetingRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movableResources",
                schema: "reservation");

            migrationBuilder.DropTable(
                name: "reservations",
                schema: "reservation");

            migrationBuilder.DropSequence(
                name: "movableresourcesseq",
                schema: "reservation");

            migrationBuilder.DropSequence(
                name: "officeseq",
                schema: "reservation");

            migrationBuilder.DropSequence(
                name: "reservationseq",
                schema: "reservation");

            migrationBuilder.DropSequence(
                name: "unmovableresourcesseq",
                schema: "reservation");

            migrationBuilder.CreateSequence(
                name: "orderseq",
                schema: "reservation",
                incrementBy: 10);
        }
    }
}
