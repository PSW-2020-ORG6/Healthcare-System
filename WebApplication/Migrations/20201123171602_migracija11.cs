using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class migracija11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "SerialNumber",
                keyValue: "9918e6d2-b9b4-48e5-948e-a67a58e9873c");

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "SerialNumber",
                keyValue: "b051bcd1-8f03-4dfc-abf6-d6eda4548dfd");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0002",
                column: "SerialNumber",
                value: "80be9ef9-3da3-4c3d-8bca-bbf7bae20fd8");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "0003",
                column: "SerialNumber",
                value: "81d4bb96-81b4-43b6-8e54-165081e4029e");

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "SerialNumber", "Findings", "PatientConditions", "PatientId", "PatientName", "PhysitianName" },
                values: new object[,]
                {
                    { "9d815b54-bdee-4117-9be7-e339bce42f8c", null, null, "0002", "Mika Mikic", "Pera Peric" },
                    { "03744665-b437-4a09-86fc-81cd3bdaaad9", null, null, "0002", "Mika Mikic", "Nikola Nikolic" },
                    { "8120ac60-d2d7-4413-87bd-a641b580c41e", null, null, "0002", "Mika Mikic", "Bole Bolevic" },
                    { "9edc0d3e-4794-4f97-9e93-e5b266b037f8", null, null, "0003", "Ana Anic", "Petar Petovic" },
                    { "16f6237b-e66d-45e1-9e35-031e78925ba9", null, null, "0003", "Ana Anic", "Bole Bolevic" }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SerialNumber", "DoctorName", "ID", "Question1", "Question10", "Question11", "Question12", "Question13", "Question14", "Question15", "Question16", "Question17", "Question18", "Question19", "Question2", "Question20", "Question21", "Question22", "Question23", "Question3", "Question4", "Question5", "Question6", "Question7", "Question8", "Question9" },
                values: new object[,]
                {
                    { "58ce9630-e321-4d82-823e-e4d8a4fe9229", "Pera Peric", "001", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" },
                    { "017e28e1-877d-4591-98ad-3c835dd9352c", "Mika Mikic", "005", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "03744665-b437-4a09-86fc-81cd3bdaaad9");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "16f6237b-e66d-45e1-9e35-031e78925ba9");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "8120ac60-d2d7-4413-87bd-a641b580c41e");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "9d815b54-bdee-4117-9be7-e339bce42f8c");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "SerialNumber",
                keyValue: "9edc0d3e-4794-4f97-9e93-e5b266b037f8");

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "SerialNumber",
                keyValue: "017e28e1-877d-4591-98ad-3c835dd9352c");

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "SerialNumber",
                keyValue: "58ce9630-e321-4d82-823e-e4d8a4fe9229");

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
    }
}
