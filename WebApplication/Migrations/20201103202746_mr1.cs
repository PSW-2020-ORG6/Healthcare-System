using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class mr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "1",
                column: "SerialNumber",
                value: "0205ed43-db9d-44af-a1ba-3ad2cab37e66");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0001",
                column: "SerialNumber",
                value: "e3e512aa-6ea3-423f-8be1-eff4e934c939");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0004",
                column: "SerialNumber",
                value: "5398f5f8-618c-4cd7-a1c3-f41fce243721");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0004",
                column: "SerialNumber",
                value: "77d5badd-628b-4d0c-ad1e-bf6a10fa1604");
        }
    }
}
