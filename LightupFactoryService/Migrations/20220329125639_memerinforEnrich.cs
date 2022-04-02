using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class memerinforEnrich : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "birthDad",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "birthMom",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "callingName",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dateOfBirth",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dateOfBirthLunar",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dateOfDeath",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dateOfDeathLunar",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "givenName",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "headImage",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "middleName",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "raiseDad",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "raiseMom",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "respectName",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "templeName",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tombDate",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tombLocation",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "yearName",
                table: "Member",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birthDad",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "birthMom",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "callingName",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "dateOfBirth",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "dateOfBirthLunar",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "dateOfDeath",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "dateOfDeathLunar",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "givenName",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "headImage",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "middleName",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "raiseDad",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "raiseMom",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "respectName",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "templeName",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "tombDate",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "tombLocation",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "yearName",
                table: "Member");
        }
    }
}
