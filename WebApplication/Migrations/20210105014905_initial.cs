using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionAndBenefitMessage",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    ActionID = table.Column<Guid>(nullable: false),
                    PharmacyName = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionAndBenefitMessage", x => x.SerialNumber);
                    table.UniqueConstraint("AK_ActionAndBenefitMessage_ActionID", x => x.ActionID);
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
                name: "Country",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosticType",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticType", x => x.SerialNumber);
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
                name: "Prescription",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    QuestionText = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.SerialNumber);
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
                    PatientId = table.Column<string>(nullable: true),
                    DoctorName = table.Column<string>(nullable: true),
                    Questions = table.Column<List<string>>(nullable: true),
                    ReportDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.SerialNumber);
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
                    table.ForeignKey(
                        name: "FK_Floor_Building_BuildingSerialNumber",
                        column: x => x.BuildingSerialNumber,
                        principalTable: "Building",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CountrySerialNumber = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_City_Country_CountrySerialNumber",
                        column: x => x.CountrySerialNumber,
                        principalTable: "Country",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosticReferral",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    DiagnosticTypeSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticReferral", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_DiagnosticReferral_DiagnosticType_DiagnosticTypeSerialNumber",
                        column: x => x.DiagnosticTypeSerialNumber,
                        principalTable: "DiagnosticType",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    CopyrightName = table.Column<string>(nullable: true),
                    GenericName = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    MedicineManufacturerSerialNumber = table.Column<string>(nullable: true),
                    MedicineTypeSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Medicine_MedicineManufacturer_MedicineManufacturerSerialNum~",
                        column: x => x.MedicineManufacturerSerialNumber,
                        principalTable: "MedicineManufacturer",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicine_MedicineType_MedicineTypeSerialNumber",
                        column: x => x.MedicineTypeSerialNumber,
                        principalTable: "MedicineType",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureType",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    SpecializationSerialNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    EstimatedTimeInMinutes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureType", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_ProcedureType_Specialization_SpecializationSerialNumber",
                        column: x => x.SpecializationSerialNumber,
                        principalTable: "Specialization",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_Room_Floor_FloorSerialNumber",
                        column: x => x.FloorSerialNumber,
                        principalTable: "Floor",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_RoomType_RoomTypeSerialNumber",
                        column: x => x.RoomTypeSerialNumber,
                        principalTable: "RoomType",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    CitySerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Address_City_CitySerialNumber",
                        column: x => x.CitySerialNumber,
                        principalTable: "City",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicineDosage",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    MedicineSerialNumber = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    PrescriptionSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDosage", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_MedicineDosage_Medicine_MedicineSerialNumber",
                        column: x => x.MedicineSerialNumber,
                        principalTable: "Medicine",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicineDosage_Prescription_PrescriptionSerialNumber",
                        column: x => x.PrescriptionSerialNumber,
                        principalTable: "Prescription",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rejection",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    MedicineSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rejection", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Rejection_Medicine_MedicineSerialNumber",
                        column: x => x.MedicineSerialNumber,
                        principalTable: "Medicine",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    RoomId = table.Column<string>(nullable: true),
                    BuildingSerialNumber = table.Column<string>(nullable: true),
                    FloorSerialNumber = table.Column<string>(nullable: true),
                    RoomSerialNumber = table.Column<string>(nullable: true),
                    ProcedureTypeSerialNumber = table.Column<string>(nullable: true),
                    RoomSerialNumber2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Equipment_Building_BuildingSerialNumber",
                        column: x => x.BuildingSerialNumber,
                        principalTable: "Building",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Floor_FloorSerialNumber",
                        column: x => x.FloorSerialNumber,
                        principalTable: "Floor",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_ProcedureType_ProcedureTypeSerialNumber",
                        column: x => x.ProcedureTypeSerialNumber,
                        principalTable: "ProcedureType",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Room_RoomSerialNumber",
                        column: x => x.RoomSerialNumber,
                        principalTable: "Room",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Room_RoomSerialNumber2",
                        column: x => x.RoomSerialNumber2,
                        principalTable: "Room",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AddressSerialNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
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
                    IsMalicious = table.Column<bool>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PhysicianSerialNumber = table.Column<string>(nullable: true),
                    ChosenPhysician = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Patient_Address_AddressSerialNumber",
                        column: x => x.AddressSerialNumber,
                        principalTable: "Address",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Physician",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AddressSerialNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    WorkSchedule_Start = table.Column<DateTime>(nullable: true),
                    WorkSchedule_End = table.Column<DateTime>(nullable: true),
                    WorkSchedule_Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Physician", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Physician_Address_AddressSerialNumber",
                        column: x => x.AddressSerialNumber,
                        principalTable: "Address",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Secretary",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AddressSerialNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretary", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Secretary_Address_AddressSerialNumber",
                        column: x => x.AddressSerialNumber,
                        principalTable: "Address",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicineDosage",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PrescriptionSerialNumber = table.Column<string>(nullable: true),
                    MedicineDosageSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedicineDosage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicineDosage_MedicineDosage_MedicineDosageSer~",
                        column: x => x.MedicineDosageSerialNumber,
                        principalTable: "MedicineDosage",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicineDosage_Prescription_PrescriptionSerialN~",
                        column: x => x.PrescriptionSerialNumber,
                        principalTable: "Prescription",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bed",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    RoomId = table.Column<string>(nullable: true),
                    BuildingSerialNumber = table.Column<string>(nullable: true),
                    FloorSerialNumber = table.Column<string>(nullable: true),
                    RoomSerialNumber = table.Column<string>(nullable: true),
                    PatientSerialNumber = table.Column<string>(nullable: true),
                    RoomSerialNumber2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bed", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Bed_Building_BuildingSerialNumber",
                        column: x => x.BuildingSerialNumber,
                        principalTable: "Building",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bed_Floor_FloorSerialNumber",
                        column: x => x.FloorSerialNumber,
                        principalTable: "Floor",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bed_Patient_PatientSerialNumber",
                        column: x => x.PatientSerialNumber,
                        principalTable: "Patient",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bed_Room_RoomSerialNumber",
                        column: x => x.RoomSerialNumber,
                        principalTable: "Room",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bed_Room_RoomSerialNumber2",
                        column: x => x.RoomSerialNumber2,
                        principalTable: "Room",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    RoomSerialNumber = table.Column<string>(nullable: true),
                    PhysicianSerialNumber = table.Column<string>(nullable: true),
                    PatientSerialNumber = table.Column<string>(nullable: true),
                    TimeInterval_Start = table.Column<DateTime>(nullable: true),
                    TimeInterval_End = table.Column<DateTime>(nullable: true),
                    TimeInterval_Id = table.Column<string>(nullable: true),
                    ProcedureTypeSerialnumber = table.Column<string>(nullable: true),
                    Urgency = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    DateOfCanceling = table.Column<string>(nullable: true),
                    IsSurveyDone = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientSerialNumber",
                        column: x => x.PatientSerialNumber,
                        principalTable: "Patient",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Physician_PhysicianSerialNumber",
                        column: x => x.PhysicianSerialNumber,
                        principalTable: "Physician",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_ProcedureType_ProcedureTypeSerialnumber",
                        column: x => x.ProcedureTypeSerialnumber,
                        principalTable: "ProcedureType",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Room_RoomSerialNumber",
                        column: x => x.RoomSerialNumber,
                        principalTable: "Room",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FollowUp",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PhysicianSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUp", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_FollowUp_Physician_PhysicianSerialNumber",
                        column: x => x.PhysicianSerialNumber,
                        principalTable: "Physician",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Physician_VacationTime",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PhysicianSerialNumber = table.Column<string>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Physician_VacationTime", x => new { x.PhysicianSerialNumber, x.Id });
                    table.ForeignKey(
                        name: "FK_Physician_VacationTime_Physician_PhysicianSerialNumber",
                        column: x => x.PhysicianSerialNumber,
                        principalTable: "Physician",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicianSpecialization",
                columns: table => new
                {
                    PhysicianSerialNumber = table.Column<string>(nullable: false),
                    SpecializationSerialNumber = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicianSpecialization", x => new { x.PhysicianSerialNumber, x.SpecializationSerialNumber });
                    table.ForeignKey(
                        name: "FK_PhysicianSpecialization_Physician_PhysicianSerialNumber",
                        column: x => x.PhysicianSerialNumber,
                        principalTable: "Physician",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicianSpecialization_Specialization_SpecializationSerial~",
                        column: x => x.SpecializationSerialNumber,
                        principalTable: "Specialization",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Findings = table.Column<string>(nullable: true),
                    PhysicianSerialNumber = table.Column<string>(nullable: true),
                    PatientConditions = table.Column<string>(nullable: true),
                    ProcedureTypeSerialNumber = table.Column<string>(nullable: true),
                    PatientName = table.Column<string>(nullable: true),
                    PhysitianName = table.Column<string>(nullable: true),
                    PatientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Report_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_Physician_PhysicianSerialNumber",
                        column: x => x.PhysicianSerialNumber,
                        principalTable: "Physician",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_ProcedureType_ProcedureTypeSerialNumber",
                        column: x => x.ProcedureTypeSerialNumber,
                        principalTable: "ProcedureType",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialistReferral",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    ProcedureTypeSerialNumber = table.Column<string>(nullable: true),
                    PhysicianSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialistReferral", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_SpecialistReferral_Physician_PhysicianSerialNumber",
                        column: x => x.PhysicianSerialNumber,
                        principalTable: "Physician",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialistReferral_ProcedureType_ProcedureTypeSerialNumber",
                        column: x => x.ProcedureTypeSerialNumber,
                        principalTable: "ProcedureType",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportDiagnosticReferral",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ReportSerialNumber = table.Column<string>(nullable: true),
                    DiagnosticReferralSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDiagnosticReferral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportDiagnosticReferral_DiagnosticReferral_DiagnosticRefer~",
                        column: x => x.DiagnosticReferralSerialNumber,
                        principalTable: "DiagnosticReferral",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportDiagnosticReferral_Report_ReportSerialNumber",
                        column: x => x.ReportSerialNumber,
                        principalTable: "Report",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportFollowUp",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ReportSerialNumber = table.Column<string>(nullable: true),
                    FollowUpSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportFollowUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportFollowUp_FollowUp_FollowUpSerialNumber",
                        column: x => x.FollowUpSerialNumber,
                        principalTable: "FollowUp",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportFollowUp_Report_ReportSerialNumber",
                        column: x => x.ReportSerialNumber,
                        principalTable: "Report",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportPrescription",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ReportSerialNumber = table.Column<string>(nullable: true),
                    PrescriptionSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportPrescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportPrescription_Prescription_PrescriptionSerialNumber",
                        column: x => x.PrescriptionSerialNumber,
                        principalTable: "Prescription",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportPrescription_Report_ReportSerialNumber",
                        column: x => x.ReportSerialNumber,
                        principalTable: "Report",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportSpecialistReferral",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ReportSerialNumber = table.Column<string>(nullable: true),
                    SpecialistReferralSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSpecialistReferral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportSpecialistReferral_Report_ReportSerialNumber",
                        column: x => x.ReportSerialNumber,
                        principalTable: "Report",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportSpecialistReferral_SpecialistReferral_SpecialistRefer~",
                        column: x => x.SpecialistReferralSerialNumber,
                        principalTable: "SpecialistReferral",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CitySerialNumber",
                table: "Address",
                column: "CitySerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientSerialNumber",
                table: "Appointment",
                column: "PatientSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PhysicianSerialNumber",
                table: "Appointment",
                column: "PhysicianSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ProcedureTypeSerialnumber",
                table: "Appointment",
                column: "ProcedureTypeSerialnumber");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_RoomSerialNumber",
                table: "Appointment",
                column: "RoomSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_BuildingSerialNumber",
                table: "Bed",
                column: "BuildingSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_FloorSerialNumber",
                table: "Bed",
                column: "FloorSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_PatientSerialNumber",
                table: "Bed",
                column: "PatientSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_RoomSerialNumber",
                table: "Bed",
                column: "RoomSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_RoomSerialNumber2",
                table: "Bed",
                column: "RoomSerialNumber2");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountrySerialNumber",
                table: "City",
                column: "CountrySerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticReferral_DiagnosticTypeSerialNumber",
                table: "DiagnosticReferral",
                column: "DiagnosticTypeSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_BuildingSerialNumber",
                table: "Equipment",
                column: "BuildingSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_FloorSerialNumber",
                table: "Equipment",
                column: "FloorSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ProcedureTypeSerialNumber",
                table: "Equipment",
                column: "ProcedureTypeSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RoomSerialNumber",
                table: "Equipment",
                column: "RoomSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RoomSerialNumber2",
                table: "Equipment",
                column: "RoomSerialNumber2");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_BuildingSerialNumber",
                table: "Floor",
                column: "BuildingSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUp_PhysicianSerialNumber",
                table: "FollowUp",
                column: "PhysicianSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_MedicineManufacturerSerialNumber",
                table: "Medicine",
                column: "MedicineManufacturerSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_MedicineTypeSerialNumber",
                table: "Medicine",
                column: "MedicineTypeSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDosage_MedicineSerialNumber",
                table: "MedicineDosage",
                column: "MedicineSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDosage_PrescriptionSerialNumber",
                table: "MedicineDosage",
                column: "PrescriptionSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AddressSerialNumber",
                table: "Patient",
                column: "AddressSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Physician_AddressSerialNumber",
                table: "Physician",
                column: "AddressSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicianSpecialization_SpecializationSerialNumber",
                table: "PhysicianSpecialization",
                column: "SpecializationSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicineDosage_MedicineDosageSerialNumber",
                table: "PrescriptionMedicineDosage",
                column: "MedicineDosageSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicineDosage_PrescriptionSerialNumber",
                table: "PrescriptionMedicineDosage",
                column: "PrescriptionSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureType_SpecializationSerialNumber",
                table: "ProcedureType",
                column: "SpecializationSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Rejection_MedicineSerialNumber",
                table: "Rejection",
                column: "MedicineSerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Report_PatientId",
                table: "Report",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_PhysicianSerialNumber",
                table: "Report",
                column: "PhysicianSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ProcedureTypeSerialNumber",
                table: "Report",
                column: "ProcedureTypeSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDiagnosticReferral_DiagnosticReferralSerialNumber",
                table: "ReportDiagnosticReferral",
                column: "DiagnosticReferralSerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportDiagnosticReferral_ReportSerialNumber",
                table: "ReportDiagnosticReferral",
                column: "ReportSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ReportFollowUp_FollowUpSerialNumber",
                table: "ReportFollowUp",
                column: "FollowUpSerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportFollowUp_ReportSerialNumber",
                table: "ReportFollowUp",
                column: "ReportSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ReportPrescription_PrescriptionSerialNumber",
                table: "ReportPrescription",
                column: "PrescriptionSerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportPrescription_ReportSerialNumber",
                table: "ReportPrescription",
                column: "ReportSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSpecialistReferral_ReportSerialNumber",
                table: "ReportSpecialistReferral",
                column: "ReportSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSpecialistReferral_SpecialistReferralSerialNumber",
                table: "ReportSpecialistReferral",
                column: "SpecialistReferralSerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_FloorSerialNumber",
                table: "Room",
                column: "FloorSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeSerialNumber",
                table: "Room",
                column: "RoomTypeSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Secretary_AddressSerialNumber",
                table: "Secretary",
                column: "AddressSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistReferral_PhysicianSerialNumber",
                table: "SpecialistReferral",
                column: "PhysicianSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistReferral_ProcedureTypeSerialNumber",
                table: "SpecialistReferral",
                column: "ProcedureTypeSerialNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionAndBenefitMessage");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Bed");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Physician_VacationTime");

            migrationBuilder.DropTable(
                name: "PhysicianSpecialization");

            migrationBuilder.DropTable(
                name: "PrescriptionMedicineDosage");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Rejection");

            migrationBuilder.DropTable(
                name: "ReportDiagnosticReferral");

            migrationBuilder.DropTable(
                name: "ReportFollowUp");

            migrationBuilder.DropTable(
                name: "ReportPrescription");

            migrationBuilder.DropTable(
                name: "ReportSpecialistReferral");

            migrationBuilder.DropTable(
                name: "Secretary");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "MedicineDosage");

            migrationBuilder.DropTable(
                name: "DiagnosticReferral");

            migrationBuilder.DropTable(
                name: "FollowUp");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "SpecialistReferral");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "RoomType");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "DiagnosticType");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Physician");

            migrationBuilder.DropTable(
                name: "ProcedureType");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "MedicineManufacturer");

            migrationBuilder.DropTable(
                name: "MedicineType");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
