using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

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
                values: new object[] { "1", true, "Ime1", "tekst komentara1" });

            migrationBuilder.InsertData(
                table: "Feedbakcs",
                columns: new[] { "Id", "Approved", "Name", "Text" },
                values: new object[] { "2", false, "Ime2", "tekst komentara2" });

            migrationBuilder.InsertData(
                table: "Feedbakcs",
                columns: new[] { "Id", "Approved", "Name", "Text" },
                values: new object[] { "3", true, "Ime3", "tekst komentara3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbakcs");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Color = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Price = table.Column<double>(type: "double", nullable: false),
                    ProductCategoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Clothes" },
                    { 2L, "Footwear" },
                    { 3L, "Food" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "Name", "Price", "ProductCategoryId" },
                values: new object[,]
                {
                    { 1L, 1L, "black", "Jacket", 40.299999999999997, null },
                    { 2L, 2L, "blue", "Shoes", 52.200000000000003, null },
                    { 3L, 1L, "white", "T-shirt", 4.0, null },
                    { 4L, 3L, "white", "Bread", 0.5, null },
                    { 5L, 2L, "brown", "Boots", 88.799999999999997, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
        }
    }
}
