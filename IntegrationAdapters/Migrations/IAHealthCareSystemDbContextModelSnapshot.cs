﻿// <auto-generated />
using System;
using IntegrationAdapters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationAdapters.Migrations
{
    [DbContext(typeof(IAHealthCareSystemDbContext))]
    partial class IAHealthCareSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IntegrationAdapters.Models.ActionAndBenefitMessage", b =>
                {
                    b.Property<Guid>("ActionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("ActionID");

                    b.ToTable("ActionAndBenefitMessage");
                });

            modelBuilder.Entity("IntegrationAdapters.Models.Api", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("text");

                    b.Property<bool>("Subscribed")
                        .HasColumnType("boolean");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.ToTable("Apis");
                });

            modelBuilder.Entity("IntegrationAdapters.Models.Medicine", b =>
                {
                    b.Property<string>("MedicineID")
                        .HasColumnType("text");

                    b.Property<string>("MedicineSpecificationID")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("MedicineID");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("IntegrationAdapters.Models.MedicineDosage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("MedicineName")
                        .HasColumnType("text");

                    b.Property<string>("MedicineReportId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedicineReportId");

                    b.ToTable("MedicineDosage");
                });

            modelBuilder.Entity("IntegrationAdapters.Models.MedicineReport", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("IntegrationAdapters.Models.MedicineSpecification", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Producer")
                        .HasColumnType("text");

                    b.Property<string>("Regime")
                        .HasColumnType("text");

                    b.Property<string>("Shape")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("MedicineSpecification");
                });

            modelBuilder.Entity("IntegrationAdapters.Models.Offer", b =>
                {
                    b.Property<string>("CompanyEmail")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<string>("TenderName")
                        .HasColumnType("text");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("integer");

                    b.HasKey("CompanyEmail");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("IntegrationAdapters.Models.Tender", b =>
                {
                    b.Property<string>("TenderName")
                        .HasColumnType("text");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("MedicineName")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("TenderName");

                    b.ToTable("Tender");
                });

            modelBuilder.Entity("IntegrationAdapters.Models.MedicineDosage", b =>
                {
                    b.HasOne("IntegrationAdapters.Models.MedicineReport", null)
                        .WithMany("Dosage")
                        .HasForeignKey("MedicineReportId");
                });
#pragma warning restore 612, 618
        }
    }
}
