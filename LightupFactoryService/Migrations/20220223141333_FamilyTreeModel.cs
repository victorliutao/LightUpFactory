using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightupFactoryService.Migrations
{
    public partial class FamilyTreeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "KnowledgePoint",
                columns: table => new
                {
                    KnowledgePointId = table.Column<string>(nullable: false),
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
                    KnowledgePointName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    ClassId = table.Column<string>(nullable: true),
                    ClassName = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgePoint", x => x.KnowledgePointId);
                });

            migrationBuilder.CreateTable(
                name: "MemberRelation",
                columns: table => new
                {
                    MemberRelationId = table.Column<string>(nullable: false),
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
                    MemberId = table.Column<string>(nullable: true),
                    RelationShipId = table.Column<string>(nullable: true),
                    parentId = table.Column<string>(nullable: true),
                    relationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRelation", x => x.MemberRelationId);
                });

            migrationBuilder.CreateTable(
                name: "RelationShip",
                columns: table => new
                {
                    RelationShipId = table.Column<string>(nullable: false),
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
                    RelationShipName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationShip", x => x.RelationShipId);
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
                name: "Story",
                columns: table => new
                {
                    storyId = table.Column<string>(nullable: false),
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
                    storyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Story", x => x.storyId);
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
                name: "Family",
                columns: table => new
                {
                    FamilyId = table.Column<string>(nullable: false),
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
                    FamilyName = table.Column<string>(nullable: true),
                    GivenName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    county = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    zipcode = table.Column<string>(nullable: true),
                    memberId = table.Column<string>(nullable: true),
                    FamilyStorystoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.FamilyId);
                    table.ForeignKey(
                        name: "FK_Family_Story_FamilyStorystoryId",
                        column: x => x.FamilyStorystoryId,
                        principalTable: "Story",
                        principalColumn: "storyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<string>(nullable: false),
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
                    MemberName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    gender = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    FamilyId = table.Column<string>(nullable: true),
                    MmeberStorystoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Member_Story_MmeberStorystoryId",
                        column: x => x.MmeberStorystoryId,
                        principalTable: "Story",
                        principalColumn: "storyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    sectionId = table.Column<string>(nullable: false),
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
                    sectionName = table.Column<string>(nullable: true),
                    storyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.sectionId);
                    table.ForeignKey(
                        name: "FK_Section_Story_storyId",
                        column: x => x.storyId,
                        principalTable: "Story",
                        principalColumn: "storyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionDetail",
                columns: table => new
                {
                    detailId = table.Column<string>(nullable: false),
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
                    sequence = table.Column<int>(nullable: false),
                    contentDesc = table.Column<string>(nullable: true),
                    sectionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionDetail", x => x.detailId);
                    table.ForeignKey(
                        name: "FK_SectionDetail_Section_sectionId",
                        column: x => x.sectionId,
                        principalTable: "Section",
                        principalColumn: "sectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Family_FamilyStorystoryId",
                table: "Family",
                column: "FamilyStorystoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_MmeberStorystoryId",
                table: "Member",
                column: "MmeberStorystoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_storyId",
                table: "Section",
                column: "storyId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetail_sectionId",
                table: "SectionDetail",
                column: "sectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enterprise");

            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.DropTable(
                name: "KnowledgePoint");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "MemberRelation");

            migrationBuilder.DropTable(
                name: "RelationShip");

            migrationBuilder.DropTable(
                name: "SectionDetail");

            migrationBuilder.DropTable(
                name: "serviceRequestLog");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Story");
        }
    }
}
