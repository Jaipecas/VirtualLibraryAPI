using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addStartTime_IsStudyTime2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoros_StudyRooms_StudyRoomId",
                table: "Pomodoros");

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoros_StudyRooms_StudyRoomId",
                table: "Pomodoros",
                column: "StudyRoomId",
                principalTable: "StudyRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoros_StudyRooms_StudyRoomId",
                table: "Pomodoros");

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoros_StudyRooms_StudyRoomId",
                table: "Pomodoros",
                column: "StudyRoomId",
                principalTable: "StudyRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
