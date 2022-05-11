using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class updateFamilySquareModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilySquareDetails_Family_FamilyId",
                table: "FamilySquareDetails");

            migrationBuilder.DropIndex(
                name: "IX_FamilySquareDetails_FamilyId",
                table: "FamilySquareDetails");

            migrationBuilder.AlterColumn<string>(
                name: "FamilyId",
                table: "FamilySquareDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FamilyId",
                table: "FamilySquareDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilySquareDetails_FamilyId",
                table: "FamilySquareDetails",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilySquareDetails_Family_FamilyId",
                table: "FamilySquareDetails",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "FamilyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
