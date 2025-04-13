using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addIsConnectedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConnected",
                table: "StudyRoomUsers",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConnected",
                table: "StudyRoomUsers");
        }
    }
}
