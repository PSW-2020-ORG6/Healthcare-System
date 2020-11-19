using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class anketa1888 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "f55d790e-cd9f-456c-a181-5f505739eb90");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "b5f06689-083a-4eef-a8ee-b474f04560a8");

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "ID",
                keyValue: "001",
                column: "SerialNumber",
                value: "98fe8f32-2482-4ad2-8425-9e3dc60a7f2a");
        }
    }
}
