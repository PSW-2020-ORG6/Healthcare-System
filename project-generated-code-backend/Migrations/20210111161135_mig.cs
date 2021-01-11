using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HealthClinicBackend.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "EquipmentRelocations",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    startTime = table.Column<DateTime>(nullable: false),
                    endTime = table.Column<DateTime>(nullable: false),
                    roomToRelocateToSerialNumber = table.Column<string>(nullable: true),
                    equipmentSerialNumber = table.Column<string>(nullable: true),
                    quantity = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentRelocations", x => x.SerialNumber);
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
                    MedicineTypeSerialNumber = table.Column<string>(nullable: true),
                    RoomSerialNumber = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 1)
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
                name: "PhysicianSpecialization",
                columns: table => new
                {
                    PhysicianSerialNumber = table.Column<string>(nullable: false),
                    SpecializationSerialNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicianSpecialization", x => new { x.PhysicianSerialNumber, x.SpecializationSerialNumber });
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
                name: "ProcedureEquipment",
                columns: table => new
                {
                    ProcedureTypeSerialNumber = table.Column<string>(nullable: false),
                    EquipmentSerialNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureEquipment", x => new { x.ProcedureTypeSerialNumber, x.EquipmentSerialNumber });
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
                    Position_Row = table.Column<int>(nullable: true),
                    Position_Column = table.Column<int>(nullable: true),
                    Position_RowSpan = table.Column<int>(nullable: true),
                    Position_ColumnSpan = table.Column<int>(nullable: true),
                    Style = table.Column<string>(nullable: true),
                    BottomDoorVisible = table.Column<int>(nullable: false),
                    RightDoorVisible = table.Column<int>(nullable: false),
                    LeftDoorVisible = table.Column<int>(nullable: false),
                    TopDoorVisible = table.Column<int>(nullable: false)
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
                    Diagnose = table.Column<string>(nullable: true),
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
                name: "Equipment",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    RoomId = table.Column<string>(nullable: true),
                    RoomSerialNumber = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 1),
                    Discriminator = table.Column<string>(nullable: false),
                    PatientSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Equipment_Patient_PatientSerialNumber",
                        column: x => x.PatientSerialNumber,
                        principalTable: "Patient",
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
                columns: new[] { "SerialNumber", "Active", "Date", "PatientSerialNumber", "PhysicianSerialNumber", "ProcedureTypeSerialnumber", "RoomSerialNumber", "Urgency", "TimeInterval_End", "TimeInterval_Id", "TimeInterval_Start" },
                values: new object[,]
                {
                    { "200001", false, new DateTime(2021, 1, 11, 17, 11, 35, 272, DateTimeKind.Local).AddTicks(6570), "0002", "600001", "300001", "101", true, new DateTime(2021, 1, 11, 17, 11, 35, 272, DateTimeKind.Local).AddTicks(315), null, new DateTime(2021, 1, 11, 17, 11, 35, 268, DateTimeKind.Local).AddTicks(7216) },
                    { "200002", false, new DateTime(2021, 1, 11, 17, 11, 35, 272, DateTimeKind.Local).AddTicks(8010), "0002", "600001", "300002", "102", false, new DateTime(2021, 1, 11, 17, 11, 35, 272, DateTimeKind.Local).AddTicks(1715), null, new DateTime(2021, 1, 11, 17, 11, 35, 272, DateTimeKind.Local).AddTicks(1696) }
                });

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "SerialNumber", "Color", "Column", "Name", "Row", "Style" },
                values: new object[,]
                {
                    { "10002", "Red", 3, "Orthopedy", 5, "UBuildingButtonStyle" },
                    { "10001", "Orange", 1, "Cardiology", 5, "TriangleBuildingButtonStyle" }
                });

            migrationBuilder.InsertData(
                table: "EquipmentRelocations",
                columns: new[] { "SerialNumber", "endTime", "equipmentSerialNumber", "quantity", "roomToRelocateToSerialNumber", "startTime" },
                values: new object[] { "ER1", new DateTime(2021, 1, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "78", 1L, "105", new DateTime(2021, 1, 20, 9, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "SerialNumber", "Approved", "Date", "PatientId", "Text" },
                values: new object[,]
                {
                    { "2fe2f4e2-cd95-410f-b126-303bb843b3f0", true, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "00010", "usluga na nivou" },
                    { "55e74a72-4939-4f0b-a82c-93c0f54aed3c", false, new DateTime(2019, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "0008", "sve pohvale" },
                    { "15702b6c-47d4-45e3-8b4d-a1c4a5078d40", true, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0007", "nikako" },
                    { "a386e04f-4379-4e06-ac44-155d84d795d1", false, new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0004", "ok" },
                    { "55458aa8-074c-4e0d-aa67-ce7028d70523", true, new DateTime(2018, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "0002", "moze bolje" },
                    { "fe596a8e-a66e-45f7-8c46-fcabf56f0bd5", false, new DateTime(2015, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0001", "onako" },
                    { "4ef0e84b-d2e1-4bfa-9ab7-d4b55790e3df", true, new DateTime(2016, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0001", "super" },
                    { "71e11297-c12d-47c0-ab6e-c9e605c63355", false, new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "0003", "dobro" }
                });

            migrationBuilder.InsertData(
                table: "Floor",
                columns: new[] { "SerialNumber", "BuildingSerialNumber", "Name" },
                values: new object[,]
                {
                    { "1001", "10001", "Ground floor" },
                    { "1002", "10001", "First floor" },
                    { "1003", "10002", "Ground floor" }
                });

            migrationBuilder.InsertData(
                table: "Medicine",
                columns: new[] { "SerialNumber", "CopyrightName", "GenericName", "IsApproved", "MedicineManufacturerSerialNumber", "MedicineTypeSerialNumber", "Quantity", "RoomSerialNumber" },
                values: new object[,]
                {
                    { "23", "Aspirin", "Aspirin", false, "2", "12", 150, "103" },
                    { "22", "Probiotic", "Probiotic", false, "2", "12", 30, "102" },
                    { "21", "Brufen", "Brufen", false, "1", "11", 50, "101" }
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
                columns: new[] { "SerialNumber", "AddressSerialNumber", "Citizenship", "Contact", "DateOfBirth", "Diagnose", "Email", "EmailConfirmed", "EmploymentStatus", "FamilyDiseases", "Gender", "Guest", "HealthInsuranceNumber", "Id", "Image", "MaritalStatus", "MunicipalityOfBirth", "MunicipalityOfResidence", "Name", "Nationality", "ParentName", "Password", "PersonalDiseases", "PhysicianSerialNumber", "PlaceOfBirth", "PlaceOfResidence", "Profession", "StateOfBirth", "StateOfResidence", "Surname" },
                values: new object[,]
                {
                    { "0003", null, null, "kontaktMica", new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "emailMica", false, null, null, "Zensko", true, null, "0003", null, null, null, null, "Sara", null, "mama", "sifraMica", null, null, null, null, null, null, null, "Milic" },
                    { "0002", null, null, "kontakt", new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "email", false, null, null, "Zensko", true, null, "0002", null, null, null, null, "Jelena", null, "otac", "sifra", null, null, null, null, null, null, null, "Tanjic" }
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
                table: "PhysicianSpecialization",
                columns: new[] { "PhysicianSerialNumber", "SpecializationSerialNumber" },
                values: new object[,]
                {
                    { "600002", "500001" },
                    { "600002", "500003" },
                    { "600002", "500004" },
                    { "600001", "500002" },
                    { "600001", "500001" },
                    { "600002", "500002" }
                });

            migrationBuilder.InsertData(
                table: "ProcedureEquipment",
                columns: new[] { "ProcedureTypeSerialNumber", "EquipmentSerialNumber" },
                values: new object[,]
                {
                    { "300001", "80" },
                    { "300001", "78" },
                    { "300002", "80" },
                    { "300002", "83" },
                    { "300002", "85" },
                    { "300003", "84" },
                    { "300004", "82" },
                    { "300001", "81" }
                });

            migrationBuilder.InsertData(
                table: "ProcedureType",
                columns: new[] { "SerialNumber", "EstimatedTimeInMinutes", "Name", "SpecializationSerialNumber" },
                values: new object[,]
                {
                    { "300002", 30, "Appointment with general practitioner", "500004" },
                    { "300003", 40, "Operation by neurosurgeon ", "500002" },
                    { "300004", 60, "Operation by kneesurgeon", "500003" },
                    { "300001", 50, "Appointment with neuropsychiatrist", "500001" }
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
                    { 23, ">Would you recommend this facility to your friends and family", "31d75d2b-fbca-4ef3-8e52-b2b5636e1bc6" },
                    { 22, "Would you come to this institution again", "c5e60635-d5bf-4195-81f8-3d8ea33a9aa1" },
                    { 21, "Overall, are you satisfied with the care you received in this facility?", "da67e8b8-c260-4893-8cb0-3503f7a820e7" },
                    { 20, "Did you have found all the necessary information on our website?", "2898f535-deba-4106-9365-b058aa2ce81f" },
                    { 19, "Did you found it easy to use our website?", "6ef0403d-1c96-415c-a18b-64706b4844b5" },
                    { 18, "The doctor prescribed medications that I could buy at the clinic's pharmacy", "51395c39-9ba0-48b0-adfe-c889d7a030b9" },
                    { 17, "Did you noticed broken or damaged equipment in the hospital", "c0e55b66-3197-48d6-868e-01818bf9fc49" },
                    { 16, "Do you think that the hospital should have more modern equipment than the current one", "ffaa9d66-b421-40ca-aac4-19a736587e5c" },
                    { 15, "Do you think the clinic's farmacy has the necessary drugs?", "211a4479-32a0-4b54-a8f0-410fb8d99089" },
                    { 14, "Do you think the clinic has the necessary equipment", "1ed71630-13f7-44d9-917d-342a0b96da6c" },
                    { 1, "The doctor is welcoming and gentle?", "234ecb39-b078-4d73-9600-1a854e4061e3" },
                    { 2, "The doctor answered all of your questions in an understandable manner?", "51ec4b1e-85bb-434b-a6c2-0cd8ccdaa65d" },
                    { 3, "The doctor takes care of you in a professional manner?", "453c6201-a398-4b01-a777-f9f4f42063ee" },
                    { 4, "Would you have the procedure done again by this doctor?", "511ef2c5-d2d8-469c-832f-fa39e0ea5c51" },
                    { 6, "The nursees answered all of your questions in an understandable manner?", "d4c9b9be-228e-4f26-8491-6df69c14e0c2" },
                    { 7, "Orientation given to warn setup", "0a44077b-d007-49c6-9821-5778b7da57df" },
                    { 5, "The personal manner(courtosy,respect,sensitivity,friendliness) of the nurses and other support staff?", "8b58053d-8999-4385-9b13-2ff5f753f051" },
                    { 13, "General impression of the ambient atmosphere", "5bce5956-52bc-4187-950e-b3fd195dfd80" },
                    { 9, "The nurse was concern for you?", "a5b85d0b-8ca6-4cd7-8137-03aa48595962" },
                    { 8, "The nurse gave you good discharge instructions", "aa68c011-90e4-4a16-b0a0-f2075154ac65" },
                    { 10, "The comfort and cleanliness of the facility", "5f0dae2e-9148-46a7-9e35-4bdd044b54a4" },
                    { 11, "Comfort level within the procedure room?", "1166b3f2-4ff4-418c-8207-3e91ee7a00a1" },
                    { 12, "Conditions of the rooms(temperature,comfort,silence)", "e944ccce-1e1b-45f6-9291-80fbd2de5a69" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "SerialNumber", "BottomDoorVisible", "FloorSerialNumber", "Id", "LeftDoorVisible", "Name", "RightDoorVisible", "RoomTypeSerialNumber", "Style", "TopDoorVisible", "Position_Column", "Position_ColumnSpan", "Position_Row", "Position_RowSpan" },
                values: new object[,]
                {
                    { "105", 2, "1001", 105, 0, "Store room 105", 0, "10000002", "RoomButtonStyle", 0, 17, 1, 12, 1 },
                    { "102", 0, "1001", 102, 2, "Examination room 102", 2, "10000003", "RoomButtonStyle", 2, 10, 4, 0, 2 },
                    { "101", 0, "1001", 101, 2, "Examination room 101", 0, "10000003", "RoomButtonStyle", 2, 14, 4, 6, 3 },
                    { "104", 0, "1001", 104, 2, "Examination room 104", 2, "10000003", "RoomButtonStyle", 2, 14, 5, 0, 3 },
                    { "103", 0, "1001", 103, 2, "Store room 103", 2, "10000002", "RoomButtonStyle", 2, 5, 3, 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "SerialNumber", "Name" },
                values: new object[,]
                {
                    { "10000003", "Examination room" },
                    { "10000002", "Store room" },
                    { "10000001", "Operation room" }
                });

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "SerialNumber", "Name" },
                values: new object[,]
                {
                    { "500003", "Kneesurgeon " },
                    { "500004", "General practitioner" },
                    { "500001", "Neuropsychiatrist " },
                    { "500002", "Neurosurgeon " }
                });

            migrationBuilder.InsertData(
                table: "Survey",
                columns: new[] { "SerialNumber", "DoctorName", "Id", "Question1", "Question10", "Question11", "Question12", "Question13", "Question14", "Question15", "Question16", "Question17", "Question18", "Question19", "Question2", "Question20", "Question21", "Question22", "Question23", "Question3", "Question4", "Question5", "Question6", "Question7", "Question8", "Question9" },
                values: new object[,]
                {
                    { "fadfd0f0-3143-4759-ad05-20cb9bb46048", "Mika Mikic", "005", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" },
                    { "993d8fd5-cec8-44e4-8e31-427420dc52ca", "Pera Peric", "001", "5", "5", "2", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "3", "2", "4", "5", "5", "4", "3", "5", "5", "1" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "SerialNumber", "Discriminator", "Id", "Name", "RoomId", "RoomSerialNumber", "PatientSerialNumber" },
                values: new object[,]
                {
                    { "100001", "Bed", "100001", "Bed 1", "101", "101", "0002" },
                    { "100002", "Bed", "100002", "Bed 2", "102", "101", "0003" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "SerialNumber", "Discriminator", "Id", "Name", "Quantity", "RoomId", "RoomSerialNumber" },
                values: new object[,]
                {
                    { "80", "Equipment", "18", "Table", 3, "101", "101" },
                    { "84", "Equipment", "22", "Stethoscope", 10, "101", "101" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "SerialNumber", "Discriminator", "Id", "Name", "RoomId", "RoomSerialNumber", "PatientSerialNumber" },
                values: new object[] { "100003", "Bed", "100003", "Bed 3", "103", "102", null });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "SerialNumber", "Discriminator", "Id", "Name", "Quantity", "RoomId", "RoomSerialNumber" },
                values: new object[,]
                {
                    { "81", "Equipment", "19", "Syringe", 100, "102", "102" },
                    { "78", "Equipment", "16", "Table", 6, "104", "104" },
                    { "83", "Equipment", "21", "Mask", 30, "104", "104" },
                    { "85", "Equipment", "23", "Gloves", 30, "105", "105" }
                });

            migrationBuilder.InsertData(
                table: "Secretary",
                columns: new[] { "SerialNumber", "AddressSerialNumber", "Contact", "DateOfBirth", "Email", "Id", "Name", "Password", "Surname" },
                values: new object[] { "123a", "200001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "111", "Marko", "123", "Markovic" });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CitySerialNumber",
                table: "Address",
                column: "CitySerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountrySerialNumber",
                table: "City",
                column: "CountrySerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticReferral_DiagnosticTypeSerialNumber",
                table: "DiagnosticReferral",
                column: "DiagnosticTypeSerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_PatientSerialNumber",
                table: "Equipment",
                column: "PatientSerialNumber");

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
                name: "IX_Patient_PhysicianSerialNumber",
                table: "Patient",
                column: "PhysicianSerialNumber");

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
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "EquipmentRelocations");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "MedicineManufacturer");

            migrationBuilder.DropTable(
                name: "MedicineType");

            migrationBuilder.DropTable(
                name: "PhysicianSpecialization");

            migrationBuilder.DropTable(
                name: "PrescriptionMedicineDosage");

            migrationBuilder.DropTable(
                name: "ProcedureEquipment");

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
                name: "Specialization");

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
