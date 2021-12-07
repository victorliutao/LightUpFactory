using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class capaadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capa",
                columns: table => new
                {
                    Capaid = table.Column<string>(nullable: false),
                    Is_Delete = table.Column<int>(nullable: true),
                    Is_Locked = table.Column<int>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Attachmentsid = table.Column<string>(nullable: true),
                    Briefdescription = table.Column<string>(nullable: true),
                    Capacustomdataid = table.Column<string>(nullable: true),
                    Capaname = table.Column<string>(nullable: true),
                    Carresolutionaction = table.Column<int>(nullable: true),
                    Carseverityid = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: true),
                    Cdotypeid = table.Column<int>(nullable: true),
                    Changecount = table.Column<int>(nullable: true),
                    Classificationid = table.Column<string>(nullable: true),
                    Closedate = table.Column<DateTime>(nullable: true),
                    Closedategmt = table.Column<DateTime>(nullable: true),
                    Closedbyid = table.Column<string>(nullable: true),
                    Closedescription = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Initiatorid = table.Column<string>(nullable: true),
                    Initiatororganizationid = table.Column<string>(nullable: true),
                    Isfrozen = table.Column<int>(nullable: true),
                    Issubmitted = table.Column<int>(nullable: true),
                    Occurrencedate = table.Column<DateTime>(nullable: true),
                    Occurrencedategmt = table.Column<DateTime>(nullable: true),
                    Organizationid = table.Column<string>(nullable: true),
                    Origprocessmodeltemplateid = table.Column<string>(nullable: true),
                    Ownerid = table.Column<string>(nullable: true),
                    Prioritylevelid = table.Column<string>(nullable: true),
                    Processmodelid = table.Column<string>(nullable: true),
                    Proposedresolution = table.Column<string>(nullable: true),
                    Qualityresolutioncodeid = table.Column<string>(nullable: true),
                    Reporteddate = table.Column<DateTime>(nullable: true),
                    Reporteddategmt = table.Column<DateTime>(nullable: true),
                    Reporterid = table.Column<string>(nullable: true),
                    Reporterorganizationid = table.Column<string>(nullable: true),
                    Riskassessmentid = table.Column<string>(nullable: true),
                    Roleid = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    Subclassificationid = table.Column<string>(nullable: true),
                    Systemicissue = table.Column<int>(nullable: true),
                    Triagecomplete = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capa", x => x.Capaid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capa");
        }
    }
}
