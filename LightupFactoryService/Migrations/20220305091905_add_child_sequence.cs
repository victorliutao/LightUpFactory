using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class add_child_sequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "childSeq",
                table: "MemberRelation",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "childSeq",
                table: "MemberRelation");
        }
    }
}
