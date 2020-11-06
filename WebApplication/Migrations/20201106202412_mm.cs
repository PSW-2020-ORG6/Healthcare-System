using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class mm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "SerialNumber",
                keyValue: "88f2bd84-104d-4ec2-bfaa-04362d6f9cd2");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "SerialNumber",
                keyValue: "e58822d8-3b84-4f1d-9f9a-6b2bde33f50d");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "d6ed01f1-fd09-47df-aff7-3dbb49e4d099");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "d64666e9-f83e-44bb-b2ed-bcc5fe1a574c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "SerialNumber", "Approved", "Date", "PatientId", "Text" },
                values: new object[,]
                {
                    { "88f2bd84-104d-4ec2-bfaa-04362d6f9cd2", true, new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0002", "komentara3" },
                    { "e58822d8-3b84-4f1d-9f9a-6b2bde33f50d", true, new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0003", "komentara3" }
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "b8a0c798-33df-4727-9fa1-3a6c3ee3490a");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "ad3c44cb-85cc-4cee-bf5a-31bdaf48fa58");
        }
    }
}
