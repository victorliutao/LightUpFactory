using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class updateKnowledge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassId",
                table: "KnowledgePoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "KnowledgePoint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "KnowledgePoint");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "KnowledgePoint");
        }
    }
}
