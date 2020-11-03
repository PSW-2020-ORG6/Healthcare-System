using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class migracija1174 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "SerialNumber",
                keyValue: "3a99838f-25dd-436e-a1c1-7e4d14f41fb8");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "SerialNumber", "Contact", "DateOfBirth", "Email", "Gender", "Guest", "Id", "Name", "ParentName", "Password", "Surname" },
                values: new object[] { "b2c09339-c304-4c2c-addf-826574519faf", "kontakt", new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "email", "Zensko", true, "0001", "Tanja", "otac", "sifra", "Tanjic" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "SerialNumber",
                keyValue: "b2c09339-c304-4c2c-addf-826574519faf");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "SerialNumber", "Contact", "DateOfBirth", "Email", "Gender", "Guest", "Id", "Name", "ParentName", "Password", "Surname" },
                values: new object[] { "3a99838f-25dd-436e-a1c1-7e4d14f41fb8", "kontakt", new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "email", "Zensko", true, "0001", "Tanja", "otac", "sifra", "Tanjic" });
        }
    }
}
