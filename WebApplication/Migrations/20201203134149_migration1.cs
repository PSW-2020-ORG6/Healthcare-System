using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Urgency = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Row = table.Column<int>(nullable: false),
                    Column = table.Column<int>(nullable: false),
                    Style = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RoomId = table.Column<string>(nullable: true),
                    BuildingSerialNumber = table.Column<string>(nullable: true),
                    FloorSerialNumber = table.Column<string>(nullable: true),
                    RoomSerialNumber = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PatientID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
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
                    table.PrimaryKey("PK_Feedback", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BuildingSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.SerialNumber);
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
                });

            migrationBuilder.CreateTable(
                name: "MedicineManufacturer",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineManufacturer", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "MedicineType",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineType", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AddressSerialNumber = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    MunicipalityOfBirth = table.Column<string>(nullable: true),
                    StateOfBirth = table.Column<string>(nullable: true),
                    PlaceOfResidence = table.Column<string>(nullable: true),
                    MunicipalityOfResidence = table.Column<string>(nullable: true),
                    StateOfResidence = table.Column<string>(nullable: true),
                    Citizenship = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true),
                    EmploymentStatus = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    HealthInsuranceNumber = table.Column<string>(nullable: true),
                    FamilyDiseases = table.Column<string>(nullable: true),
                    PersonalDiseases = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Guest = table.Column<bool>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    ChosenDoctor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Physitian",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AddressSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Physitian", x => x.SerialNumber);
                    table.UniqueConstraint("AK_Physitian_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureType",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EstimatedTimeInMinutes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureType", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureTypeEquipmentUsage",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    ProcedureTypeSerialNumber = table.Column<string>(nullable: true),
                    EquipmentSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureTypeEquipmentUsage", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false),
                    FloorSerialNumber = table.Column<string>(nullable: true),
                    BuildingSerialNumber = table.Column<string>(nullable: true),
                    RoomTypeSerialNumber = table.Column<string>(nullable: true),
                    Row = table.Column<int>(nullable: false),
                    Column = table.Column<int>(nullable: false),
                    RowSpan = table.Column<int>(nullable: false),
                    ColumnSpan = table.Column<int>(nullable: false),
                    Style = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    ID = table.Column<string>(nullable: true),
                    DoctorName = table.Column<string>(nullable: true),
                    Question1 = table.Column<string>(nullable: true),
                    Question2 = table.Column<string>(nullable: true),
                    Question3 = table.Column<string>(nullable: true),
                    Question4 = table.Column<string>(nullable: true),
                    Question5 = table.Column<string>(nullable: true),
                    Question6 = table.Column<string>(nullable: true),
                    Question7 = table.Column<string>(nullable: true),
                    Question8 = table.Column<string>(nullable: true),
                    Question9 = table.Column<string>(nullable: true),
                    Question10 = table.Column<string>(nullable: true),
                    Question11 = table.Column<string>(nullable: true),
                    Question12 = table.Column<string>(nullable: true),
                    Question13 = table.Column<string>(nullable: true),
                    Question14 = table.Column<string>(nullable: true),
                    Question15 = table.Column<string>(nullable: true),
                    Question16 = table.Column<string>(nullable: true),
                    Question17 = table.Column<string>(nullable: true),
                    Question18 = table.Column<string>(nullable: true),
                    Question19 = table.Column<string>(nullable: true),
                    Question20 = table.Column<string>(nullable: true),
                    Question22 = table.Column<string>(nullable: true),
                    Question21 = table.Column<string>(nullable: true),
                    Question23 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "TimeInterval",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeInterval", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Findings = table.Column<string>(nullable: true),
                    PatientId = table.Column<string>(nullable: true),
                    PhysitianSerialNumber = table.Column<string>(nullable: true),
                    PatientConditions = table.Column<string>(nullable: true),
                    ProcedureTypeSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Report_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_Physitian_PhysitianSerialNumber",
                        column: x => x.PhysitianSerialNumber,
                        principalTable: "Physitian",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_ProcedureType_ProcedureTypeSerialNumber",
                        column: x => x.ProcedureTypeSerialNumber,
                        principalTable: "ProcedureType",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "SerialNumber", "Street" },
                values: new object[,]
                {
                    { "200001", "Njegoševa 45" },
                    { "200002", "Njegoševa 46" }
                });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "SerialNumber", "Urgency" },
                values: new object[,]
                {
                    { "200001", true },
                    { "200002", false }
                });

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "SerialNumber", "Color", "Column", "Name", "Row", "Style" },
                values: new object[,]
                {
                    { "10001", "Orange", 1, "Cardiology", 5, "TriangleBuildingButtonStyle" },
                    { "10002", "Red", 3, "Orthopedy", 5, "UBuildingButtonStyle" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BuildingSerialNumber", "Discriminator", "FloorSerialNumber", "Name", "RoomId", "RoomSerialNumber", "SerialNumber" },
                values: new object[,]
                {
                    { "17", "10001", "Equipment", "1002", "Table", "111", "107", "79" },
                    { "20", "10002", "Equipment", "1003", "Bed", "112", "114", "82" },
                    { "19", "10002", "Equipment", "1003", "Bed", "112", "114", "81" },
                    { "18", "10001", "Equipment", "1002", "Table", "111", "107", "80" },
                    { "16", "10001", "Equipment", "1002", "Table", "104", "106", "78" },
                    { "15", "10001", "Equipment", "1002", "Bed", "102", "106", "77" },
                    { "14", "10001", "Equipment", "1001", "Bed", "101", "101", "76" },
                    { "13", "10001", "Equipment", "1001", "Bed", "103", "101", "75" },
                    { "12", "10001", "Equipment", "1001", "Bed", "102", "101", "74" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BuildingSerialNumber", "Discriminator", "FloorSerialNumber", "Name", "RoomId", "RoomSerialNumber", "SerialNumber", "PatientID" },
                values: new object[] { "100003", "10001", "Bed", "1001", "Bed 3", "103", "102", "100003", null });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BuildingSerialNumber", "Discriminator", "FloorSerialNumber", "Name", "RoomId", "RoomSerialNumber", "SerialNumber" },
                values: new object[] { "11", "10001", "Equipment", "1001", "Bed", "101", "101", "73" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BuildingSerialNumber", "Discriminator", "FloorSerialNumber", "Name", "RoomId", "RoomSerialNumber", "SerialNumber", "PatientID" },
                values: new object[,]
                {
                    { "100001", "10001", "Bed", "1001", "Bed 1", "101", "101", "100001", "0002" },
                    { "100002", "10001", "Bed", "1001", "Bed 2", "102", "101", "100002", "0003" }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "SerialNumber", "Approved", "Date", "PatientId", "Text" },
                values: new object[,]
                {
                    { "aeded527-e03c-4acd-afa4-45fcdcb89075", true, new DateTime(2016, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0001", "super" },
                    { "c9b789d3-d6c8-4459-96e7-d83c568337a1", false, new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0004", "ok" },
                    { "183a520e-d712-4f75-9ec3-49bdafd2d395", true, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "00010", "usluga na nivou" },
                    { "80e9cf29-70b5-49fe-9e2c-c545d6c74e7b", false, new DateTime(2019, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "0008", "sve pohvale" },
                    { "ef956514-d2c7-4d69-8119-392a9aa70b7d", true, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0007", "nikako" },
                    { "d01c84ba-bc44-4a02-a165-dae638f67456", false, new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0003", "dobro" },
                    { "af850575-8fe4-42f0-9cc4-1ab08e5fccf2", true, new DateTime(2018, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "0002", "moze bolje" },
                    { "0a437aa3-d467-473e-8216-64f3eb4683ee", false, new DateTime(2015, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0001", "onako" }
                });

            migrationBuilder.InsertData(
                table: "Floor",
                columns: new[] { "SerialNumber", "BuildingSerialNumber", "Name" },
                values: new object[,]
                {
                    { "1003", "10002", "Floor1" },
                    { "1002", "10001", "Floor2" },
                    { "1001", "10001", "Floor1" }
                });

            migrationBuilder.InsertData(
                table: "Medicine",
                columns: new[] { "SerialNumber", "CopyrightName", "GenericName", "MedicineManufacturerSerialNumber", "MedicineTypeSerialNumber" },
                values: new object[,]
                {
                    { "21", "Brufen", "Brufen", "1", "11" },
                    { "22", "Probiotic", "Probiotic", "2", "12" }
                });

            migrationBuilder.InsertData(
                table: "MedicineManufacturer",
                columns: new[] { "SerialNumber", "Name" },
                values: new object[,]
                {
                    { "1", "manufacturer1" },
                    { "2", "manufacturer2" }
                });

            migrationBuilder.InsertData(
                table: "MedicineType",
                columns: new[] { "SerialNumber", "Type" },
                values: new object[,]
                {
                    { "11", "Antibiotic" },
                    { "12", "Brufen" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "AddressSerialNumber", "ChosenDoctor", "Citizenship", "Contact", "DateOfBirth", "Email", "EmailConfirmed", "EmploymentStatus", "FamilyDiseases", "FullName", "Gender", "Guest", "HealthInsuranceNumber", "Image", "MaritalStatus", "MunicipalityOfBirth", "MunicipalityOfResidence", "Name", "Nationality", "ParentName", "Password", "PersonalDiseases", "PlaceOfBirth", "PlaceOfResidence", "Profession", "SerialNumber", "StateOfBirth", "StateOfResidence", "Surname" },
                values: new object[,]
                {
                    { "0002", null, "Gojko Simic", null, "kontakt", new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "email", false, null, null, "Jelena Tanjic", "Zensko", true, null, null, null, null, null, "Jelena", null, "otac", "sifra", null, null, null, null, "96736fd7-3018-4f3f-a14b-35610a1c8959", null, null, "Tanjic" },
                    { "0003", null, "Gojko Simic", null, "kontaktMica", new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailMica", false, null, null, "Sara Milic", "Zensko", true, null, null, null, null, null, "Sara", null, "mama", "sifraMica", null, null, null, null, "b7e5f8f4-8612-4bf0-93b0-68ef5accf24d", null, null, "Milic" }
                });

            migrationBuilder.InsertData(
                table: "Physitian",
                columns: new[] { "SerialNumber", "AddressSerialNumber", "Contact", "DateOfBirth", "Email", "FullName", "Id", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { "600002", "200002", "Dicic kontakt", new DateTime(1985, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "dicic@gmail.com", "Klara Dicic", "600002", "Klara", "sifraDicic98754", "Dicic" },
                    { "600001", "200001", "Simic kontakt", new DateTime(1975, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "simic@gmail.com", "Gojko Simic", "600001", "Gojko", "sifraSimic24dsf1", "Simic" }
                });

            migrationBuilder.InsertData(
                table: "ProcedureType",
                columns: new[] { "SerialNumber", "EstimatedTimeInMinutes", "Name" },
                values: new object[,]
                {
                    { "300002", 78, "Check on patient 0002" },
                    { "300001", 50, "Operation on patient 0002" }
                });

            migrationBuilder.InsertData(
                table: "ProcedureTypeEquipmentUsage",
                columns: new[] { "SerialNumber", "EquipmentSerialNumber", "ProcedureTypeSerialNumber" },
                values: new object[,]
                {
                    { "400001", "81", "300001" },
                    { "400002", "82", "300002" }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "QuestionText" },
                values: new object[,]
                {
                    { 3, "The doctor takes care of you in a professional manner?" },
                    { 4, "Would you have the procedure done again by this doctor?" },
                    { 5, "The personal manner(courtosy,respect,sensitivity,friendliness) of the nurses and other support staff?" },
                    { 6, "The nursees answered all of your questions in an understandable manner?" },
                    { 21, "Overall, are you satisfied with the care you received in this facility?" },
                    { 8, "The nurse gave you good discharge instructions" },
                    { 23, ">Would you recommend this facility to your friends and family" },
                    { 22, "Would you come to this institution again" },
                    { 1, "The doctor is welcoming and gentle?" },
                    { 20, "Did you have found all the necessary information on our website?" },
                    { 19, "Did you found it easy to use our website?" },
                    { 18, "The doctor prescribed medications that I could buy at the clinic's pharmacy" },
                    { 17, "Did you noticed broken or damaged equipment in the hospital" },
                    { 16, "Do you think that the hospital should have more modern equipment than the current one" },
                    { 15, "Do you think the clinic's farmacy has the necessary drugs?" },
                    { 14, "Do you think the clinic has the necessary equipment" },
                    { 13, "General impression of the ambient atmosphere" },
                    { 12, "Conditions of the rooms(temperature,comfort,silence)" },
                    { 11, "Comfort level within the procedure room?" },
                    { 10, "The comfort and cleanliness of the facility" },
                    { 9, "The nurse was concern for you?" },
                    { 7, "Orientation given to warn setup" },
                    { 2, "The doctor answered all of your questions in an understandable manner?" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "SerialNumber", "BuildingSerialNumber", "Column", "ColumnSpan", "FloorSerialNumber", "Id", "Name", "RoomTypeSerialNumber", "Row", "RowSpan", "Style" },
                values: new object[,]
                {
                    { "112", "10002", 0, 0, "1003", 112, "Store room 112", "10000002", 0, 0, "RoomButtonStyle" },
                    { "108", "10001", 10, 3, "1002", 108, "Store room 108", "10000002", 0, 2, "RoomButtonStyle" },
                    { "103", "10001", 5, 3, "1001", 103, "Store room 103", "10000002", 0, 2, "RoomButtonStyle" },
                    { "104", "10001", 14, 5, "1001", 104, "Examination room 104", "10000003", 0, 3, "RoomButtonStyle" },
                    { "105", "10001", 9, 5, "1001", 105, "Store room 105", "10000002", 10, 2, "RoomButtonStyle" },
                    { "106", "10001", 0, 7, "1002", 106, "Operation room 106", "10000001", 0, 4, "RoomButtonStyle" },
                    { "107", "10001", 0, 7, "1002", 107, "Operation room 107", "10000001", 8, 4, "RoomButtonStyle" },
                    { "109", "10002", 0, 0, "1003", 109, "Examination room 109", "10000003", 0, 0, "RoomButtonStyle" },
                    { "102", "10001", 10, 4, "1001", 102, "Examination room 102", "10000003", 0, 2, "RoomButtonStyle" },
                    { "110", "10002", 0, 0, "1003", 110, "Operation room 110", "10000001", 0, 0, "RoomButtonStyle" },
                    { "113", "10002", 0, 0, "1003", 113, "Examination room 113", "10000003", 0, 0, "RoomButtonStyle" },
                    { "114", "10002", 0, 0, "1003", 114, "Examination room 114", "10000003", 0, 0, "RoomButtonStyle" },
                    { "111", "10002", 0, 0, "1003", 111, "Examination room 111", "10000003", 0, 0, "RoomButtonStyle" },
                    { "101", "10001", 0, 5, "1001", 101, "Examination room 101", "10000003", 0, 3, "RoomButtonStyle" }
                });

            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "SerialNumber", "Name" },
                values: new object[,]
                {
                    { "10000001", "Operation room" },
                    { "10000002", "Store room" },
                    { "10000003", "Examination room" }
                });

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "SerialNumber", "Name" },
                values: new object[,]
                {
                    { "500001", "Neurosurgeon " },
                    { "500002", "Family doctor" }
                });

            migrationBuilder.InsertData(
                table: "Survey",
                columns: new[] { "SerialNumber", "DoctorName", "ID", "Question1", "Question10", "Question11", "Question12", "Question13", "Question14", "Question15", "Question16", "Question17", "Question18", "Question19", "Question2", "Question20", "Question21", "Question22", "Question23", "Question3", "Question4", "Question5", "Question6", "Question7", "Question8", "Question9" },
                values: new object[,]
                {
                    { "fc525c2c-beb5-4ea7-8a47-f5b9c9cbb70e", "Mika Mikic", "005", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" },
                    { "1a3f875c-94bd-490d-a551-dacea8bdf036", "Pera Peric", "001", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" }
                });

            migrationBuilder.InsertData(
                table: "TimeInterval",
                columns: new[] { "Id", "End", "Start" },
                values: new object[,]
                {
                    { "600002", new DateTime(2020, 12, 3, 14, 41, 47, 973, DateTimeKind.Local).AddTicks(7181), new DateTime(2020, 12, 3, 14, 41, 47, 973, DateTimeKind.Local).AddTicks(7159) },
                    { "600001", new DateTime(2020, 12, 3, 14, 41, 47, 973, DateTimeKind.Local).AddTicks(6100), new DateTime(2020, 12, 3, 14, 41, 47, 970, DateTimeKind.Local).AddTicks(7280) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Report_PatientId",
                table: "Report",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_PhysitianSerialNumber",
                table: "Report",
                column: "PhysitianSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ProcedureTypeSerialNumber",
                table: "Report",
                column: "ProcedureTypeSerialNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "MedicineManufacturer");

            migrationBuilder.DropTable(
                name: "MedicineType");

            migrationBuilder.DropTable(
                name: "ProcedureTypeEquipmentUsage");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "RoomType");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "TimeInterval");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Physitian");

            migrationBuilder.DropTable(
                name: "ProcedureType");
        }
    }
}
