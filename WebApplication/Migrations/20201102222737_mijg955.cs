using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class mijg955 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbakcs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbakcs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Feedbakcs",
                columns: new[] { "Id", "Approved", "Name", "Text" },
                values: new object[,]
                {
                    { "1", true, "Ime1", "tekst komentara1" },
                    { "2", false, "Ime2", "tekst komentara2" },
                    { "3", true, "Ime3", "tekst komentara3" },
                    { "4", false, "Ime4", "tekst komentara4" },
                    { "5", false, "Ime5", "tekst komentara5" },
                    { "6", true, "Ime6", "tekst komentara6" },
                    { "7", false, "Ime5", "tekst komentara5" },
                    { "8", false, "Ime5", "tekst komentara5" },
                    { "9", false, "Ime5", "tekst komentara5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbakcs");
        }
    }
}
