using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class addAuditObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilySquareDetails_FamilySquare_FamilySquareId",
                table: "FamilySquareDetails");

            migrationBuilder.RenameColumn(
                name: "FamilySquareId",
                table: "FamilySquareDetails",
                newName: "familySquareId");

            migrationBuilder.RenameIndex(
                name: "IX_FamilySquareDetails_FamilySquareId",
                table: "FamilySquareDetails",
                newName: "IX_FamilySquareDetails_familySquareId");

            migrationBuilder.CreateTable(
                name: "AuditHistory",
                columns: table => new
                {
                    AuditHistoryId = table.Column<string>(nullable: false),
                    auditTaskId = table.Column<string>(nullable: true),
                    auditTaskHistoryName = table.Column<string>(nullable: true),
                    auditType = table.Column<int>(nullable: false),
                    auditResult = table.Column<int>(nullable: false),
                    comments = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditHistory", x => x.AuditHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "AuditTask",
                columns: table => new
                {
                    auditTaskId = table.Column<string>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    auditTaskName = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    contents = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    approvalStatus = table.Column<int>(nullable: false),
                    applicator = table.Column<string>(nullable: true),
                    familyId = table.Column<string>(nullable: true),
                    openDate = table.Column<DateTime>(nullable: false),
                    closeDate = table.Column<DateTime>(nullable: false),
                    objectName = table.Column<string>(nullable: true),
                    objectId = table.Column<string>(nullable: true),
                    objectChange = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTask", x => x.auditTaskId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FamilySquareDetails_FamilySquare_familySquareId",
                table: "FamilySquareDetails",
                column: "familySquareId",
                principalTable: "FamilySquare",
                principalColumn: "FamilySquareId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilySquareDetails_FamilySquare_familySquareId",
                table: "FamilySquareDetails");

            migrationBuilder.DropTable(
                name: "AuditHistory");

            migrationBuilder.DropTable(
                name: "AuditTask");

            migrationBuilder.RenameColumn(
                name: "familySquareId",
                table: "FamilySquareDetails",
                newName: "FamilySquareId");

            migrationBuilder.RenameIndex(
                name: "IX_FamilySquareDetails_familySquareId",
                table: "FamilySquareDetails",
                newName: "IX_FamilySquareDetails_FamilySquareId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilySquareDetails_FamilySquare_FamilySquareId",
                table: "FamilySquareDetails",
                column: "FamilySquareId",
                principalTable: "FamilySquare",
                principalColumn: "FamilySquareId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
