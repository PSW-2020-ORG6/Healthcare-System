﻿// <auto-generated />
using System;
using HealthClinicBackend.Backend.Events.EventLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HealthClinicBackend.Migrations
{
    [DbContext(typeof(EventDbContext))]
    [Migration("20210118161201_migration2")]
    partial class migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HealthClinicBackend.Backend.Events.PatientRegisteredEventLogging.PatientAppointmentEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChoosenPhysician")
                        .HasColumnType("text");

                    b.Property<string>("ChoosenSpecialization")
                        .HasColumnType("text");

                    b.Property<bool>("IsAppointmentScheduled")
                        .HasColumnType("boolean");

                    b.Property<string>("SchedulingDuration")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TransitionsFromFourToThreeStep")
                        .HasColumnType("integer");

                    b.Property<int>("TransitionsFromThreeToTwoStep")
                        .HasColumnType("integer");

                    b.Property<int>("TransitionsFromTwoToOneStep")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PatientAppointmentEvents");
                });

            modelBuilder.Entity("HealthClinicBackend.Backend.Events.PatientRegisteredEventLogging.PatientRegisteredEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("PatientAge")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("PatientRegisteredEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
