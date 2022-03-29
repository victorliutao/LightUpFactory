using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class add_Member_MarrageFamily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "marriageFamilyId",
                table: "Member",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "marriageFamilyId",
                table: "Member");
        }
    }
}
