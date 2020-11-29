using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RoomId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Approved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BuildingName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.SerialNumber);
                });

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

            migrationBuilder.CreateTable(
                name: "MedicineManufacturers",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineManufacturers", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTypes",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTypes", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Guest = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FloorName = table.Column<string>(nullable: true),
                    BuildingName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    CopyrightName = table.Column<string>(nullable: true),
                    GenericName = table.Column<string>(nullable: true),
                    MedicineManufacturerSerialNumber = table.Column<string>(nullable: true),
                    MedicineTypeSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Medicine_MedicineManufacturers_MedicineManufacturerSerialNum~",
                        column: x => x.MedicineManufacturerSerialNumber,
                        principalTable: "MedicineManufacturers",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicine_MedicineTypes_MedicineTypeSerialNumber",
                        column: x => x.MedicineTypeSerialNumber,
                        principalTable: "MedicineTypes",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "SerialNumber", "Color", "Name", "Shape" },
                values: new object[,]
                {
                    { "10002", "Dark Orange", "Orthopedy", "Square" },
                    { "10001", "Orange", "Cardiology", "Square" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Name", "RoomId", "SerialNumber" },
                values: new object[,]
                {
                    { "19", "Bed", "112", "81" },
                    { "11", "Bed", "101", "73" },
                    { "12", "Bed", "102", "74" },
                    { "13", "Bed", "103", "75" },
                    { "14", "Bed", "101", "76" },
                    { "15", "Bed", "102", "77" },
                    { "16", "Table", "104", "78" },
                    { "17", "Table", "111", "79" },
                    { "18", "Table", "111", "80" },
                    { "20", "Bed", "112", "82" }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "SerialNumber", "BuildingName", "Name" },
                values: new object[,]
                {
                    { "1001", "Cardiology", "Floor1" },
                    { "1002", "Cardiology", "Floor2" },
                    { "1003", "Orthopedy", "Floor1" }
                });

            migrationBuilder.InsertData(
                table: "MedicineGEA",
                columns: new[] { "SerialNumber", "CopyrightName", "GenericName", "MedicineManufacturerId", "MedicineTypeId" },
                values: new object[,]
                {
                    { "22", "Probiotic", "Probiotic", "2", "12" },
                    { "21", "Brufen", "Brufen", "1", "11" }
                });

            migrationBuilder.InsertData(
                table: "MedicineManufacturers",
                columns: new[] { "SerialNumber", "Name" },
                values: new object[,]
                {
                    { "2", "manufacturer2" },
                    { "1", "manufacturer1" }
                });

            migrationBuilder.InsertData(
                table: "MedicineTypes",
                columns: new[] { "SerialNumber", "Type" },
                values: new object[,]
                {
                    { "11", "Antibiotic" },
                    { "12", "Brufen" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Contact", "DateOfBirth", "Email", "Gender", "Guest", "Name", "ParentName", "Password", "SerialNumber", "Surname" },
                values: new object[,]
                {
                    { "0002", "kontakt", new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "email", "Zensko", true, "Jelena", "otac", null, "ed81c00f-889e-4653-9fbe-8c422ff1998b", "Tanjic" },
                    { "0003", "kontaktMica", new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailMica", "Zensko", true, "Sara", "mama", null, "d9320de2-28b6-4246-bbc2-a3847c5a6d87", "Milic" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "SerialNumber", "BuildingName", "FloorName", "Name" },
                values: new object[,]
                {
                    { "101", "Cardiology", "Floor 1", "Examination room" },
                    { "102", "Cardiology", "Floor 1", "Examination room" },
                    { "103", "Cardiology", "Floor 1", "Store room" },
                    { "104", "Cardiology", "Floor 1", "Examination room" },
                    { "105", "Cardiology", "Floor 1", "Store room" },
                    { "106", "Cardiology", "Floor 2", "Operation room" },
                    { "107", "Cardiology", "Floor 2", "Operation room" },
                    { "108", "Cardiology", "Floor 2", "Store room" },
                    { "109", "Orthopedy", "Floor 1", "Examination room" },
                    { "110", "Orthopedy", "Floor 1", "Operation room" },
                    { "111", "Orthopedy", "Floor 1", "Examination room" },
                    { "112", "Orthopedy", "Floor 1", "Store room" },
                    { "113", "Orthopedy", "Floor 1", "Examination room" },
                    { "114", "Orthopedy", "Floor 1", "Examination room" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_MedicineManufacturerSerialNumber",
                table: "Medicine",
                column: "MedicineManufacturerSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_MedicineTypeSerialNumber",
                table: "Medicine",
                column: "MedicineTypeSerialNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "MedicineGEA");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "MedicineManufacturers");

            migrationBuilder.DropTable(
                name: "MedicineTypes");
        }
    }
}
