using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class family : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceObject");

            migrationBuilder.DropTable(
                name: "ServiceRegister");

            migrationBuilder.AddColumn<string>(
                name: "optionField1",
                table: "Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField2",
                table: "Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField3",
                table: "Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField1",
                table: "Unit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField2",
                table: "Unit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField3",
                table: "Unit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField1",
                table: "Supplier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField2",
                table: "Supplier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField3",
                table: "Supplier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField1",
                table: "StockPoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField2",
                table: "StockPoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField3",
                table: "StockPoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField1",
                table: "Producttype",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField2",
                table: "Producttype",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField3",
                table: "Producttype",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField1",
                table: "Productfamily",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField2",
                table: "Productfamily",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField3",
                table: "Productfamily",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField1",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField2",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField3",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField1",
                table: "KnowledgePoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField2",
                table: "KnowledgePoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField3",
                table: "KnowledgePoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField1",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField2",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField3",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField1",
                table: "Capa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField2",
                table: "Capa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField3",
                table: "Capa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField1",
                table: "Aqllevel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField2",
                table: "Aqllevel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "optionField3",
                table: "Aqllevel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    FamilyId = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    optionField1 = table.Column<string>(nullable: true),
                    optionField2 = table.Column<string>(nullable: true),
                    optionField3 = table.Column<string>(nullable: true),
                    FamilyName = table.Column<string>(nullable: true),
                    GivenName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    county = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    zipcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.FamilyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.DropColumn(
                name: "optionField1",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "optionField2",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "optionField3",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "optionField1",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "optionField2",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "optionField3",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "optionField1",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "optionField2",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "optionField3",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "optionField1",
                table: "StockPoint");

            migrationBuilder.DropColumn(
                name: "optionField2",
                table: "StockPoint");

            migrationBuilder.DropColumn(
                name: "optionField3",
                table: "StockPoint");

            migrationBuilder.DropColumn(
                name: "optionField1",
                table: "Producttype");

            migrationBuilder.DropColumn(
                name: "optionField2",
                table: "Producttype");

            migrationBuilder.DropColumn(
                name: "optionField3",
                table: "Producttype");

            migrationBuilder.DropColumn(
                name: "optionField1",
                table: "Productfamily");

            migrationBuilder.DropColumn(
                name: "optionField2",
                table: "Productfamily");

            migrationBuilder.DropColumn(
                name: "optionField3",
                table: "Productfamily");

            migrationBuilder.DropColumn(
                name: "optionField1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "optionField2",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "optionField3",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "optionField1",
                table: "KnowledgePoint");

            migrationBuilder.DropColumn(
                name: "optionField2",
                table: "KnowledgePoint");

            migrationBuilder.DropColumn(
                name: "optionField3",
                table: "KnowledgePoint");

            migrationBuilder.DropColumn(
                name: "optionField1",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "optionField2",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "optionField3",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "optionField1",
                table: "Capa");

            migrationBuilder.DropColumn(
                name: "optionField2",
                table: "Capa");

            migrationBuilder.DropColumn(
                name: "optionField3",
                table: "Capa");

            migrationBuilder.DropColumn(
                name: "optionField1",
                table: "Aqllevel");

            migrationBuilder.DropColumn(
                name: "optionField2",
                table: "Aqllevel");

            migrationBuilder.DropColumn(
                name: "optionField3",
                table: "Aqllevel");

            migrationBuilder.CreateTable(
                name: "ServiceObject",
                columns: table => new
                {
                    ServiceObjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnterpriseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Delete = table.Column<int>(type: "int", nullable: true),
                    Is_Locked = table.Column<int>(type: "int", nullable: true),
                    RedirectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceObjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceObject", x => x.ServiceObjectId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRegister",
                columns: table => new
                {
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnterpriseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Delete = table.Column<int>(type: "int", nullable: true),
                    Is_Locked = table.Column<int>(type: "int", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceObjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    showInAdd = table.Column<int>(type: "int", nullable: true),
                    showInEdit = table.Column<int>(type: "int", nullable: true),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRegister", x => x.ServiceId);
                });
        }
    }
}
