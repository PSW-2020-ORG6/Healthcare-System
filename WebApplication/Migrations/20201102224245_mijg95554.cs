using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class mijg95554 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbakcs",
                table: "Feedbakcs");

            migrationBuilder.RenameTable(
                name: "Feedbakcs",
                newName: "Feedbacks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Approved", "Name", "Text" },
                values: new object[] { "11", false, "Ime5", "tekst komentara5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: "11");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "Feedbakcs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbakcs",
                table: "Feedbakcs",
                column: "Id");
        }
    }
}
