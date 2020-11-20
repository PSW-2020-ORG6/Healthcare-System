using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class migracija1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "0ac3da1e-bac8-4004-8469-d2d874315845");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "b439874b-fa9e-43d3-b824-f233b2a3167b");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "8b59b122-8a01-4d76-8993-04c96896f2f8");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "3caa3334-ee68-4861-a65f-db3db48c9728");
        }
    }
}
