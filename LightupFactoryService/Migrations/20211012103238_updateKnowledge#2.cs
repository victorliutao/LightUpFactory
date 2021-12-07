using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class updateKnowledge2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "KnowledgePoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "KnowledgePoint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "KnowledgePoint");

            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "KnowledgePoint");
        }
    }
}
