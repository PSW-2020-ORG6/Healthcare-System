using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class ssdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    PatientName = table.Column<string>(nullable: true),
                    PhysitianName = table.Column<string>(nullable: true),
                    PatientId = table.Column<string>(nullable: true),
                    Findings = table.Column<string>(nullable: true),
                    PatientConditions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
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
                    table.PrimaryKey("PK_Surveys", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Contact", "DateOfBirth", "Email", "Gender", "Guest", "Name", "ParentName", "Password", "SerialNumber", "Surname" },
                values: new object[,]
                {
                    { "0002", "kontakt", new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "email", "Zensko", true, "Jelena", "otac", null, "0e3f7e4a-d6d5-4a82-b926-f52b4e61d12d", "Tanjic" },
                    { "0003", "kontaktMica", new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailMica", "Zensko", true, "Sara", "mama", null, "be4976fa-634b-4878-bec2-c33dcc7b9696", "Milic" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "QuestionText" },
                values: new object[,]
                {
                    { 23, ">Would you recommend this facility to your friends and family" },
                    { 22, "Would you come to this institution again" },
                    { 21, "Overall, are you satisfied with the care you received in this facility?" },
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
                    { 8, "The nurse gave you good discharge instructions" },
                    { 7, "Orientation given to warn setup" },
                    { 6, "The nursees answered all of your questions in an understandable manner?" },
                    { 5, "The personal manner(courtosy,respect,sensitivity,friendliness) of the nurses and other support staff?" },
                    { 4, "Would you have the procedure done again by this doctor?" },
                    { 3, "The doctor takes care of you in a professional manner?" },
                    { 2, "The doctor answered all of your questions in an understandable manner?" },
                    { 1, "The doctor is welcoming and gentle?" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "SerialNumber", "Findings", "PatientConditions", "PatientId", "PatientName", "PhysitianName" },
                values: new object[,]
                {
                    { "4838da26-ec30-4689-b158-c262af085467", null, null, "0003", "Ana Anic", "Bole Bolevic" },
                    { "bbc69589-4290-4b28-b237-c5fa93679bd1", null, null, "0003", "Ana Anic", "Petar Petovic" },
                    { "12b03d11-c920-4bef-9be2-ed9e0826c8fd", null, null, "0002", "Mika Mikic", "Bole Bolevic" },
                    { "c1f6087a-f996-4c8a-b04d-1c8b02b2d36d", null, null, "0002", "Mika Mikic", "Nikola Nikolic" },
                    { "04539c87-57f7-4f71-8b56-711c56d8522f", null, null, "0002", "Mika Mikic", "Pera Peric" }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "ID", "DoctorName", "Question1", "Question10", "Question11", "Question12", "Question13", "Question14", "Question15", "Question16", "Question17", "Question18", "Question19", "Question2", "Question20", "Question21", "Question22", "Question23", "Question3", "Question4", "Question5", "Question6", "Question7", "Question8", "Question9" },
                values: new object[,]
                {
                    { "001", "Pera Peric", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" },
                    { "005", "Mika Mikic", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
