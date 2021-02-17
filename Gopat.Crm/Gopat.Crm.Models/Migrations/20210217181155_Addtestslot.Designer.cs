﻿// <auto-generated />
using System;
using Gopat.Crm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gopat.Crm.Models.Migrations
{
    [DbContext(typeof(GopatContext))]
    [Migration("20210217181155_Addtestslot")]
    partial class Addtestslot
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Gopat.Crm.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ApplianceTotal")
                        .HasColumnType("int");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("bit");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ContractId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpectedApplianceTotal")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Rescheduled")
                        .HasColumnType("bit");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("SiteId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Gopat.Crm.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TradingStyle")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Gopat.Crm.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobRole")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Gopat.Crm.Models.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CancelledDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("IntervalMonths")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RenewalDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SiteId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Gopat.Crm.Models.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("Gopat.Crm.Models.TestSlot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ActualAppliances")
                        .HasColumnType("int");

                    b.Property<int?>("ActualDurationMins")
                        .HasColumnType("int");

                    b.Property<Guid?>("ContractId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstimatedAppliances")
                        .HasColumnType("int");

                    b.Property<int>("EstimatedDurationMins")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ScheduledDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TestSlowResult")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("SiteId");

                    b.ToTable("TestSlots");
                });

            modelBuilder.Entity("Gopat.Crm.Models.Appointment", b =>
                {
                    b.HasOne("Gopat.Crm.Models.Contract", null)
                        .WithMany("Appointments")
                        .HasForeignKey("ContractId");

                    b.HasOne("Gopat.Crm.Models.Site", "Site")
                        .WithMany("Appointments")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Gopat.Crm.Models.Owned.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("AppointmentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<long>("ApplianceTestFee")
                                .HasColumnType("bigint");

                            b1.Property<long>("CalloutFee")
                                .HasColumnType("bigint");

                            b1.HasKey("AppointmentId");

                            b1.ToTable("Appointments");

                            b1.WithOwner()
                                .HasForeignKey("AppointmentId");
                        });

                    b.Navigation("Price");

                    b.Navigation("Site");
                });

            modelBuilder.Entity("Gopat.Crm.Models.Company", b =>
                {
                    b.OwnsOne("Gopat.Crm.Models.Owned.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Area")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("BuildingNumberName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Postcode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StreetName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Gopat.Crm.Models.Contact", b =>
                {
                    b.HasOne("Gopat.Crm.Models.Company", "Company")
                        .WithMany("Contacts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Gopat.Crm.Models.Owned.EmailAddress", "EmailAddress", b1 =>
                        {
                            b1.Property<Guid>("ContactId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ContactId");

                            b1.ToTable("Contacts");

                            b1.WithOwner()
                                .HasForeignKey("ContactId");
                        });

                    b.OwnsOne("Gopat.Crm.Models.Owned.Person", "Person", b1 =>
                        {
                            b1.Property<Guid>("ContactId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ContactId");

                            b1.ToTable("Contacts");

                            b1.WithOwner()
                                .HasForeignKey("ContactId");
                        });

                    b.OwnsOne("Gopat.Crm.Models.Owned.Telephone", "Telephone", b1 =>
                        {
                            b1.Property<Guid>("ContactId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ContactId");

                            b1.ToTable("Contacts");

                            b1.WithOwner()
                                .HasForeignKey("ContactId");
                        });

                    b.Navigation("Company");

                    b.Navigation("EmailAddress");

                    b.Navigation("Person");

                    b.Navigation("Telephone");
                });

            modelBuilder.Entity("Gopat.Crm.Models.Contract", b =>
                {
                    b.HasOne("Gopat.Crm.Models.Company", "Company")
                        .WithMany("Contracts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gopat.Crm.Models.Site", "Site")
                        .WithMany("Contracts")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.OwnsOne("Gopat.Crm.Models.Owned.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("ContractId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<long>("ApplianceTestFee")
                                .HasColumnType("bigint");

                            b1.Property<long>("CalloutFee")
                                .HasColumnType("bigint");

                            b1.HasKey("ContractId");

                            b1.ToTable("Contracts");

                            b1.WithOwner()
                                .HasForeignKey("ContractId");
                        });

                    b.Navigation("Company");

                    b.Navigation("Price");

                    b.Navigation("Site");
                });

            modelBuilder.Entity("Gopat.Crm.Models.Site", b =>
                {
                    b.HasOne("Gopat.Crm.Models.Company", "Company")
                        .WithMany("Sites")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Gopat.Crm.Models.Owned.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("SiteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Area")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("BuildingNumberName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Postcode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StreetName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SiteId");

                            b1.ToTable("Sites");

                            b1.WithOwner()
                                .HasForeignKey("SiteId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Gopat.Crm.Models.TestSlot", b =>
                {
                    b.HasOne("Gopat.Crm.Models.Contract", "Contract")
                        .WithMany("TestSlots")
                        .HasForeignKey("ContractId");

                    b.HasOne("Gopat.Crm.Models.Site", "Site")
                        .WithMany("TestSlots")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Gopat.Crm.Models.Owned.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("TestSlotId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<long>("ApplianceTestFee")
                                .HasColumnType("bigint");

                            b1.Property<long>("CalloutFee")
                                .HasColumnType("bigint");

                            b1.HasKey("TestSlotId");

                            b1.ToTable("TestSlots");

                            b1.WithOwner()
                                .HasForeignKey("TestSlotId");
                        });

                    b.Navigation("Contract");

                    b.Navigation("Price");

                    b.Navigation("Site");
                });

            modelBuilder.Entity("Gopat.Crm.Models.Company", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Contracts");

                    b.Navigation("Sites");
                });

            modelBuilder.Entity("Gopat.Crm.Models.Contract", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("TestSlots");
                });

            modelBuilder.Entity("Gopat.Crm.Models.Site", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Contracts");

                    b.Navigation("TestSlots");
                });
#pragma warning restore 612, 618
        }
    }
}