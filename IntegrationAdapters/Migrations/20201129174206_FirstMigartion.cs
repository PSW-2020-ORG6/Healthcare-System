using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationAdapters.Migrations
{
    public partial class FirstMigartion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apis",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    PharmacyName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apis", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineDosage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicineName = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    MedicineReportId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDosage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineDosage_Reports_MedicineReportId",
                        column: x => x.MedicineReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDosage_MedicineReportId",
                table: "MedicineDosage",
                column: "MedicineReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apis");

            migrationBuilder.DropTable(
                name: "MedicineDosage");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
