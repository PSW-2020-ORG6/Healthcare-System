using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class migracija117 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Address_AddressSerialNumber",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AddressSerialNumber",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "SerialNumber",
                keyValue: "460ac1fb-418e-4591-8da8-1ee0ea94525c");

            migrationBuilder.DropColumn(
                name: "AddressSerialNumber",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Patients_Id",
                table: "Patients",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "SerialNumber", "Contact", "DateOfBirth", "Email", "Gender", "Guest", "Id", "Name", "ParentName", "Password", "Surname" },
                values: new object[] { "3a99838f-25dd-436e-a1c1-7e4d14f41fb8", "kontakt", new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "email", "Zensko", true, "0001", "Tanja", "otac", "sifra", "Tanjic" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Patients_Id",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "SerialNumber",
                keyValue: "3a99838f-25dd-436e-a1c1-7e4d14f41fb8");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Patients",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "AddressSerialNumber",
                table: "Patients",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Street = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.SerialNumber);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "SerialNumber", "AddressSerialNumber", "Contact", "DateOfBirth", "Email", "Gender", "Guest", "Id", "Name", "ParentName", "Password", "Surname" },
                values: new object[] { "460ac1fb-418e-4591-8da8-1ee0ea94525c", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Ime1", "Tanja", null, null, "Tanjic" });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressSerialNumber",
                table: "Patients",
                column: "AddressSerialNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Address_AddressSerialNumber",
                table: "Patients",
                column: "AddressSerialNumber",
                principalTable: "Address",
                principalColumn: "SerialNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
