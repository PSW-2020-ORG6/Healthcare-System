﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication.Backend.Model;

namespace WebApplication.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Accounts.Patient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Contact")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Guest")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ParentName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = "0002",
                            Contact = "kontakt",
                            DateOfBirth = new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "email",
                            Gender = "Zensko",
                            Guest = true,
                            Name = "Jelena",
                            ParentName = "otac",
                            Password = "sifra",
                            SerialNumber = "2c5cf1c4-e87a-468f-b612-5940154b9e51",
                            Surname = "Tanjic"
                        },
                        new
                        {
                            Id = "0003",
                            Contact = "kontaktMica",
                            DateOfBirth = new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emailMica",
                            Gender = "Zensko",
                            Guest = true,
                            Name = "Sara",
                            ParentName = "mama",
                            Password = "sifraMica",
                            SerialNumber = "58072d3b-bb70-467c-9d05-79f4457951b8",
                            Surname = "Milic"
                        });
                });

            modelBuilder.Entity("Model.Blog.Feedback", b =>
                {
                    b.Property<string>("SerialNumber")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<bool>("Approved")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PatientId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SerialNumber");

                    b.ToTable("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
