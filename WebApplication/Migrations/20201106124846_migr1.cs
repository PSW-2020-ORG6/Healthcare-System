using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class migr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "SerialNumber",
                keyValue: "0cb6ae43-5e76-45de-a80b-54433873b23c");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "SerialNumber",
                keyValue: "dfc185a6-33ed-446b-b020-a4c514031c48");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "SerialNumber",
                keyValue: "88f2bd84-104d-4ec2-bfaa-04362d6f9cd2");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "SerialNumber",
                keyValue: "e58822d8-3b84-4f1d-9f9a-6b2bde33f50d");

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "SerialNumber", "Approved", "Date", "PatientId", "Text" },
                values: new object[,]
                {
                    { "dfc185a6-33ed-446b-b020-a4c514031c48", true, new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0002", "komentara3" },
                    { "0cb6ae43-5e76-45de-a80b-54433873b23c", true, new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0003", "komentara3" }
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "39ada87d-2b95-4d69-9e03-a8420bbbf5fe");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "e8aaec05-aa10-493d-8578-482b19e62928");
        }
    }
}
