using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addStartTime_IsStudyTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoros_StudyRooms_StudyRoomId",
                table: "Pomodoros");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyRooms_AspNetUsers_OwnerId",
                table: "StudyRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyRoomUsers_AspNetUsers_UserId",
                table: "StudyRoomUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyRoomUsers_StudyRooms_StudyRoomId",
                table: "StudyRoomUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "StudyRoomUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoros_StudyRooms_StudyRoomId",
                table: "Pomodoros",
                column: "StudyRoomId",
                principalTable: "StudyRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyRooms_AspNetUsers_OwnerId",
                table: "StudyRooms",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyRoomUsers_AspNetUsers_UserId",
                table: "StudyRoomUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyRoomUsers_StudyRooms_StudyRoomId",
                table: "StudyRoomUsers",
                column: "StudyRoomId",
                principalTable: "StudyRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoros_StudyRooms_StudyRoomId",
                table: "Pomodoros");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyRooms_AspNetUsers_OwnerId",
                table: "StudyRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyRoomUsers_AspNetUsers_UserId",
                table: "StudyRoomUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyRoomUsers_StudyRooms_StudyRoomId",
                table: "StudyRoomUsers");

            migrationBuilder.DropColumn(
                name: "IsStudyTime",
                table: "StudyRooms");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "StudyRooms");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "StudyRoomUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoros_StudyRooms_StudyRoomId",
                table: "Pomodoros",
                column: "StudyRoomId",
                principalTable: "StudyRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyRooms_AspNetUsers_OwnerId",
                table: "StudyRooms",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyRoomUsers_AspNetUsers_UserId",
                table: "StudyRoomUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyRoomUsers_StudyRooms_StudyRoomId",
                table: "StudyRoomUsers",
                column: "StudyRoomId",
                principalTable: "StudyRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
