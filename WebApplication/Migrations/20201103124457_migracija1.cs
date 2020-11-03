using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class migracija1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "15");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "17");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "174");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "1774");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Feedbacks");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Feedbacks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Date", "PatientId" },
                values: new object[] { new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ime1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Feedbacks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Feedbacks",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "Ime1");

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Approved", "Name", "Text" },
                values: new object[,]
                {
                    { "2", false, "Ime2", "tekst komentara2" },
                    { "3", true, "Ime3", "tekst komentara3" },
                    { "4", false, "Ime4", "tekst komentara4" },
                    { "5", false, "Ime5", "tekst komentara5" },
                    { "6", true, "Ime6", "tekst komentara6" },
                    { "7", false, "Ime5", "tekst komentara5" },
                    { "8", false, "Ime5", "tekst komentara5" },
                    { "9", false, "Ime5", "tekst komentara5" },
                    { "10", false, "Ime5", "tekst komentara5" },
                    { "11", false, "Ime5", "tekst komentara5" },
                    { "15", false, "Ime5", "tekst komentara5" },
                    { "17", false, "Ime5", "tekst komentara5" },
                    { "174", false, "Ime5", "tekst komentara5" },
                    { "1774", false, "Ime5", "tekst komentara5" }
                });
        }
    }
}
