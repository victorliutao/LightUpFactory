﻿// <auto-generated />
using System;
using LightupFactoryService.ContextStr;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LightupFactoryService.Migrations
{
    [DbContext(typeof(LightUpFactoryContext))]
    [Migration("20220223141333_FamilyTreeModel")]
    partial class FamilyTreeModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LightupFactoryService.Model.Enterprise", b =>
                {
                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contactPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ext1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ext2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ext3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EnterpriseId");

                    b.ToTable("Enterprise");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Family", b =>
                {
                    b.Property<string>("FamilyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyStorystoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GivenName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("changeCount")
                        .HasColumnType("int");

                    b.Property<string>("county")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("memberId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FamilyId");

                    b.HasIndex("FamilyStorystoryId");

                    b.ToTable("Family");
                });

            modelBuilder.Entity("LightupFactoryService.Model.KnowledgePoint", b =>
                {
                    b.Property<string>("KnowledgePointId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("KnowledgePointName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("changeCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("optionField1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sequence")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("KnowledgePointId");

                    b.ToTable("KnowledgePoint");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Member", b =>
                {
                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("MemberName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MmeberStorystoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("changeCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MemberId");

                    b.HasIndex("MmeberStorystoryId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("LightupFactoryService.Model.MemberRelation", b =>
                {
                    b.Property<string>("MemberRelationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelationShipId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("changeCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("optionField1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("parentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("relationId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MemberRelationId");

                    b.ToTable("MemberRelation");
                });

            modelBuilder.Entity("LightupFactoryService.Model.RelationShip", b =>
                {
                    b.Property<string>("RelationShipId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("RelationShipName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("changeCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("optionField1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RelationShipId");

                    b.ToTable("RelationShip");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Section", b =>
                {
                    b.Property<string>("sectionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("changeCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("optionField1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sectionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("storyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("sectionId");

                    b.HasIndex("storyId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("LightupFactoryService.Model.SectionDetail", b =>
                {
                    b.Property<string>("detailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("changeCount")
                        .HasColumnType("int");

                    b.Property<string>("contentDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("optionField1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sectionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("sequence")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("detailId");

                    b.HasIndex("sectionId");

                    b.ToTable("SectionDetail");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Story", b =>
                {
                    b.Property<string>("storyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("changeCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("optionField1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("optionField3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("storyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("storyId");

                    b.ToTable("Story");
                });

            modelBuilder.Entity("LightupFactoryService.Model.UserInfo", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("ResourceGroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResourceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkCenterId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("LightupFactoryService.Model.serviceRequestLog", b =>
                {
                    b.Property<string>("serviceRequestLogId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("actionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("controllerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("httpHead")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("requestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("requestParams")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("serviceRequestLogId");

                    b.ToTable("serviceRequestLog");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Family", b =>
                {
                    b.HasOne("LightupFactoryService.Model.Story", "FamilyStory")
                        .WithMany()
                        .HasForeignKey("FamilyStorystoryId");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Member", b =>
                {
                    b.HasOne("LightupFactoryService.Model.Story", "MmeberStory")
                        .WithMany()
                        .HasForeignKey("MmeberStorystoryId");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Section", b =>
                {
                    b.HasOne("LightupFactoryService.Model.Story", null)
                        .WithMany("storyContent")
                        .HasForeignKey("storyId");
                });

            modelBuilder.Entity("LightupFactoryService.Model.SectionDetail", b =>
                {
                    b.HasOne("LightupFactoryService.Model.Section", null)
                        .WithMany("sectionDetails")
                        .HasForeignKey("sectionId");
                });
#pragma warning restore 612, 618
        }
    }
}
