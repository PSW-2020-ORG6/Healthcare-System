using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class migracija10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "04539c87-57f7-4f71-8b56-711c56d8522f");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "12b03d11-c920-4bef-9be2-ed9e0826c8fd");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "4838da26-ec30-4689-b158-c262af085467");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "bbc69589-4290-4b28-b237-c5fa93679bd1");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "c1f6087a-f996-4c8a-b04d-1c8b02b2d36d");

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "ID",
                keyValue: "001");

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "ID",
                keyValue: "005");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Surveys",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Surveys",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys",
                column: "SerialNumber");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "e1646f09-3a92-443f-88c4-099e49c849d8");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "ccd5d784-45bc-47ea-aa5a-0acf2e5f68aa");

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "SerialNumber", "Findings", "PatientConditions", "PatientId", "PatientName", "PhysitianName" },
                values: new object[,]
                {
                    { "ce76b5fc-6cbe-4e45-ab37-173a964cc39b", null, null, "0002", "Mika Mikic", "Pera Peric" },
                    { "032e21b0-b12e-49f5-a5d1-f3167a171d0d", null, null, "0002", "Mika Mikic", "Nikola Nikolic" },
                    { "55ee62a0-227c-4f0f-b6d2-d127ebb8ce1f", null, null, "0002", "Mika Mikic", "Bole Bolevic" },
                    { "73baa9f4-7ba7-4d91-9296-1342d3327a37", null, null, "0003", "Ana Anic", "Petar Petovic" },
                    { "509b7c29-23ce-41de-bb2c-f452ca7192da", null, null, "0003", "Ana Anic", "Bole Bolevic" }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SerialNumber", "DoctorName", "ID", "Question1", "Question10", "Question11", "Question12", "Question13", "Question14", "Question15", "Question16", "Question17", "Question18", "Question19", "Question2", "Question20", "Question21", "Question22", "Question23", "Question3", "Question4", "Question5", "Question6", "Question7", "Question8", "Question9" },
                values: new object[,]
                {
                    { "9918e6d2-b9b4-48e5-948e-a67a58e9873c", "Pera Peric", "001", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" },
                    { "b051bcd1-8f03-4dfc-abf6-d6eda4548dfd", "Mika Mikic", "005", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "032e21b0-b12e-49f5-a5d1-f3167a171d0d");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "509b7c29-23ce-41de-bb2c-f452ca7192da");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "55ee62a0-227c-4f0f-b6d2-d127ebb8ce1f");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "73baa9f4-7ba7-4d91-9296-1342d3327a37");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "ce76b5fc-6cbe-4e45-ab37-173a964cc39b");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Surveys");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Surveys",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "0e3f7e4a-d6d5-4a82-b926-f52b4e61d12d");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "be4976fa-634b-4878-bec2-c33dcc7b9696");

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "SerialNumber", "Findings", "PatientConditions", "PatientId", "PatientName", "PhysitianName" },
                values: new object[,]
                {
                    { "04539c87-57f7-4f71-8b56-711c56d8522f", null, null, "0002", "Mika Mikic", "Pera Peric" },
                    { "c1f6087a-f996-4c8a-b04d-1c8b02b2d36d", null, null, "0002", "Mika Mikic", "Nikola Nikolic" },
                    { "12b03d11-c920-4bef-9be2-ed9e0826c8fd", null, null, "0002", "Mika Mikic", "Bole Bolevic" },
                    { "bbc69589-4290-4b28-b237-c5fa93679bd1", null, null, "0003", "Ana Anic", "Petar Petovic" },
                    { "4838da26-ec30-4689-b158-c262af085467", null, null, "0003", "Ana Anic", "Bole Bolevic" }
                });
        }
    }
}
