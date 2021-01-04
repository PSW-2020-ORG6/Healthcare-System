using Microsoft.EntityFrameworkCore;
using System;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Blog;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Survey;
using HealthClinicBackend.Backend.Model.Util;

namespace WebApplication.Backend.Model
{
    public class UtilDbContext : DbContext
    {
        public UtilDbContext(DbContextOptions<UtilDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<AdditionalDocument>();
            QuestionCreation(modelBuilder);
            ReportCreation(modelBuilder);
            FeedbackCreation(modelBuilder);
            BuildingCreation(modelBuilder);
            EquipmentCreation(modelBuilder);
            RoomCreation(modelBuilder);
            MedicineTypeCreation(modelBuilder);
            PatientCreation(modelBuilder);
            AddressCreation(modelBuilder);
            ProcedureTypeEquipmentUsageCreation(modelBuilder);
            SpecializationCreation(modelBuilder);
            SurveyCreation(modelBuilder);
            FloorCreation(modelBuilder);
            RoomTypeCreation(modelBuilder);
            MedicineManufacturerCreation(modelBuilder);
            MedicineCreation(modelBuilder);
            AppointmentCreation(modelBuilder);
            ProcedureTypeCreation(modelBuilder);
            TimeIntervalCreation(modelBuilder);
            PhysicianCreation(modelBuilder);
            BedCreation(modelBuilder);
        }

