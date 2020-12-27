using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationAdapters.Migrations
{
    public partial class fm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionAndBenefitMessage",
                columns: table => new
                {
                    ActionID = table.Column<Guid>(nullable: false),
                    PharmacyName = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionAndBenefitMessage", x => x.ActionID);
                });

            migrationBuilder.CreateTable(
                name: "Apis",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    PharmacyName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Subscribed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apis", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    MedicineID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MedicineSpecificationID = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.MedicineID);
                });

            migrationBuilder.CreateTable(
                name: "MedicineSpecification",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Regime = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineSpecification", x => x.ID);
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
                name: "Tender",
                columns: table => new
                {
                    TenderName = table.Column<string>(nullable: false),
                    MedicineName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tender", x => x.TenderName);
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
                name: "ActionAndBenefitMessage");

            migrationBuilder.DropTable(
                name: "Apis");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "MedicineDosage");

            migrationBuilder.DropTable(
                name: "MedicineSpecification");

            migrationBuilder.DropTable(
                name: "Tender");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
