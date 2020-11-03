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
    [Migration("20201103124457_migracija1")]
    partial class migracija1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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
                            Text = "tekst komentara1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
