﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class connectionIdField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "StudyRoomUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "StudyRoomUsers");
        }
    }
}
