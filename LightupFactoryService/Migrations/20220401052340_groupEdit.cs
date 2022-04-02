using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class groupEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "changeCount",
                table: "ObjectsEditHistory",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "residence",
                table: "Member",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupEdit",
                columns: table => new
                {
                    GroupEditId = table.Column<string>(nullable: false),
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
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    sectionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEdit", x => x.GroupEditId);
                });

            migrationBuilder.CreateTable(
                name: "GroupEditHistory",
                columns: table => new
                {
                    GroupEditHistoryId = table.Column<string>(nullable: false),
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
                    GroupEditId = table.Column<string>(nullable: true),
                    modifyName = table.Column<string>(nullable: true),
                    contents = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEditHistory", x => x.GroupEditHistoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupEdit");

            migrationBuilder.DropTable(
                name: "GroupEditHistory");

            migrationBuilder.DropColumn(
                name: "residence",
                table: "Member");

            migrationBuilder.AlterColumn<int>(
                name: "changeCount",
                table: "ObjectsEditHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
