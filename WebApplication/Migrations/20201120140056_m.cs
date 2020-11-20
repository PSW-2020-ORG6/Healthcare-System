using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "ID", "Question1", "Question10", "Question11", "Question12", "Question13", "Question14", "Question15", "Question16", "Question17", "Question18", "Question19", "Question2", "Question20", "Question21", "Question22", "Question23", "Question3", "Question4", "Question5", "Question6", "Question7", "Question8", "Question9" },
                values: new object[] { "005", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "ID",
                keyValue: "005");

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
    }
}
