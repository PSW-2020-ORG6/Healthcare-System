using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "Surveys",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "ID",
                keyValue: "001",
                column: "DoctorName",
                value: "Pera Peric");

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "ID",
                keyValue: "005",
                column: "DoctorName",
                value: "Mika Mikic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "Surveys");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "4d9dae21-7088-422e-82f7-c8ff6cbc5bd0");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "7e9cdc01-3628-4623-98c9-71a366106ca5");
        }
    }
}
