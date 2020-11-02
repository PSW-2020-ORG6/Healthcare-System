using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Feedbakcs",
                columns: new[] { "Id", "Approved", "Name", "Text" },
                values: new object[] { "6", true, "Ime6", "tekst komentara6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbakcs",
                keyColumn: "Id",
                keyValue: "6");
        }
    }
}
