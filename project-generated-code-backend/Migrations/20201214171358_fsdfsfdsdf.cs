using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HealthClinicBackend.Migrations
{
    public partial class fsdfsfdsdf : Migration
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
                name: "Apis",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Key = table.Column<string>(nullable: false),
                    PharmacyName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Subscribed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apis", x => x.SerialNumber);
                    table.UniqueConstraint("AK_Apis_Key", x => x.Key);
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
                    Active = table.Column<bool>(nullable: false)
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
                    IsApproved = table.Column<bool>(nullable: false),
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
                name: "MedicinePharmacy",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    MedicineID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MedicineSpecificationID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinePharmacy", x => x.SerialNumber);
                    table.UniqueConstraint("AK_MedicinePharmacy_MedicineID", x => x.MedicineID);
                });

            migrationBuilder.CreateTable(
                name: "MedicineReport",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineReport", x => x.SerialNumber);
                    table.UniqueConstraint("AK_MedicineReport_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineSpecification",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Regime = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineSpecification", x => x.SerialNumber);
                    table.UniqueConstraint("AK_MedicineSpecification_ID", x => x.ID);
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
                name: "Physician",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AddressSerialNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Physician", x => x.SerialNumber);
                    table.UniqueConstraint("AK_Physician_Id", x => x.Id);
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SerialNumber = table.Column<string>(nullable: true),
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
                    Id = table.Column<string>(nullable: true),
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
                name: "MedicineDosagePharmacy",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    MedicineName = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    MedicineReportSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDosagePharmacy", x => x.SerialNumber);
                    table.UniqueConstraint("AK_MedicineDosagePharmacy_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineDosagePharmacy_MedicineReport_MedicineReportSerialN~",
                        column: x => x.MedicineReportSerialNumber,
                        principalTable: "MedicineReport",
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
                name: "Patient",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
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
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PhysicianSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.SerialNumber);
                    table.UniqueConstraint("AK_Patient_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Physician_PhysicianSerialNumber",
                        column: x => x.PhysicianSerialNumber,
                        principalTable: "Physician",
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
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RoomId = table.Column<string>(nullable: true),
                    BuildingSerialNumber = table.Column<string>(nullable: true),
                    FloorSerialNumber = table.Column<string>(nullable: true),
                    RoomSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
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
                        name: "FK_Equipment_Room_RoomSerialNumber",
                        column: x => x.RoomSerialNumber,
                        principalTable: "Room",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
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
                    PatientSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bed", x => x.SerialNumber);
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

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "SerialNumber", "CitySerialNumber", "Street" },
                values: new object[,]
                {
                    { "200002", null, "Njegoševa 46" },
                    { "200001", null, "Njegoševa 45" }
                });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "SerialNumber", "Active", "PatientSerialNumber", "PhysicianSerialNumber", "ProcedureTypeSerialnumber", "RoomSerialNumber", "Urgency", "TimeInterval_End", "TimeInterval_Id", "TimeInterval_Start" },
                values: new object[,]
                {
                    { "200002", false, "0002", "600002", null, "103", false, new DateTime(2020, 12, 14, 18, 13, 57, 286, DateTimeKind.Local).AddTicks(531), null, new DateTime(2020, 12, 14, 18, 13, 57, 286, DateTimeKind.Local).AddTicks(513) },
                    { "200001", false, "0003", "600001", null, "101", true, new DateTime(2020, 12, 14, 18, 13, 57, 285, DateTimeKind.Local).AddTicks(9213), null, new DateTime(2020, 12, 14, 18, 13, 57, 283, DateTimeKind.Local).AddTicks(2711) }
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
                table: "Feedback",
                columns: new[] { "SerialNumber", "Approved", "Date", "PatientId", "Text" },
                values: new object[,]
                {
                    { "08dde094-2115-4b7d-be91-3f41b3b93b3a", true, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "00010", "usluga na nivou" },
                    { "f683c5d9-b93c-4fb3-ba02-30a8a1c8de0d", false, new DateTime(2019, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "0008", "sve pohvale" },
                    { "72aab4af-1535-4ade-82b0-99e3692a03ca", false, new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0004", "ok" },
                    { "cf7d48cd-92b7-46a2-a749-839c4b5e9c3c", false, new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0003", "dobro" },
                    { "d0a94946-41ec-494b-a705-8e1def3d1ec9", true, new DateTime(2018, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "0002", "moze bolje" },
                    { "90c764a7-adb9-478e-ba5c-12abc7dc5abb", false, new DateTime(2015, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0001", "onako" },
                    { "3d2beca3-b9e1-409a-b115-3adf36b5e6f9", true, new DateTime(2016, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0001", "super" },
                    { "7ec9311f-d1d8-4256-865f-3abdbb9e824f", true, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0007", "nikako" }
                });

            migrationBuilder.InsertData(
                table: "Floor",
                columns: new[] { "SerialNumber", "BuildingSerialNumber", "Name" },
                values: new object[,]
                {
                    { "1001", "10001", "Floor1" },
                    { "1002", "10001", "Floor2" },
                    { "1003", "10002", "Floor1" }
                });

            migrationBuilder.InsertData(
                table: "Medicine",
                columns: new[] { "SerialNumber", "CopyrightName", "GenericName", "IsApproved", "MedicineManufacturerSerialNumber", "MedicineTypeSerialNumber" },
                values: new object[,]
                {
                    { "21", "Brufen", "Brufen", false, "1", "11" },
                    { "22", "Probiotic", "Probiotic", false, "2", "12" }
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
                columns: new[] { "SerialNumber", "AddressSerialNumber", "Citizenship", "Contact", "DateOfBirth", "Email", "EmailConfirmed", "EmploymentStatus", "FamilyDiseases", "Gender", "Guest", "HealthInsuranceNumber", "Id", "Image", "MaritalStatus", "MunicipalityOfBirth", "MunicipalityOfResidence", "Name", "Nationality", "ParentName", "Password", "PersonalDiseases", "PhysicianSerialNumber", "PlaceOfBirth", "PlaceOfResidence", "Profession", "StateOfBirth", "StateOfResidence", "Surname" },
                values: new object[,]
                {
                    { "0002", null, null, "kontakt", new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "email", false, null, null, "Zensko", true, null, "0002", null, null, null, null, "Jelena", null, "otac", "sifra", null, null, null, null, null, null, null, "Tanjic" },
                    { "0003", null, null, "kontaktMica", new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emailMica", false, null, null, "Zensko", true, null, "0003", null, null, null, null, "Sara", null, "mama", "sifraMica", null, null, null, null, null, null, null, "Milic" }
                });

            migrationBuilder.InsertData(
                table: "Physician",
                columns: new[] { "SerialNumber", "AddressSerialNumber", "Contact", "DateOfBirth", "Email", "Id", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { "600001", "200001", "Simic kontakt", new DateTime(1975, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "simic@gmail.com", "600001", "Gojko", "sifraSimic24dsf1", "Simic" },
                    { "600002", "200002", "Dicic kontakt", new DateTime(1985, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "dicic@gmail.com", "600002", "Klara", "sifraDicic98754", "Dicic" }
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
                    { "400002", "82", "300002" },
                    { "400001", "81", "300001" }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "QuestionText", "SerialNumber" },
                values: new object[,]
                {
                    { 5, "The personal manner(courtosy,respect,sensitivity,friendliness) of the nurses and other support staff?", "a9f9f098-1fe0-4c1d-8741-64b87e2bcb41" },
                    { 6, "The nursees answered all of your questions in an understandable manner?", "34fad81b-fbe0-47e4-b3be-00101f45b8ea" },
                    { 9, "The nurse was concern for you?", "77ba541b-f950-4efe-85d4-98ecf32630fb" },
                    { 4, "Would you have the procedure done again by this doctor?", "effeb5b2-6ee7-4f2e-9c44-e4a532e9334c" },
                    { 3, "The doctor takes care of you in a professional manner?", "9c6d1aec-9a81-44f6-9e29-91dbf087128d" },
                    { 2, "The doctor answered all of your questions in an understandable manner?", "8f97977b-c7d2-4620-8b31-d3f4396611d5" },
                    { 1, "The doctor is welcoming and gentle?", "1e596336-e8b8-4735-abf5-65297d07a3ce" },
                    { 10, "The comfort and cleanliness of the facility", "4eb89caa-91be-4085-b921-2c25d8864e23" },
                    { 7, "Orientation given to warn setup", "6385b0d6-0e6e-465f-9ceb-7e886a218a05" },
                    { 11, "Comfort level within the procedure room?", "32df310d-1bd1-4f73-b7f8-2840bcc5e88d" },
                    { 13, "General impression of the ambient atmosphere", "968f6ad0-dd24-4266-8b1a-38325176fa31" },
                    { 14, "Do you think the clinic has the necessary equipment", "e16a7bd1-b252-49c5-a919-3b0e98078b48" },
                    { 15, "Do you think the clinic's farmacy has the necessary drugs?", "85329164-ad38-496f-a1ce-08dc94205c4d" },
                    { 16, "Do you think that the hospital should have more modern equipment than the current one", "595a7379-5393-417f-a179-aed7e3da77d7" },
                    { 17, "Did you noticed broken or damaged equipment in the hospital", "7a34bc77-cda2-42dc-b34a-cad7f78851fe" },
                    { 18, "The doctor prescribed medications that I could buy at the clinic's pharmacy", "70735c00-71ee-4989-aa0d-3febd917e9b6" },
                    { 19, "Did you found it easy to use our website?", "a3ec695c-ed89-4290-b0c4-2790076e7088" },
                    { 20, "Did you have found all the necessary information on our website?", "730fa57b-3a57-4bc8-a7cb-1b7813c60ef0" },
                    { 21, "Overall, are you satisfied with the care you received in this facility?", "8c6d5f63-b8c7-41fa-9afa-be8081087d8b" },
                    { 22, "Would you come to this institution again", "f723fc76-5d4c-4ac5-8658-a474f9ed7354" },
                    { 23, ">Would you recommend this facility to your friends and family", "0522bdab-028f-40b3-9475-0470d1b3085a" },
                    { 12, "Conditions of the rooms(temperature,comfort,silence)", "3f56aa75-a19f-413b-b111-c7407e731c48" },
                    { 8, "The nurse gave you good discharge instructions", "d0bcf4e8-81ea-4d89-9b1a-662672fb5348" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "SerialNumber", "Column", "ColumnSpan", "FloorSerialNumber", "Id", "Name", "RoomTypeSerialNumber", "Row", "RowSpan", "Style" },
                values: new object[,]
                {
                    { "105", 9, 5, "1001", 105, "Store room 105", "10000002", 10, 2, "RoomButtonStyle" },
                    { "101", 0, 5, "1001", 101, "Examination room 101", "10000003", 0, 3, "RoomButtonStyle" },
                    { "106", 0, 7, "1002", 106, "Operation room 106", "10000001", 0, 4, "RoomButtonStyle" },
                    { "107", 0, 7, "1002", 107, "Operation room 107", "10000001", 8, 4, "RoomButtonStyle" },
                    { "108", 10, 3, "1002", 108, "Store room 108", "10000002", 0, 2, "RoomButtonStyle" },
                    { "109", 0, 0, "1003", 109, "Examination room 109", "10000003", 0, 0, "RoomButtonStyle" },
                    { "104", 14, 5, "1001", 104, "Examination room 104", "10000003", 0, 3, "RoomButtonStyle" },
                    { "111", 0, 0, "1003", 111, "Examination room 111", "10000003", 0, 0, "RoomButtonStyle" },
                    { "110", 0, 0, "1003", 110, "Operation room 110", "10000001", 0, 0, "RoomButtonStyle" },
                    { "113", 0, 0, "1003", 113, "Examination room 113", "10000003", 0, 0, "RoomButtonStyle" },
                    { "114", 0, 0, "1003", 114, "Examination room 114", "10000003", 0, 0, "RoomButtonStyle" },
                    { "103", 5, 3, "1001", 103, "Store room 103", "10000002", 0, 2, "RoomButtonStyle" },
                    { "102", 10, 4, "1001", 102, "Examination room 102", "10000003", 0, 2, "RoomButtonStyle" },
                    { "112", 0, 0, "1003", 112, "Store room 112", "10000002", 0, 0, "RoomButtonStyle" }
                });

            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "SerialNumber", "Name" },
                values: new object[,]
                {
                    { "10000002", "Store room" },
                    { "10000003", "Examination room" },
                    { "10000001", "Operation room" }
                });

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "SerialNumber", "Name" },
                values: new object[,]
                {
                    { "500002", "Family doctor" },
                    { "500001", "Neurosurgeon " }
                });

            migrationBuilder.InsertData(
                table: "Survey",
                columns: new[] { "SerialNumber", "DoctorName", "Id", "Question1", "Question10", "Question11", "Question12", "Question13", "Question14", "Question15", "Question16", "Question17", "Question18", "Question19", "Question2", "Question20", "Question21", "Question22", "Question23", "Question3", "Question4", "Question5", "Question6", "Question7", "Question8", "Question9" },
                values: new object[,]
                {
                    { "abfd6e64-6f86-4e46-a0a9-d90c2ec99776", "Pera Peric", "001", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" },
                    { "619a2011-2c3e-44e2-9c31-67f87591e076", "Mika Mikic", "005", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" }
                });

            migrationBuilder.InsertData(
                table: "Bed",
                columns: new[] { "SerialNumber", "BuildingSerialNumber", "FloorSerialNumber", "Id", "Name", "PatientSerialNumber", "RoomId", "RoomSerialNumber" },
                values: new object[,]
                {
                    { "100001", "10001", "1001", "100001", "Bed 1", "0002", "101", "101" },
                    { "100002", "10001", "1001", "100002", "Bed 2", "0003", "102", "101" },
                    { "100003", "10001", "1001", "100003", "Bed 3", null, "103", "102" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BuildingSerialNumber", "FloorSerialNumber", "Name", "RoomId", "RoomSerialNumber", "SerialNumber" },
                values: new object[,]
                {
                    { "11", "10001", "1001", "Bed", "101", "101", "73" },
                    { "12", "10001", "1001", "Bed", "102", "101", "74" },
                    { "13", "10001", "1001", "Bed", "103", "101", "75" },
                    { "14", "10001", "1001", "Bed", "101", "101", "76" },
                    { "15", "10001", "1002", "Bed", "102", "106", "77" },
                    { "16", "10001", "1002", "Table", "104", "106", "78" },
                    { "17", "10001", "1002", "Table", "111", "107", "79" },
                    { "18", "10001", "1002", "Table", "111", "107", "80" },
                    { "19", "10002", "1003", "Bed", "112", "114", "81" },
                    { "20", "10002", "1003", "Bed", "112", "114", "82" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CitySerialNumber",
                table: "Address",
                column: "CitySerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_PatientSerialNumber",
                table: "Bed",
                column: "PatientSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_RoomSerialNumber",
                table: "Bed",
                column: "RoomSerialNumber");

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
                name: "IX_Equipment_RoomSerialNumber",
                table: "Equipment",
                column: "RoomSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUp_PhysicianSerialNumber",
                table: "FollowUp",
                column: "PhysicianSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDosage_MedicineSerialNumber",
                table: "MedicineDosage",
                column: "MedicineSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDosage_PrescriptionSerialNumber",
                table: "MedicineDosage",
                column: "PrescriptionSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDosagePharmacy_MedicineReportSerialNumber",
                table: "MedicineDosagePharmacy",
                column: "MedicineReportSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PhysicianSerialNumber",
                table: "Patient",
                column: "PhysicianSerialNumber");

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
                name: "Apis");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Bed");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "MedicineDosagePharmacy");

            migrationBuilder.DropTable(
                name: "MedicineManufacturer");

            migrationBuilder.DropTable(
                name: "MedicinePharmacy");

            migrationBuilder.DropTable(
                name: "MedicineSpecification");

            migrationBuilder.DropTable(
                name: "MedicineType");

            migrationBuilder.DropTable(
                name: "PhysicianSpecialization");

            migrationBuilder.DropTable(
                name: "PrescriptionMedicineDosage");

            migrationBuilder.DropTable(
                name: "ProcedureTypeEquipmentUsage");

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
                name: "RoomType");

            migrationBuilder.DropTable(
                name: "Secretary");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "MedicineReport");

            migrationBuilder.DropTable(
                name: "Specialization");

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
                name: "Address");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "DiagnosticType");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "ProcedureType");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Physician");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
