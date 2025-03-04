using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addOwnerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "StudyRooms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StudyRooms_OwnerId",
                table: "StudyRooms",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyRooms_AspNetUsers_OwnerId",
                table: "StudyRooms",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyRooms_AspNetUsers_OwnerId",
                table: "StudyRooms");

            migrationBuilder.DropIndex(
                name: "IX_StudyRooms_OwnerId",
                table: "StudyRooms");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "StudyRooms");
        }
    }
}
