using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class Report : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientSerialNumber",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysitianSerialNumber",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcedureTypeSerialNumber",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Guest",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_PatientSerialNumber",
                table: "Reports",
                column: "PatientSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_PhysitianSerialNumber",
                table: "Reports",
                column: "PhysitianSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ProcedureTypeSerialNumber",
                table: "Reports",
                column: "ProcedureTypeSerialNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Accounts_PatientSerialNumber",
                table: "Reports",
                column: "PatientSerialNumber",
                principalTable: "Accounts",
                principalColumn: "SerialNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Accounts_PhysitianSerialNumber",
                table: "Reports",
                column: "PhysitianSerialNumber",
                principalTable: "Accounts",
                principalColumn: "SerialNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ProcedureTypes_ProcedureTypeSerialNumber",
                table: "Reports",
                column: "ProcedureTypeSerialNumber",
                principalTable: "ProcedureTypes",
                principalColumn: "SerialNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Accounts_PatientSerialNumber",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Accounts_PhysitianSerialNumber",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ProcedureTypes_ProcedureTypeSerialNumber",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_PatientSerialNumber",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_PhysitianSerialNumber",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ProcedureTypeSerialNumber",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PatientSerialNumber",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PhysitianSerialNumber",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ProcedureTypeSerialNumber",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Guest",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Accounts");
        }
    }
}
