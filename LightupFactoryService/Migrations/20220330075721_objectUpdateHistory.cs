using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class objectUpdateHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectsEditHistory",
                columns: table => new
                {
                    ObjectsEditHistoryId = table.Column<string>(nullable: false),
                    objectName = table.Column<string>(nullable: true),
                    objectId = table.Column<string>(nullable: true),
                    changeCount = table.Column<int>(nullable: false),
                    changeContent = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectsEditHistory", x => x.ObjectsEditHistoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectsEditHistory");
        }
    }
}
