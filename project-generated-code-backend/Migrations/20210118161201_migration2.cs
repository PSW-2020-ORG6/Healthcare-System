using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HealthClinicBackend.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientAppointmentEvents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    TransitionsFromTwoToOneStep = table.Column<int>(nullable: false),
                    TransitionsFromThreeToTwoStep = table.Column<int>(nullable: false),
                    TransitionsFromFourToThreeStep = table.Column<int>(nullable: false),
                    SchedulingDuration = table.Column<string>(nullable: true),
                    IsAppointmentScheduled = table.Column<bool>(nullable: false),
                    ChoosenPhysician = table.Column<string>(nullable: true),
                    ChoosenSpecialization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAppointmentEvents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAppointmentEvents");
        }
    }
}
