using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class anketa188 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Survey",
                table: "Survey");

            migrationBuilder.RenameTable(
                name: "Survey",
                newName: "Surveys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys",
                column: "ID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys");

            migrationBuilder.RenameTable(
                name: "Surveys",
                newName: "Survey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Survey",
                table: "Survey",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "d83f001b-19f7-4f93-bee1-b612d60f9aad");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "c6de2fcc-9c21-437b-a563-a58911519c1d");

            migrationBuilder.UpdateData(
                table: "Survey",
                keyColumn: "ID",
                keyValue: "001",
                column: "SerialNumber",
                value: "d968244e-9e15-4b74-96a6-4e195839f801");
        }
    }
}
