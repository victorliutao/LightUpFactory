using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class familySquareEnhance2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamilySquare",
                columns: table => new
                {
                    FamilySquareId = table.Column<string>(nullable: false),
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
                    FamilySquareName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ShowScope = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilySquare", x => x.FamilySquareId);
                });

            migrationBuilder.CreateTable(
                name: "FamilySquareDetails",
                columns: table => new
                {
                    FamilySquareDetailsId = table.Column<string>(nullable: false),
                    FamilySquareDetailsName = table.Column<string>(nullable: true),
                    FamilyId = table.Column<string>(nullable: true),
                    FamilySquareId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilySquareDetails", x => x.FamilySquareDetailsId);
                    table.ForeignKey(
                        name: "FK_FamilySquareDetails_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilySquareDetails_FamilySquare_FamilySquareId",
                        column: x => x.FamilySquareId,
                        principalTable: "FamilySquare",
                        principalColumn: "FamilySquareId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilySquareDetails_FamilyId",
                table: "FamilySquareDetails",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilySquareDetails_FamilySquareId",
                table: "FamilySquareDetails",
                column: "FamilySquareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilySquareDetails");

            migrationBuilder.DropTable(
                name: "FamilySquare");
        }
    }
}
