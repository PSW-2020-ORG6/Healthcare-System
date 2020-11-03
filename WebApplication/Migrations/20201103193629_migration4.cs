using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Patients_Id",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0001");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Feedbacks");

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Patients",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Patients_Id",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "SerialNumber");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "SerialNumber", "Contact", "DateOfBirth", "Email", "Gender", "Guest", "Id", "Name", "ParentName", "Password", "Surname" },
                values: new object[] { "b2c09339-c304-4c2c-addf-826574519faf", "kontakt", new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "email", "Zensko", true, "0001", "Tanja", "otac", "sifra", "Tanjic" });
        }
    }
}
