using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyRooms_Pomodoros_PomodoroId",
                table: "StudyRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyRoomUsers_StudyRooms_StudyRoomId",
                table: "StudyRoomUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyRooms_Pomodoros_PomodoroId",
                table: "StudyRooms",
                column: "PomodoroId",
                principalTable: "Pomodoros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyRoomUsers_StudyRooms_StudyRoomId",
                table: "StudyRoomUsers",
                column: "StudyRoomId",
                principalTable: "StudyRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyRooms_Pomodoros_PomodoroId",
                table: "StudyRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyRoomUsers_StudyRooms_StudyRoomId",
                table: "StudyRoomUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyRooms_Pomodoros_PomodoroId",
                table: "StudyRooms",
                column: "PomodoroId",
                principalTable: "Pomodoros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyRoomUsers_StudyRooms_StudyRoomId",
                table: "StudyRoomUsers",
                column: "StudyRoomId",
                principalTable: "StudyRooms",
                principalColumn: "Id");
        }
    }
}
