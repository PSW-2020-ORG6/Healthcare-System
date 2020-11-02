﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication.Backend.Model;

namespace WebApplication.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20201102230123_mijg95554448")]
    partial class mijg95554448
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

                    b.Property<string>("Name")
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
                            Name = "Ime1",
                            Text = "tekst komentara1"
                        },
                        new
                        {
                            Id = "2",
                            Approved = false,
                            Name = "Ime2",
                            Text = "tekst komentara2"
                        },
                        new
                        {
                            Id = "3",
                            Approved = true,
                            Name = "Ime3",
                            Text = "tekst komentara3"
                        },
                        new
                        {
                            Id = "4",
                            Approved = false,
                            Name = "Ime4",
                            Text = "tekst komentara4"
                        },
                        new
                        {
                            Id = "5",
                            Approved = false,
                            Name = "Ime5",
                            Text = "tekst komentara5"
                        },
                        new
                        {
                            Id = "6",
                            Approved = true,
                            Name = "Ime6",
                            Text = "tekst komentara6"
                        },
                        new
                        {
                            Id = "7",
                            Approved = false,
                            Name = "Ime5",
                            Text = "tekst komentara5"
                        },
                        new
                        {
                            Id = "8",
                            Approved = false,
                            Name = "Ime5",
                            Text = "tekst komentara5"
                        },
                        new
                        {
                            Id = "9",
                            Approved = false,
                            Name = "Ime5",
                            Text = "tekst komentara5"
                        },
                        new
                        {
                            Id = "10",
                            Approved = false,
                            Name = "Ime5",
                            Text = "tekst komentara5"
                        },
                        new
                        {
                            Id = "11",
                            Approved = false,
                            Name = "Ime5",
                            Text = "tekst komentara5"
                        },
                        new
                        {
                            Id = "15",
                            Approved = false,
                            Name = "Ime5",
                            Text = "tekst komentara5"
                        },
                        new
                        {
                            Id = "17",
                            Approved = false,
                            Name = "Ime5",
                            Text = "tekst komentara5"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
