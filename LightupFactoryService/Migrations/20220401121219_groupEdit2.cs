using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class groupEdit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sectionId",
                table: "GroupEdit");

            migrationBuilder.AddColumn<int>(
                name: "sequence",
                table: "GroupEdit",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sequence",
                table: "GroupEdit");

            migrationBuilder.AddColumn<string>(
                name: "sectionId",
                table: "GroupEdit",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
