using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Feedbakcs",
                columns: new[] { "Id", "Approved", "Name", "Text" },
                values: new object[] { "4", false, "Ime4", "tekst komentara4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbakcs",
                keyColumn: "Id",
                keyValue: "4");
        }
    }
}
