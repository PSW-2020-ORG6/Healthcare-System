using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class migration45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "1",
                column: "SerialNumber",
                value: "482ef216-5586-42f9-8425-3a9be1501fd6");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0001",
                column: "SerialNumber",
                value: "d93f589e-587a-47ac-812a-8dcc0db32112");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Contact", "DateOfBirth", "Email", "Gender", "Guest", "Name", "ParentName", "Password", "SerialNumber", "Surname" },
                values: new object[] { "0004", "kontaktMica", new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailMica", "Zensko", true, "Milica", "mama", "sifraMica", "77d5badd-628b-4d0c-ad1e-bf6a10fa1604", "Milic" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0004");

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "1",
                column: "SerialNumber",
                value: "f0204215-de41-451d-ae79-f1eb18f720a8");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0001",
                column: "SerialNumber",
                value: "53c4e467-3b34-4238-a27e-edcd40a2fc86");
        }
    }
}