        private static void FeedbackCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Feedback>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback {PatientId = "0001", Text = "super", Date = new DateTime(2016, 11, 18), Approved = true},
                new Feedback {PatientId = "0001", Text = "onako", Date = new DateTime(2015, 5, 18), Approved = false},
                new Feedback
                    {PatientId = "0002", Text = "moze bolje", Date = new DateTime(2018, 4, 8), Approved = true},
                new Feedback {PatientId = "0003", Text = "dobro", Date = new DateTime(2019, 3, 18), Approved = false},
                new Feedback {PatientId = "0007", Text = "nikako", Date = new DateTime(2019, 1, 10), Approved = true},
                new Feedback
                    {PatientId = "0008", Text = "sve pohvale", Date = new DateTime(2019, 12, 11), Approved = false},
                new Feedback
                    {PatientId = "00010", Text = "usluga na nivou", Date = new DateTime(2020, 3, 18), Approved = true},
                new Feedback {PatientId = "0004", Text = "ok", Date = new DateTime(2018, 1, 18), Approved = false});
        }

        private static void ReportCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>().HasKey(o => o.SerialNumber);
        }

        private static void RoomCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Room>().Ignore(o => o.RoomType);
            modelBuilder.Entity<Room>().Ignore(o => o.Equipment);
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    SerialNumber = "101", Name = "Examination room 101", Id = 101, FloorSerialNumber = "1001",
                    BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000003", Row = 0, Column = 0, RowSpan = 3,
                    ColumnSpan = 5, Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "102", Name = "Examination room 102", Id = 102, FloorSerialNumber = "1001",
                    BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000003", Row = 0, Column = 10,
                    RowSpan = 2, ColumnSpan = 4, Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "103", Name = "Store room 103", Id = 103, FloorSerialNumber = "1001",
                    BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000002", Row = 0, Column = 5, RowSpan = 2,
                    ColumnSpan = 3, Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "104", Name = "Examination room 104", Id = 104, FloorSerialNumber = "1001",
                    BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000003", Row = 0, Column = 14,
                    RowSpan = 3, ColumnSpan = 5, Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "105", Name = "Store room 105", Id = 105, FloorSerialNumber = "1001",
                    BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000002", Row = 10, Column = 9,
                    RowSpan = 2, ColumnSpan = 5, Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "106", Name = "Operation room 106", Id = 106, FloorSerialNumber = "1002",
                    BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000001", Row = 0, Column = 0, RowSpan = 4,
                    ColumnSpan = 7, Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "107", Name = "Operation room 107", Id = 107, FloorSerialNumber = "1002",
                    BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000001", Row = 8, Column = 0, RowSpan = 4,
                    ColumnSpan = 7, Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "108", Name = "Store room 108", Id = 108, FloorSerialNumber = "1002",
                    BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000002", Row = 0, Column = 10,
                    RowSpan = 2, ColumnSpan = 3, Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "109", Name = "Examination room 109", Id = 109, FloorSerialNumber = "1003",
                    BuildingSerialNumber = "10002", RoomTypeSerialNumber = "10000003", Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "110", Name = "Operation room 110", Id = 110, FloorSerialNumber = "1003",
                    BuildingSerialNumber = "10002", RoomTypeSerialNumber = "10000001", Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "111", Name = "Examination room 111", Id = 111, FloorSerialNumber = "1003",
                    BuildingSerialNumber = "10002", RoomTypeSerialNumber = "10000003", Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "112", Name = "Store room 112", Id = 112, FloorSerialNumber = "1003",
                    BuildingSerialNumber = "10002", RoomTypeSerialNumber = "10000002", Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "113", Name = "Examination room 113", Id = 113, FloorSerialNumber = "1003",
                    BuildingSerialNumber = "10002", RoomTypeSerialNumber = "10000003", Style = "RoomButtonStyle"
                },
                new Room
                {
                    SerialNumber = "114", Name = "Examination room 114", Id = 114, FloorSerialNumber = "1003",
                    BuildingSerialNumber = "10002", RoomTypeSerialNumber = "10000003", Style = "RoomButtonStyle"
                }
            );
        }

        private static void MedicineManufacturerCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineManufacturer>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<MedicineManufacturer>().HasData(
                new MedicineManufacturer {SerialNumber = "1", Name = "manufacturer1"},
                new MedicineManufacturer {SerialNumber = "2", Name = "manufacturer2"}
            );
        }

        private static void MedicineTypeCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineType>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<MedicineType>().HasData(
                new MedicineType {SerialNumber = "11", Type = "Antibiotic"},
                new MedicineType {SerialNumber = "12", Type = "Brufen"}
            );
        }

        private static void MedicineCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Medicine>().Ignore(o => o.MedicineManufacturer);
            modelBuilder.Entity<Medicine>().Ignore(o => o.MedicineType);
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine
                {
                    SerialNumber = "21", CopyrightName = "Brufen", GenericName = "Brufen",
                    MedicineManufacturerSerialNumber = "1", MedicineTypeSerialNumber = "11"
                },
                new Medicine
                {
                    SerialNumber = "22", CopyrightName = "Probiotic", GenericName = "Probiotic",
                    MedicineManufacturerSerialNumber = "2", MedicineTypeSerialNumber = "12"
                }
            );
        }

        private static void PatientCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasAlternateKey(o => o.Id);
            modelBuilder.Entity<Patient>().Ignore(o => o.Address);
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Name = "Jelena", Surname = "Tanjic", Id = "0002", DateOfBirth = new DateTime(2017, 1, 18),
                    Contact = "kontakt", Password = "sifra", Address = new Address("neka adresa"), ParentName = "otac",
                    Gender = "Zensko", Email = "email", Guest = true
                },
                new Patient
                {
                    Name = "Sara", Surname = "Milic", Id = "0003", DateOfBirth = new DateTime(2018, 1, 18),
                    Contact = "kontaktMica", Password = "sifraMica", Address = new Address("neka adresaMica"),
                    ParentName = "mama", Gender = "Zensko", Email = "emailMica", Guest = true
                }
            );
        }

        private static void SurveyCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>().HasKey(o => o.SerialNumber);
        }

        private static void QuestionCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasKey(o => o.Id);
            modelBuilder.Entity<Question>().HasData(
                new Question {Id = 1, QuestionText = "The doctor is welcoming and gentle?"},
                new Question
                    {Id = 2, QuestionText = "The doctor answered all of your questions in an understandable manner?"},
                new Question {Id = 3, QuestionText = "The doctor takes care of you in a professional manner?"},
                new Question {Id = 4, QuestionText = "Would you have the procedure done again by this doctor?"},
                new Question
                {
                    Id = 5,
                    QuestionText =
                        "The personal manner(courtosy,respect,sensitivity,friendliness) of the nurses and other support staff?"
                },
                new Question
                    {Id = 6, QuestionText = "The nursees answered all of your questions in an understandable manner?"},
                new Question {Id = 7, QuestionText = "Orientation given to warn setup"},
                new Question {Id = 8, QuestionText = "The nurse gave you good discharge instructions"},
                new Question {Id = 9, QuestionText = "The nurse was concern for you?"},
                new Question {Id = 10, QuestionText = "The comfort and cleanliness of the facility"},
                new Question {Id = 11, QuestionText = "Comfort level within the procedure room?"},
                new Question {Id = 12, QuestionText = "Conditions of the rooms(temperature,comfort,silence)"},
                new Question {Id = 13, QuestionText = "General impression of the ambient atmosphere"},
                new Question {Id = 14, QuestionText = "Do you think the clinic has the necessary equipment"},
                new Question {Id = 15, QuestionText = "Do you think the clinic's farmacy has the necessary drugs?"},
                new Question
                {
                    Id = 16,
                    QuestionText =
                        "Do you think that the hospital should have more modern equipment than the current one"
                },
                new Question {Id = 17, QuestionText = "Did you noticed broken or damaged equipment in the hospital"},
                new Question
                {
                    Id = 18,
                    QuestionText = "The doctor prescribed medications that I could buy at the clinic's pharmacy"
                },
                new Question {Id = 19, QuestionText = "Did you found it easy to use our website?"},
                new Question
                    {Id = 20, QuestionText = "Did you have found all the necessary information on our website?"},
                new Question
                    {Id = 21, QuestionText = "Overall, are you satisfied with the care you received in this facility?"},
                new Question {Id = 22, QuestionText = "Would you come to this institution again"},
                new Question {Id = 23, QuestionText = ">Would you recommend this facility to your friends and family"}
            );
        }

        private static void BuildingCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Building>().Ignore(o => o.Floors);
            modelBuilder.Entity<Building>().HasData(
                new Building
                {
                    SerialNumber = "10001", Name = "Cardiology", Color = "Orange", Row = 5, Column = 1,
                    Style = "TriangleBuildingButtonStyle"
                },
                new Building
                {
                    SerialNumber = "10002", Name = "Orthopedy", Color = "Red", Row = 5, Column = 3,
                    Style = "UBuildingButtonStyle"
                }
            );
        }

        private static void FloorCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Floor>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Floor>().Ignore(o => o.Rooms);
            modelBuilder.Entity<Floor>().HasData(
                new Floor {SerialNumber = "1001", Name = "Floor1", BuildingSerialNumber = "10001"},
                new Floor {SerialNumber = "1002", Name = "Floor2", BuildingSerialNumber = "10001"},
                new Floor {SerialNumber = "1003", Name = "Floor1", BuildingSerialNumber = "10002"}
            );
        }

        private static void EquipmentCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().HasKey(o => o.Id);
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment
                {
                    SerialNumber = "73", RoomId = "101", Name = "Bed", Id = "11", BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1001", RoomSerialNumber = "101"
                },
                new Equipment
                {
                    SerialNumber = "74", RoomId = "102", Name = "Bed", Id = "12", BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1001", RoomSerialNumber = "101"
                },
                new Equipment
                {
                    SerialNumber = "75", RoomId = "103", Name = "Bed", Id = "13", BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1001", RoomSerialNumber = "101"
                },
                new Equipment
                {
                    SerialNumber = "76", RoomId = "101", Name = "Bed", Id = "14", BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1001", RoomSerialNumber = "101"
                },
                new Equipment
                {
                    SerialNumber = "77", RoomId = "102", Name = "Bed", Id = "15", BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1002", RoomSerialNumber = "106"
                },
                new Equipment
                {
                    SerialNumber = "78", RoomId = "104", Name = "Table", Id = "16", BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1002", RoomSerialNumber = "106"
                },
                new Equipment
                {
                    SerialNumber = "79", RoomId = "111", Name = "Table", Id = "17", BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1002", RoomSerialNumber = "107"
                },
                new Equipment
                {
                    SerialNumber = "80", RoomId = "111", Name = "Table", Id = "18", BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1002", RoomSerialNumber = "107"
                },
                new Equipment
                {
                    SerialNumber = "81", RoomId = "112", Name = "Bed", Id = "19", BuildingSerialNumber = "10002",
                    FloorSerialNumber = "1003", RoomSerialNumber = "114"
                },
                new Equipment
                {
                    SerialNumber = "82", RoomId = "112", Name = "Bed", Id = "20", BuildingSerialNumber = "10002",
                    FloorSerialNumber = "1003", RoomSerialNumber = "114"
                }
            );
        }

        private static void RoomTypeCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomType>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType {SerialNumber = "10000001", Name = "Operation room"},
                new RoomType {SerialNumber = "10000002", Name = "Store room"},
                new RoomType {SerialNumber = "10000003", Name = "Examination room"}
            );
        }

        private static void AddressCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Address>().HasData(
                new Address {SerialNumber = "200001", Street = "Njegoševa 45"},
                new Address {SerialNumber = "200002", Street = "Njegoševa 46"}
            );
        }

        private static void ProcedureTypeCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcedureType>().HasData(
                new ProcedureType
                    {SerialNumber = "300001", Name = "Operation on patient 0002", EstimatedTimeInMinutes = 50},
                new ProcedureType {SerialNumber = "300002", Name = "Check on patient 0002", EstimatedTimeInMinutes = 78}
            );
            modelBuilder.Entity<ProcedureType>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<ProcedureType>().Ignore(o => o.Specialization);
            modelBuilder.Entity<ProcedureType>().Ignore(o => o.RequiredEquipment);
        }

        private static void ProcedureTypeEquipmentUsageCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcedureTypeEquipmentUsage>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<ProcedureTypeEquipmentUsage>().Ignore(o => o.ProcedureType);
            modelBuilder.Entity<ProcedureTypeEquipmentUsage>().Ignore(o => o.Equipment);
            modelBuilder.Entity<ProcedureTypeEquipmentUsage>().HasData(
                new ProcedureTypeEquipmentUsage
                    {SerialNumber = "400001", ProcedureTypeSerialNumber = "300001", EquipmentSerialNumber = "81"},
                new ProcedureTypeEquipmentUsage
                    {SerialNumber = "400002", ProcedureTypeSerialNumber = "300002", EquipmentSerialNumber = "82"}
            );
        }

        private static void TimeIntervalCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeInterval>().HasKey(o => o.Id);
            modelBuilder.Entity<TimeInterval>().HasData(
                new TimeInterval {Start = DateTime.Now, End = DateTime.Now, Id = "600001"},
                new TimeInterval {Start = DateTime.Now, End = DateTime.Now, Id = "600002"}
            );
        }

        private static void SpecializationCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialization>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Specialization>().HasData(
                new Specialization {SerialNumber = "500001", Name = "Neurosurgeon "},
                new Specialization {SerialNumber = "500002", Name = "Family doctor"}
            );
        }

        private static void PhysicianCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Physician>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Physician>().HasAlternateKey(o => o.Id);
            modelBuilder.Entity<Physician>().Ignore(o => o.Address);
            modelBuilder.Entity<Physician>().Ignore(o => o.Specialization);
            modelBuilder.Entity<Physician>().Ignore(o => o.VacationTime);
            modelBuilder.Entity<Physician>().Ignore(o => o.WorkSchedule);
           // modelBuilder.Entity<Physician>().Ignore(o => o.AllSpecializations);
            modelBuilder.Entity<Physician>().HasData(
                new Physician
                {
                    SerialNumber = "600001", Name = "Gojko", Surname = "Simic", Id = "600001",
                    DateOfBirth = new DateTime(1975, 11, 11), Contact = "Simic kontakt", Email = "simic@gmail.com",
                    Password = "sifraSimic24dsf1", AddressSerialNumber = "200001"
                },
                new Physician
                {
                    SerialNumber = "600002", Name = "Klara", Surname = "Dicic", Id = "600002",
                    DateOfBirth = new DateTime(1985, 4, 25), Contact = "Dicic kontakt", Email = "dicic@gmail.com",
                    Password = "sifraDicic98754", AddressSerialNumber = "200002"
                }
            );
        }

        private static void AppointmentCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Appointment>().Ignore(o => o.Date);
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment {SerialNumber = "200001", Urgency = true},
                new Appointment {SerialNumber = "200002", Urgency = false}
            );
        }

        private static void BedCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bed>().HasData(
                new Bed
                {
                    SerialNumber = "100001",
                    BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1001",
                    RoomSerialNumber = "101",
                    Name = "Bed 1",
                    PatientSerialNumber = "0002",
                    Id = "100001",
                    RoomId = "101"
                },
                new Bed
                {
                    SerialNumber = "100002",
                    BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1001",
                    RoomSerialNumber = "101",
                    Name = "Bed 2",
                    PatientSerialNumber = "0003",
                    Id = "100002",
                    RoomId = "102"
                },
                new Bed
                {
                    SerialNumber = "100003",
                    BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1001",
                    RoomSerialNumber = "102",
                    Name = "Bed 3",
                    PatientSerialNumber = null,
                    Id = "100003",
                    RoomId = "103"
                }
            );
        }
    }
}