using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class anketa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Surveys");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "1bf9ef2f-5216-4b7a-a288-b7591996cd10");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "9d6d731c-2c20-4ca0-905d-23470b4db804");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Surveys",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "f37672e0-8f72-47c5-94d0-3d0f0b5ec4a1");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "504607eb-7402-409d-9b7b-855201c9a2df");

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "ID",
                keyValue: "001",
                column: "SerialNumber",
                value: "a28c9167-f77a-404b-a1cc-ae1af522de11");
        }
    }
}
