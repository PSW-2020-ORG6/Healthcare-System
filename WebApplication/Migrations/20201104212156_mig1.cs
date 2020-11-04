using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Feedbacks");

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Feedbacks",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "SerialNumber");

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "SerialNumber", "Approved", "Date", "PatientId", "Text" },
                values: new object[,]
                {
                    { "1279749f-3344-4d73-afc3-25d06431492e", true, new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0002", "komentara3" },
                    { "3edfdd60-2df9-4b1f-a5a7-e343f105daa1", true, new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0003", "komentara3" }
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "2eb30a4d-9fac-4c4f-b29b-cc2c11a39a41");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "fb991288-29be-4b06-a062-4bab45fd0ec8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "SerialNumber",
                keyValue: "1279749f-3344-4d73-afc3-25d06431492e");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "SerialNumber",
                keyValue: "3edfdd60-2df9-4b1f-a5a7-e343f105daa1");

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Feedbacks",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Feedbacks",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Approved", "Date", "PatientId", "SerialNumber", "Text" },
                values: new object[] { "2", true, new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ime2", "2", "tekst komentara2" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "fd558114-33a3-4dde-89af-9c92699145a0");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "8b306d26-512a-4aa2-9f50-8353ae11d738");
        }
    }
}
