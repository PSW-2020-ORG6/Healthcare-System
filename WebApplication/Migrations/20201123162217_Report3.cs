using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class Report3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecializationSerialNumber",
                table: "ProcedureTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureTypes_SpecializationSerialNumber",
                table: "ProcedureTypes",
                column: "SpecializationSerialNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureTypes_Specializations_SpecializationSerialNumber",
                table: "ProcedureTypes",
                column: "SpecializationSerialNumber",
                principalTable: "Specializations",
                principalColumn: "SerialNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureTypes_Specializations_SpecializationSerialNumber",
                table: "ProcedureTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProcedureTypes_SpecializationSerialNumber",
                table: "ProcedureTypes");

            migrationBuilder.DropColumn(
                name: "SpecializationSerialNumber",
                table: "ProcedureTypes");
        }
    }
}
