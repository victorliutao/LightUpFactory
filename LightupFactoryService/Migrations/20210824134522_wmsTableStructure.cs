using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class wmsTableStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createDate",
                table: "Capa",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updateDate",
                table: "Capa",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createDate",
                table: "Aqllevel",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updateDate",
                table: "Aqllevel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Customerid = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Addressline1 = table.Column<string>(nullable: true),
                    Addressline2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Customername = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Faxnumber = table.Column<string>(nullable: true),
                    Isfrozen = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Phonenumber = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Customerid);
                });

            migrationBuilder.CreateTable(
                name: "Enterprise",
                columns: table => new
                {
                    EnterpriseId = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EnterpriseName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    contactPerson = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    EnterpriseCode = table.Column<string>(nullable: true),
                    ext1 = table.Column<string>(nullable: true),
                    ext2 = table.Column<string>(nullable: true),
                    ext3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprise", x => x.EnterpriseId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Productid = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Bomid = table.Column<string>(nullable: true),
                    Brandname = table.Column<string>(nullable: true),
                    Catalognumber = table.Column<string>(nullable: true),
                    Currentcost = table.Column<decimal>(nullable: true),
                    Customerid = table.Column<string>(nullable: true),
                    Customerproductnumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Devicetype = table.Column<string>(nullable: true),
                    Documentsetid = table.Column<string>(nullable: true),
                    Eco = table.Column<string>(nullable: true),
                    Erpbomid = table.Column<string>(nullable: true),
                    Erprouteid = table.Column<string>(nullable: true),
                    Glentity = table.Column<string>(nullable: true),
                    Inspectall = table.Column<int>(nullable: true),
                    Inventorycontrolled = table.Column<int>(nullable: true),
                    Isfrozen = table.Column<int>(nullable: true),
                    Isphantom = table.Column<int>(nullable: true),
                    Lotcontrolled = table.Column<int>(nullable: true),
                    Modelnumber = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Plannedcost = table.Column<decimal>(nullable: true),
                    Productfamilyid = table.Column<string>(nullable: true),
                    Productrevision = table.Column<string>(nullable: true),
                    Producttypeid = table.Column<string>(nullable: true),
                    Serialcontrolled = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    Stdcost = table.Column<decimal>(nullable: true),
                    Stdstartqty = table.Column<decimal>(nullable: true),
                    Stdstartqty2 = table.Column<decimal>(nullable: true),
                    Stdstartuom2id = table.Column<string>(nullable: true),
                    Stdstartuomid = table.Column<string>(nullable: true),
                    Stockpointcontrolled = table.Column<int>(nullable: true),
                    Subfactory = table.Column<string>(nullable: true),
                    Targetcycletime = table.Column<decimal>(nullable: true),
                    Targetdurationperunit = table.Column<decimal>(nullable: true),
                    Targetfinalyield = table.Column<decimal>(nullable: true),
                    Targetrolledthroughputyield = table.Column<decimal>(nullable: true),
                    Targetunitsperhour = table.Column<decimal>(nullable: true),
                    Trainingreqgroupid = table.Column<string>(nullable: true),
                    Workflowid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Productid);
                });

            migrationBuilder.CreateTable(
                name: "Productfamily",
                columns: table => new
                {
                    Productfamilyid = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Currentcost = table.Column<decimal>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Documentsetid = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Plannedcost = table.Column<decimal>(nullable: true),
                    Productfamilyname = table.Column<string>(nullable: true),
                    Stdcost = table.Column<decimal>(nullable: true),
                    Stdstartqty = table.Column<decimal>(nullable: true),
                    Stdstartqty2 = table.Column<decimal>(nullable: true),
                    Stdstartuom2id = table.Column<string>(nullable: true),
                    Stdstartuomid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productfamily", x => x.Productfamilyid);
                });

            migrationBuilder.CreateTable(
                name: "Producttype",
                columns: table => new
                {
                    Producttypeid = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Isfrozen = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Producttypename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producttype", x => x.Producttypeid);
                });

            migrationBuilder.CreateTable(
                name: "ServiceObject",
                columns: table => new
                {
                    ServiceObjectId = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ServiceObjectName = table.Column<string>(nullable: true),
                    ControllerName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RedirectName = table.Column<string>(nullable: true),
                    RedirectUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceObject", x => x.ServiceObjectId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRegister",
                columns: table => new
                {
                    ServiceId = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ServiceName = table.Column<string>(nullable: true),
                    ServiceObjectId = table.Column<string>(nullable: true),
                    ControllerName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    showInAdd = table.Column<int>(nullable: true),
                    showInEdit = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRegister", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "serviceRequestLog",
                columns: table => new
                {
                    serviceRequestLogId = table.Column<string>(nullable: false),
                    requestDate = table.Column<DateTime>(nullable: true),
                    serviceName = table.Column<string>(nullable: true),
                    controllerName = table.Column<string>(nullable: true),
                    actionName = table.Column<string>(nullable: true),
                    requestParams = table.Column<string>(nullable: true),
                    txt1 = table.Column<string>(nullable: true),
                    txt2 = table.Column<string>(nullable: true),
                    txt3 = table.Column<string>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    httpHead = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceRequestLog", x => x.serviceRequestLogId);
                });

            migrationBuilder.CreateTable(
                name: "StockPoint",
                columns: table => new
                {
                    StockPointId = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    StockName = table.Column<string>(nullable: true),
                    dimensionUnit = table.Column<string>(nullable: true),
                    Width = table.Column<string>(nullable: true),
                    Length = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Draw_Background = table.Column<string>(nullable: true),
                    Draw_SVG = table.Column<string>(nullable: true),
                    Draw_Xposition = table.Column<string>(nullable: true),
                    Draw_YPosition = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    areaUnit = table.Column<string>(nullable: true),
                    Volume = table.Column<string>(nullable: true),
                    VolumeUnit = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    WarehouseId = table.Column<string>(nullable: true),
                    isPhatom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPoint", x => x.StockPointId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Supplierid = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Suppliername = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Supplierid);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Unitid = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Filtertags = table.Column<string>(nullable: true),
                    Isfrozen = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Unitname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Unitid);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true),
                    User_password = table.Column<string>(nullable: true),
                    FactoryId = table.Column<string>(nullable: true),
                    WorkCenterId = table.Column<string>(nullable: true),
                    ResourceId = table.Column<string>(nullable: true),
                    ResourceGroupId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehouseId = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    dimensionUnit = table.Column<string>(nullable: true),
                    Width = table.Column<string>(nullable: true),
                    Length = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Draw_Background = table.Column<string>(nullable: true),
                    Draw_SVG = table.Column<string>(nullable: true),
                    areaUnit = table.Column<string>(nullable: true),
                    Volume = table.Column<string>(nullable: true),
                    VolumeUnit = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsPhatom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.WarehouseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Enterprise");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Productfamily");

            migrationBuilder.DropTable(
                name: "Producttype");

            migrationBuilder.DropTable(
                name: "ServiceObject");

            migrationBuilder.DropTable(
                name: "ServiceRegister");

            migrationBuilder.DropTable(
                name: "serviceRequestLog");

            migrationBuilder.DropTable(
                name: "StockPoint");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropColumn(
                name: "createDate",
                table: "Capa");

            migrationBuilder.DropColumn(
                name: "updateDate",
                table: "Capa");

            migrationBuilder.DropColumn(
                name: "createDate",
                table: "Aqllevel");

            migrationBuilder.DropColumn(
                name: "updateDate",
                table: "Aqllevel");
        }
    }
}
