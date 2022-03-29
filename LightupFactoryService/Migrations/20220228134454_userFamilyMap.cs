using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class userFamilyMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFamilyMapping",
                columns: table => new
                {
                    UserFamilyMapId = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    changeCount = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    optionField1 = table.Column<string>(nullable: true),
                    optionField2 = table.Column<string>(nullable: true),
                    optionField3 = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    FamilyId = table.Column<string>(nullable: true),
                    MemberId = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFamilyMapping", x => x.UserFamilyMapId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFamilyMapping");
        }
    }
}
