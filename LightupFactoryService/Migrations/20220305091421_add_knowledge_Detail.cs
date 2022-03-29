using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class add_knowledge_Detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KnowledgeDetail",
                columns: table => new
                {
                    KnowledgeDetailId = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    changeCount = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    optionField1 = table.Column<string>(nullable: true),
                    optionField2 = table.Column<string>(nullable: true),
                    optionField3 = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeDetail", x => x.KnowledgeDetailId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnowledgeDetail");
        }
    }
}
