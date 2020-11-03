﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication.Backend.Model;

namespace WebApplication.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20201103193629_migration4")]
    partial class migration4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = "0001",
                            Contact = "kontakt",
                            DateOfBirth = new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "email",
                            Gender = "Zensko",
                            Guest = true,
                            Name = "Tanja",
                            ParentName = "otac",
                            Password = "sifra",
                            SerialNumber = "53c4e467-3b34-4238-a27e-edcd40a2fc86",
                            Surname = "Tanjic"
                        });
                });

            modelBuilder.Entity("Model.Blog.Feedback", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<bool>("Approved")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PatientId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Approved = true,
                            Date = new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PatientId = "Ime1",
                            SerialNumber = "f0204215-de41-451d-ae79-f1eb18f720a8",
                            Text = "tekst komentara1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
