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
    [Migration("20211012123243_updateKnowledge#3")]
    partial class updateKnowledge3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LightupFactoryService.Model.Aqllevel", b =>
                {
                    b.Property<string>("Aqllevelid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Aqllevelname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Filtertags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<int?>("Isfrozen")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Aqllevelid");

                    b.ToTable("Aqllevel");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Capa", b =>
                {
                    b.Property<string>("Capaid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Attachmentsid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Briefdescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Capacustomdataid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Capaname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Carresolutionaction")
                        .HasColumnType("int");

                    b.Property<string>("Carseverityid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Category")
                        .HasColumnType("int");

                    b.Property<int?>("Cdotypeid")
                        .HasColumnType("int");

                    b.Property<int?>("Changecount")
                        .HasColumnType("int");

                    b.Property<string>("Classificationid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Closedate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Closedategmt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Closedbyid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Closedescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Initiatorid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Initiatororganizationid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<int?>("Isfrozen")
                        .HasColumnType("int");

                    b.Property<int?>("Issubmitted")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Occurrencedate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Occurrencedategmt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Organizationid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origprocessmodeltemplateid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ownerid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prioritylevelid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processmodelid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proposedresolution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qualityresolutioncodeid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Reporteddate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Reporteddategmt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reporterid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reporterorganizationid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Riskassessmentid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roleid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Subclassificationid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Systemicissue")
                        .HasColumnType("int");

                    b.Property<int?>("Triagecomplete")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Capaid");

                    b.ToTable("Capa");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Customer", b =>
                {
                    b.Property<string>("Customerid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Addressline1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Addressline2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Faxnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<int?>("Isfrozen")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phonenumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Customerid");

                    b.ToTable("Customer");
                });

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

                    b.Property<int>("changecount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("KnowledgePointId");

                    b.ToTable("KnowledgePoint");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Product", b =>
                {
                    b.Property<string>("Productid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Bomid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brandname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Catalognumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Currentcost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Customerid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customerproductnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Devicetype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documentsetid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Eco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Erpbomid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Erprouteid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Glentity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Inspectall")
                        .HasColumnType("int");

                    b.Property<int?>("Inventorycontrolled")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<int?>("Isfrozen")
                        .HasColumnType("int");

                    b.Property<int?>("Isphantom")
                        .HasColumnType("int");

                    b.Property<int?>("Lotcontrolled")
                        .HasColumnType("int");

                    b.Property<string>("Modelnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Plannedcost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Productfamilyid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Productrevision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producttypeid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Serialcontrolled")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<decimal?>("Stdcost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Stdstartqty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Stdstartqty2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Stdstartuom2id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stdstartuomid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Stockpointcontrolled")
                        .HasColumnType("int");

                    b.Property<string>("Subfactory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Targetcycletime")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Targetdurationperunit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Targetfinalyield")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Targetrolledthroughputyield")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Targetunitsperhour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Trainingreqgroupid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Workflowid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Productid");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Productfamily", b =>
                {
                    b.Property<string>("Productfamilyid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("Currentcost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documentsetid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Plannedcost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Productfamilyname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Stdcost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Stdstartqty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Stdstartqty2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Stdstartuom2id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stdstartuomid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Productfamilyid");

                    b.ToTable("Productfamily");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Producttype", b =>
                {
                    b.Property<string>("Producttypeid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<int?>("Isfrozen")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producttypename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Producttypeid");

                    b.ToTable("Producttype");
                });

            modelBuilder.Entity("LightupFactoryService.Model.ServiceObject", b =>
                {
                    b.Property<string>("ServiceObjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ControllerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("RedirectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RedirectUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceObjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ServiceObjectId");

                    b.ToTable("ServiceObject");
                });

            modelBuilder.Entity("LightupFactoryService.Model.ServiceRegister", b =>
                {
                    b.Property<string>("ServiceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ControllerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceObjectId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("showInAdd")
                        .HasColumnType("int");

                    b.Property<int?>("showInEdit")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ServiceId");

                    b.ToTable("ServiceRegister");
                });

            modelBuilder.Entity("LightupFactoryService.Model.StockPoint", b =>
                {
                    b.Property<string>("StockPointId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Draw_Background")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Draw_SVG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Draw_Xposition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Draw_YPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("Length")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Volume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VolumeUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehouseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Width")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("areaUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("dimensionUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isPhatom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StockPointId");

                    b.ToTable("StockPoint");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Supplier", b =>
                {
                    b.Property<string>("Supplierid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suppliername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Supplierid");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("LightupFactoryService.Model.Unit", b =>
                {
                    b.Property<string>("Unitid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Filtertags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<int?>("Isfrozen")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unitname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Unitid");

                    b.ToTable("Unit");
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

            modelBuilder.Entity("LightupFactoryService.Model.Warehouse", b =>
                {
                    b.Property<string>("WarehouseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Draw_Background")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Draw_SVG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsPhatom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Is_Delete")
                        .HasColumnType("int");

                    b.Property<int?>("Is_Locked")
                        .HasColumnType("int");

                    b.Property<string>("Length")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Volume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VolumeUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Width")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("areaUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("dimensionUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouse");
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
#pragma warning restore 612, 618
        }
    }
}
