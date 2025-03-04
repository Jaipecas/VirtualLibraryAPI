using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCascadeDelete4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyRooms_Pomodoros_PomodoroId",
                table: "StudyRooms");

            migrationBuilder.DropIndex(
                name: "IX_StudyRooms_PomodoroId",
                table: "StudyRooms");

            migrationBuilder.DropColumn(
                name: "PomodoroId",
                table: "StudyRooms");

            migrationBuilder.AddColumn<int>(
                name: "StudyRoomId",
                table: "Pomodoros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pomodoros_StudyRoomId",
                table: "Pomodoros",
                column: "StudyRoomId",
                unique: true);

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

            migrationBuilder.DropIndex(
                name: "IX_Pomodoros_StudyRoomId",
                table: "Pomodoros");

            migrationBuilder.DropColumn(
                name: "StudyRoomId",
                table: "Pomodoros");

            migrationBuilder.AddColumn<int>(
                name: "PomodoroId",
                table: "StudyRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudyRooms_PomodoroId",
                table: "StudyRooms",
                column: "PomodoroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyRooms_Pomodoros_PomodoroId",
                table: "StudyRooms",
                column: "PomodoroId",
                principalTable: "Pomodoros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
