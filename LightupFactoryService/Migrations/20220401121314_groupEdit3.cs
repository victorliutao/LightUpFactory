using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class groupEdit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sectionId",
                table: "GroupEdit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupEdit_sectionId",
                table: "GroupEdit",
                column: "sectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEdit_Section_sectionId",
                table: "GroupEdit",
                column: "sectionId",
                principalTable: "Section",
                principalColumn: "sectionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupEdit_Section_sectionId",
                table: "GroupEdit");

            migrationBuilder.DropIndex(
                name: "IX_GroupEdit_sectionId",
                table: "GroupEdit");

            migrationBuilder.DropColumn(
                name: "sectionId",
                table: "GroupEdit");
        }
    }
}
