using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class isCompleteCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Cards");
        }
    }
}
