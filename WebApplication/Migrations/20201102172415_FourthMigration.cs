using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Feedbakcs",
                columns: new[] { "Id", "Approved", "Name", "Text" },
                values: new object[] { "5", false, "Ime5", "tekst komentara5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbakcs",
                keyColumn: "Id",
                keyValue: "5");
        }
    }
}
