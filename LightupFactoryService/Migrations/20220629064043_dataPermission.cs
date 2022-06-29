using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class dataPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dataPermission",
                columns: table => new
                {
                    dataPermissionId = table.Column<string>(nullable: false),
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
                    objectName = table.Column<string>(nullable: true),
                    objectId = table.Column<string>(nullable: true),
                    showScope = table.Column<string>(nullable: true),
                    scopeUserId = table.Column<string>(nullable: true),
                    scopeMemberId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataPermission", x => x.dataPermissionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dataPermission");
        }
    }
}
