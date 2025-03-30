using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addRoomRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RoomId",
                table: "Notifications",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_StudyRooms_RoomId",
                table: "Notifications",
                column: "RoomId",
                principalTable: "StudyRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_StudyRooms_RoomId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_RoomId",
                table: "Notifications");
        }
    }
}
