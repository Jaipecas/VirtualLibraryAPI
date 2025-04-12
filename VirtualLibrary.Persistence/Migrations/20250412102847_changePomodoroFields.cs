using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changePomodoroFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStudyTime",
                table: "StudyRooms");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "StudyRooms");

            migrationBuilder.AddColumn<bool>(
                name: "IsStudyTime",
                table: "Pomodoros",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Pomodoros",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStudyTime",
                table: "Pomodoros");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Pomodoros");

            migrationBuilder.AddColumn<bool>(
                name: "IsStudyTime",
                table: "StudyRooms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "StudyRooms",
                type: "datetime2",
                nullable: true);
        }
    }
}
