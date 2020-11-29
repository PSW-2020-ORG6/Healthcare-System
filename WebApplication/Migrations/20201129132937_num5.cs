using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class num5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineGEA",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    CopyrightName = table.Column<string>(nullable: true),
                    GenericName = table.Column<string>(nullable: true),
                    MedicineManufacturerId = table.Column<string>(nullable: true),
                    MedicineTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineGEA", x => x.SerialNumber);
                });

            migrationBuilder.InsertData(
                table: "MedicineGEA",
                columns: new[] { "SerialNumber", "CopyrightName", "GenericName", "MedicineManufacturerId", "MedicineTypeId" },
                values: new object[,]
                {
                    { "21", "Brufen", "Brufen", "1", "11" },
                    { "22", "Probiotic", "Probiotic", "2", "12" }
                });

            migrationBuilder.InsertData(
                table: "MedicineManufacturers",
                columns: new[] { "SerialNumber", "Name" },
                values: new object[,]
                {
                    { "1", "manufacturer1" },
                    { "2", "manufacturer2" }
                });

            migrationBuilder.InsertData(
                table: "MedicineTypes",
                columns: new[] { "SerialNumber", "Type" },
                values: new object[,]
                {
                    { "11", "Antibiotic" },
                    { "12", "Brufen" }
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "41c3c395-27a1-40cb-b96c-5de59e35ce48");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "8ccb083c-493f-4cbc-bf88-aa78e6b2eb54");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineGEA");

            migrationBuilder.DeleteData(
                table: "MedicineManufacturers",
                keyColumn: "SerialNumber",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "MedicineManufacturers",
                keyColumn: "SerialNumber",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "MedicineTypes",
                keyColumn: "SerialNumber",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "MedicineTypes",
                keyColumn: "SerialNumber",
                keyValue: "12");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "9d077b3f-0b41-448d-8c00-d30058d49cf0");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "56f67aca-c2b2-4a9e-8cf4-a66cd31282c8");
        }
    }
}
