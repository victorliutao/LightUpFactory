using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class familySquareEnhance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "livingMemQty",
                table: "Family",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "passedMemQty",
                table: "Family",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "showScope",
                table: "Family",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "livingMemQty",
                table: "Family");

            migrationBuilder.DropColumn(
                name: "passedMemQty",
                table: "Family");

            migrationBuilder.DropColumn(
                name: "showScope",
                table: "Family");
        }
    }
}
