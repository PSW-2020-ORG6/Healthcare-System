using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "SerialNumber",
                keyValue: "1279749f-3344-4d73-afc3-25d06431492e");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "SerialNumber",
                keyValue: "3edfdd60-2df9-4b1f-a5a7-e343f105daa1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
