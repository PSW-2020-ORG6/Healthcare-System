using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class Report2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Specializations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProcedureTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Specializations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProcedureTypes");
        }
    }
}
