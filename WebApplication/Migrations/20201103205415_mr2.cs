using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class mr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0001");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0004");

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Approved", "Date", "PatientId", "SerialNumber", "Text" },
                values: new object[] { "2", true, new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ime2", "2", "tekst komentara2" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Contact", "DateOfBirth", "Email", "Gender", "Guest", "Name", "ParentName", "Password", "SerialNumber", "Surname" },
                values: new object[] { "0003", "kontaktMica", new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailMica", "Zensko", true, "Sara", "mama", "sifraMica", "8b306d26-512a-4aa2-9f50-8353ae11d738", "Milic" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Contact", "DateOfBirth", "Email", "Gender", "Guest", "Name", "ParentName", "Password", "SerialNumber", "Surname" },
                values: new object[] { "0002", "kontakt", new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "email", "Zensko", true, "Jelena", "otac", "sifra", "fd558114-33a3-4dde-89af-9c92699145a0", "Tanjic" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003");

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Approved", "Date", "PatientId", "SerialNumber", "Text" },
                values: new object[] { "1", true, new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ime1", "0205ed43-db9d-44af-a1ba-3ad2cab37e66", "tekst komentara1" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Contact", "DateOfBirth", "Email", "Gender", "Guest", "Name", "ParentName", "Password", "SerialNumber", "Surname" },
                values: new object[] { "0004", "kontaktMica", new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailMica", "Zensko", true, "Milica", "mama", "sifraMica", "5398f5f8-618c-4cd7-a1c3-f41fce243721", "Milic" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Contact", "DateOfBirth", "Email", "Gender", "Guest", "Name", "ParentName", "Password", "SerialNumber", "Surname" },
                values: new object[] { "0001", "kontakt", new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "email", "Zensko", true, "Tanja", "otac", "sifra", "e3e512aa-6ea3-423f-8be1-eff4e934c939", "Tanjic" });
        }
    }
}
