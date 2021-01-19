using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Blog;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Model.PharmacySupport;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Survey;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql.RelationHelpers;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class HealthCareSystemDbContext : DbContext
    {
        //private const string CONNECTION_STRING =
        //    "User ID =postgres;Password=root;Server=localhost;Port=5432;Database=healthcare-system-db;Integrated Security=true;Pooling=true;";

        public DbSet<Address> Address { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Physician> Physician { get; set; }
        public DbSet<PhysicianSpecialization> PhysicianSpecialization { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Secretary> Secretary { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentRelocation> EquipmentRelocations { get; set; }
        public DbSet<RoomRenovation> RoomRenovations { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<ProcedureEquipment> ProcedureEquipment { get; set; }
        public DbSet<Bed> Bed { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Floor> Floor { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<MedicineManufacturer> MedicineManufacturer { get; set; }
        public DbSet<MedicineType> MedicineType { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Rejection> Rejection { get; set; }
        public DbSet<DiagnosticType> DiagnosticType { get; set; }
        public DbSet<DiagnosticReferral> DiagnosticReferral { get; set; }
        public DbSet<FollowUp> FollowUp { get; set; }
        public DbSet<SpecialistReferral> SpecialistReferral { get; set; }
        public DbSet<MedicineDosage> MedicineDosage { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PrescriptionMedicineDosage> PrescriptionMedicineDosage { get; set; }
        public DbSet<ReportPrescription> ReportPrescription { get; set; }
        public DbSet<ReportDiagnosticReferral> ReportDiagnosticReferral { get; set; }
        public DbSet<ReportFollowUp> ReportFollowUp { get; set; }
        public DbSet<ReportSpecialistReferral> ReportSpecialistReferral { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<ProcedureType> ProcedureType { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<ActionAndBenefitMessage> ActionAndBenefitMessage { get; set; }
        public HealthCareSystemDbContext(DbContextOptions<HealthCareSystemDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(CONNECTION_STRING);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Medicine>()
                .HasOne(m => m.MedicineManufacturer) // Medicine has one Medicine Manufacturer
                .WithMany(); // Medicine Manufacturer has many Medicine but doesn't reference them

            modelBuilder.Entity<Medicine>()
                .HasOne(m => m.MedicineType)
                .WithMany();

            modelBuilder.Entity<Rejection>()
                .HasOne(r => r.Medicine)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Building>()
                .HasMany(b => b.Floors) // Building has many references to Floors
                .WithOne() // Floors have one reference to Building but doesn't reference it
                .OnDelete(DeleteBehavior.Cascade); // On deleting one building all the referenced floors are deleted

            modelBuilder.Entity<Floor>()
                .HasMany(f => f.Rooms) // Floor has many Rooms
                .WithOne() // Room has one Floor but doesn't reference it
                .OnDelete(DeleteBehavior.Cascade); // When Floor is deleted, so are all the referenced Rooms

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Equipment) // Room has many Equipments
                .WithOne(); // Equipment 'has' one Room but doesn't reference it

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Beds) // Room has many Beds
                .WithOne(); // Bed 'has' one Room but doesn't reference it

            modelBuilder.Entity<Room>()
                .HasOne(r => r.RoomType) // Room has RoomType
                .WithMany(); // RoomType can have many Rooms but doesn't reference them

            modelBuilder.Entity<City>().HasOne(c => c.Country).WithMany();
            modelBuilder.Entity<Address>().HasOne(a => a.City).WithMany();

            modelBuilder.Entity<Physician>().HasOne(p => p.Address).WithMany();
            modelBuilder.Entity<Patient>().HasOne(p => p.Address).WithMany();
            modelBuilder.Entity<Secretary>().HasOne(s => s.Address).WithMany();

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany();
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.ProcedureType)
                .WithMany();
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Physician)
                .WithMany();
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Room)
                .WithMany();

            modelBuilder.Entity<RoomRenovation>()
                .OwnsOne(r => r.TimeInterval);

            // Relation helpers are used for many-to-many relations
            modelBuilder.Entity<PhysicianSpecialization>().HasKey(o => new { o.PhysicianSerialNumber, o.SpecializationSerialNumber });
            modelBuilder.Entity<PhysicianSpecialization>()
                .HasOne(ps => ps.Physician)
                .WithMany();
            modelBuilder.Entity<PhysicianSpecialization>()
                .HasOne(ps => ps.Specialization)
                .WithMany();

            modelBuilder.Entity<ProcedureEquipment>().HasKey(o => new { o.ProcedureTypeSerialNumber, o.EquipmentSerialNumber });
            modelBuilder.Entity<ProcedureEquipment>()
                .HasOne(pe => pe.ProcedureType)
                .WithMany();
            modelBuilder.Entity<ProcedureEquipment>()
                .HasOne(pe => pe.Equipment)
                .WithMany();

            modelBuilder.Entity<DiagnosticReferral>()
                .HasKey(x => x.SerialNumber);
            modelBuilder.Entity<SpecialistReferral>()
                .HasKey(x => x.SerialNumber);
            modelBuilder.Entity<FollowUp>()
                .HasKey(x => x.SerialNumber);
            modelBuilder.Entity<Prescription>()
                .HasKey(x => x.SerialNumber);
            modelBuilder.Entity<Admin>()
              .HasKey(x => x.Email);

            modelBuilder.Entity<DiagnosticReferral>()
                .HasOne(dr => dr.DiagnosticType)
                .WithMany();
            modelBuilder.Entity<FollowUp>()
                .HasOne(fu => fu.Physician)
                .WithMany();
            modelBuilder.Entity<SpecialistReferral>()
                .HasOne(sr => sr.Physician)
                .WithMany();
            modelBuilder.Entity<SpecialistReferral>()
                .HasOne(sr => sr.ProcedureType)
                .WithMany();
            modelBuilder.Entity<MedicineDosage>()
                .HasOne(md => md.Medicine)
                .WithMany();

            // Relation helpers are used for many-to-many relations
            modelBuilder.Entity<PrescriptionMedicineDosage>()
                .HasOne(pmd => pmd.Prescription)
                .WithMany();
            modelBuilder.Entity<PrescriptionMedicineDosage>()
                .HasOne(pmd => pmd.MedicineDosage)
                .WithMany();

            modelBuilder.Entity<ReportPrescription>()
                .HasOne(rp => rp.Report)
                .WithMany();
            modelBuilder.Entity<ReportPrescription>()
                .HasOne(rp => rp.Prescription)
                .WithOne();

            modelBuilder.Entity<ReportDiagnosticReferral>()
                .HasOne(x => x.Report)
                .WithMany();
            modelBuilder.Entity<ReportDiagnosticReferral>()
                .HasOne(x => x.DiagnosticReferral)
                .WithOne();

            modelBuilder.Entity<ReportSpecialistReferral>()
                .HasOne(x => x.Report)
                .WithMany();
            modelBuilder.Entity<ReportSpecialistReferral>()
                .HasOne(x => x.SpecialistReferral)
                .WithOne();

            modelBuilder.Entity<ReportFollowUp>()
                .HasOne(x => x.Report)
                .WithMany();
            modelBuilder.Entity<ReportFollowUp>()
                .HasOne(x => x.FollowUp)
                .WithOne();

            modelBuilder.Entity<ActionAndBenefitMessage>()
                .HasAlternateKey(abm => abm.ActionID);

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
            //            SurveyCreation(modelBuilder);
            FloorCreation(modelBuilder);
            RoomTypeCreation(modelBuilder);
            MedicineManufacturerCreation(modelBuilder);
            MedicineCreation(modelBuilder);
            AppointmentCreation(modelBuilder);
            ProcedureTypeCreation(modelBuilder);
            PhysicianCreation(modelBuilder);
            BedCreation(modelBuilder);
            SecretaryCreation(modelBuilder);
            PhysicianSpecializationCreation(modelBuilder);
            ProcedureEquipmentCreation(modelBuilder);
            EquipmentRelocationsCreation(modelBuilder);
            RoomRenovation(modelBuilder);
        }

        private void RoomRenovation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomRenovation>().HasKey(r => r.SerialNumber);
            modelBuilder.Entity<RoomRenovation>().Ignore(r => r.RenovatedRoom);
            modelBuilder.Entity<RoomRenovation>().Ignore(r => r.RenovatingRooms);
        }

        private static void EquipmentRelocationsCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipmentRelocation>().HasKey(r => r.SerialNumber);
            modelBuilder.Entity<EquipmentRelocation>().Ignore(e => e.equipment);
            modelBuilder.Entity<Appointment>().Ignore(o => o.Room);
        }
        private static void SecretaryCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Secretary>()
                .HasKey(r => r.SerialNumber);
            modelBuilder.Entity<Secretary>().HasData(
                new Secretary
                {
                    Name = "Marko",
                    Surname = "Markovic",
                    SerialNumber = "123a",
                    AddressSerialNumber = "200001",
                    Id = "111",
                    Password = "123"
                }
                );
        }

        private static void FeedbackCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Feedback>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { PatientId = "0001", Text = "super", Date = new DateTime(2016, 11, 18), Approved = true },
                new Feedback { PatientId = "0001", Text = "onako", Date = new DateTime(2015, 5, 18), Approved = false },
                new Feedback
                { PatientId = "0002", Text = "moze bolje", Date = new DateTime(2018, 4, 8), Approved = true },
                new Feedback { PatientId = "0003", Text = "dobro", Date = new DateTime(2019, 3, 18), Approved = false },
                new Feedback { PatientId = "0007", Text = "nikako", Date = new DateTime(2019, 1, 10), Approved = true },
                new Feedback
                { PatientId = "0008", Text = "sve pohvale", Date = new DateTime(2019, 12, 11), Approved = false },
                new Feedback
                { PatientId = "00010", Text = "usluga na nivou", Date = new DateTime(2020, 3, 18), Approved = true },
                new Feedback { PatientId = "0004", Text = "ok", Date = new DateTime(2018, 1, 18), Approved = false });
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
            modelBuilder.Entity<Room>().Ignore(o => o.Beds);
            modelBuilder.Entity<Room>().Ignore(o => o.Medicines);
            modelBuilder.Entity<Room>().Property(o => o.RoomRenovationSerialNumber).HasDefaultValue(null);
            modelBuilder.Entity<Room>().Property(o => o.IsWaitingToBeRenovated).HasDefaultValue(false);
            modelBuilder.Entity<Room>().Property(o => o.IsBeingRenovated).HasDefaultValue(false);

            modelBuilder.Entity<Room>()
               .Property(r => r.Name)
               .HasField("_name");
            modelBuilder.Entity<Room>()
               .Property(r => r.Id)
               .HasField("_id");
            modelBuilder.Entity<Room>()
               .Property(r => r.FloorSerialNumber)
               .HasField("_floorSerialNumber");
            modelBuilder.Entity<Room>()
               .Property(r => r.RoomTypeSerialNumber)
               .HasField("_roomTypeSerialNumber");
            modelBuilder.Entity<Room>()
               .Property(r => r.Style)
               .HasField("_style");
            modelBuilder.Entity<Room>()
               .Property(r => r.BottomDoorVisible)
               .HasField("_bottomDoorVisible");
            modelBuilder.Entity<Room>()
               .Property(r => r.RightDoorVisible)
               .HasField("_rightDoorVisible");
            modelBuilder.Entity<Room>()
                .Property(r => r.LeftDoorVisible)
                .HasField("_leftDoorVisible");
            modelBuilder.Entity<Room>()
               .Property(r => r.TopDoorVisible)
               .HasField("_topDoorVisible");
            modelBuilder.Entity<Room>()
               .Property(r => r.RoomRenovationSerialNumber)
               .HasField("_roomRenovationSerialNumber");

            modelBuilder.Entity<Room>().OwnsOne(r => r.Position).HasData(
               new
               {
                   RoomSerialNumber = "101",
                   Row = 6,
                   Column = 14,
                   RowSpan = 3,
                   ColumnSpan = 4
               },
               new
               {
                   RoomSerialNumber = "102",
                   Row = 0,
                   Column = 10,
                   RowSpan = 2,
                   ColumnSpan = 4
               },
                new
                {
                    RoomSerialNumber = "103",
                    Row = 0,
                    Column = 5,
                    RowSpan = 2,
                    ColumnSpan = 3
                },
               new
               {
                   RoomSerialNumber = "104",
                   Row = 0,
                   Column = 14,
                   RowSpan = 3,
                   ColumnSpan = 5
               },
               new
               {
                   RoomSerialNumber = "105",
                   Row = 12,
                   Column = 17,
                   RowSpan = 1,
                   ColumnSpan = 1
               }
            );

            Room room1 = new Room("101", "Examination room 101", 101, "1001",
                "10000003", "RoomButtonStyle", 0, 0, 2, 2);
            Room room2 = new Room("102", "Examination room 102", 102, "1001",
                "10000003", "RoomButtonStyle", 0, 2, 2, 2);
            Room room3 = new Room("103", "Store room 103", 103, "1001",
                "10000002", "RoomButtonStyle", 0, 2, 2, 2);
            Room room4 = new Room("104", "Examination room 104", 104, "1001",
                "10000003", "RoomButtonStyle", 0, 2, 2, 2);
            Room room5 = new Room("105", "Store room 105", 105, "1001",
                "10000002", "RoomButtonStyle", 2, 0, 0, 0);

            modelBuilder.Entity<Room>().HasData(room1, room2, room3, room4, room5);
        }

        private static void MedicineManufacturerCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineManufacturer>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<MedicineManufacturer>().HasData(
                new MedicineManufacturer { SerialNumber = "1", Name = "manufacturer1" },
                new MedicineManufacturer { SerialNumber = "2", Name = "manufacturer2" }
            );
        }

        private static void MedicineTypeCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineType>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<MedicineType>().HasData(
                new MedicineType { SerialNumber = "11", Type = "Antibiotic" },
                new MedicineType { SerialNumber = "12", Type = "Brufen" }
            );
        }

        private static void MedicineCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Medicine>().Ignore(o => o.MedicineManufacturer);
            modelBuilder.Entity<Medicine>().Ignore(o => o.MedicineType);
            modelBuilder.Entity<Medicine>().Property(o => o.Quantity).HasDefaultValue(1);
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine
                {
                    SerialNumber = "21",
                    CopyrightName = "Brufen",
                    GenericName = "Brufen",
                    MedicineManufacturerSerialNumber = "1",
                    MedicineTypeSerialNumber = "11",
                    RoomSerialNumber = "101",
                    Quantity = 50
                },
                new Medicine
                {
                    SerialNumber = "22",
                    CopyrightName = "Probiotic",
                    GenericName = "Probiotic",
                    MedicineManufacturerSerialNumber = "2",
                    MedicineTypeSerialNumber = "12",
                    RoomSerialNumber = "102",
                    Quantity = 30
                },
                new Medicine
                {
                    SerialNumber = "23",
                    CopyrightName = "Aspirin",
                    GenericName = "Aspirin",
                    MedicineManufacturerSerialNumber = "2",
                    MedicineTypeSerialNumber = "12",
                    RoomSerialNumber = "103",
                    Quantity = 150
                }
            );
        }

        private static void PatientCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Patient>().HasAlternateKey(o => o.Id);
            modelBuilder.Entity<Patient>().Ignore(o => o.Address);
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Name = "Jelena",
                    Surname = "Tanjic",
                    SerialNumber = "0002",
                    Id = "0002",
                    DateOfBirth = new DateTime(2017, 1, 18),
                    Contact = "kontakt",
                    Password = "sifra",
                    Address = new Address("neka adresa"),
                    ParentName = "otac",
                    Gender = "Zensko",
                    Email = "email",
                    Guest = true
                },
                new Patient
                {
                    Name = "Sara",
                    Surname = "Milic",
                    SerialNumber = "0003",
                    Id = "0003",
                    DateOfBirth = new DateTime(2018, 1, 18),
                    Contact = "kontaktMica",
                    Password = "sifraMica",
                    Address = new Address("neka adresaMica"),
                    ParentName = "mama",
                    Gender = "Zensko",
                    Email = "emailMica",
                    Guest = true
                }
            );
        }

        private static void QuestionCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasKey(o => o.Id);
            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, QuestionText = "The doctor is welcoming and gentle?" },
                new Question
                { Id = 2, QuestionText = "The doctor answered all of your questions in an understandable manner?" },
                new Question { Id = 3, QuestionText = "The doctor takes care of you in a professional manner?" },
                new Question { Id = 4, QuestionText = "Would you have the procedure done again by this doctor?" },
                new Question
                {
                    Id = 5,
                    QuestionText =
                        "The personal manner(courtosy,respect,sensitivity,friendliness) of the nurses and other support staff?"
                },
                new Question
                { Id = 6, QuestionText = "The nursees answered all of your questions in an understandable manner?" },
                new Question { Id = 7, QuestionText = "Orientation given to warn setup" },
                new Question { Id = 8, QuestionText = "The nurse gave you good discharge instructions" },
                new Question { Id = 9, QuestionText = "The nurse was concern for you?" },
                new Question { Id = 10, QuestionText = "The comfort and cleanliness of the facility" },
                new Question { Id = 11, QuestionText = "Comfort level within the procedure room?" },
                new Question { Id = 12, QuestionText = "Conditions of the rooms(temperature,comfort,silence)" },
                new Question { Id = 13, QuestionText = "General impression of the ambient atmosphere" },
                new Question { Id = 14, QuestionText = "Do you think the clinic has the necessary equipment" },
                new Question { Id = 15, QuestionText = "Do you think the clinic's farmacy has the necessary drugs?" },
                new Question
                {
                    Id = 16,
                    QuestionText =
                        "Do you think that the hospital should have more modern equipment than the current one"
                },
                new Question { Id = 17, QuestionText = "Did you noticed broken or damaged equipment in the hospital" },
                new Question
                {
                    Id = 18,
                    QuestionText = "The doctor prescribed medications that I could buy at the clinic's pharmacy"
                },
                new Question { Id = 19, QuestionText = "Did you found it easy to use our website?" },
                new Question
                { Id = 20, QuestionText = "Did you have found all the necessary information on our website?" },
                new Question
                { Id = 21, QuestionText = "Overall, are you satisfied with the care you received in this facility?" },
                new Question { Id = 22, QuestionText = "Would you come to this institution again" },
                new Question { Id = 23, QuestionText = ">Would you recommend this facility to your friends and family" }
            );
        }

        private static void BuildingCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Building>().Ignore(o => o.Floors);

            modelBuilder.Entity<Building>()
               .Property(b => b.Name)
               .HasField("_name");
            modelBuilder.Entity<Building>()
                .Property(b => b.Color)
                .HasField("_color");
            modelBuilder.Entity<Building>()
                .Property(b => b.Row)
                .HasField("_row");
            modelBuilder.Entity<Building>()
                .Property(b => b.Column)
                .HasField("_column");
            modelBuilder.Entity<Building>()
                .Property(b => b.Style)
                .HasField("_style");

            Building building1 = new Building("10001", "Cardiology", "Orange", 5, 1, "TriangleBuildingButtonStyle");
            Building building2 = new Building("10002", "Orthopedy", "Red", 5, 3, "UBuildingButtonStyle");

            modelBuilder.Entity<Building>().HasData(building1, building2);
        }

        private static void FloorCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Floor>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Floor>().Ignore(o => o.Rooms);

            modelBuilder.Entity<Floor>()
               .Property(f => f.Name)
               .HasField("_name");
            modelBuilder.Entity<Floor>()
               .Property(f => f.BuildingSerialNumber)
               .HasField("_buildingSerialNumber");

            Floor floor1 = new Floor("1001", "Ground floor", "10001");
            Floor floor2 = new Floor("1002", "First floor", "10001");
            Floor floor3 = new Floor("1003", "Ground floor", "10002");
            modelBuilder.Entity<Floor>().HasData(floor1, floor2, floor3);
        }

        private static void EquipmentCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Equipment>().Property(o => o.Quantity).HasDefaultValue(1);
            modelBuilder.Entity<Equipment>().HasData(
                //new Equipment
                new Equipment
                {
                    SerialNumber = "78",
                    RoomId = "104",
                    Name = "Table",
                    Id = "16",
                    RoomSerialNumber = "104",
                    Quantity = 6
                },
                new Equipment
                {
                    SerialNumber = "80",
                    RoomId = "101",
                    Name = "Table",
                    Id = "18",
                    RoomSerialNumber = "101",
                    Quantity = 3
                },
                new Equipment
                {
                    SerialNumber = "81",
                    RoomId = "102",
                    Name = "Syringe",
                    Id = "19",
                    RoomSerialNumber = "102",
                    Quantity = 100
                },
                new Equipment
                {
                    SerialNumber = "83",
                    RoomId = "104",
                    Name = "Mask",
                    Id = "21",
                    RoomSerialNumber = "104",
                    Quantity = 30
                },
                new Equipment
                {
                    SerialNumber = "84",
                    RoomId = "101",
                    Name = "Stethoscope",
                    Id = "22",
                    RoomSerialNumber = "101",
                    Quantity = 10
                },
                new Equipment
                {
                    SerialNumber = "85",
                    RoomId = "105",
                    Name = "Gloves",
                    Id = "23",
                    RoomSerialNumber = "105",
                    Quantity = 30
                }
            );
        }

        private static void RoomTypeCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomType>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType { SerialNumber = "10000001", Name = "Operation room" },
                new RoomType { SerialNumber = "10000002", Name = "Store room" },
                new RoomType { SerialNumber = "10000003", Name = "Examination room" }
            );
        }

        private static void AddressCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Address>().HasData(
                new Address { SerialNumber = "200001", Street = "Njegoševa 45" },
                new Address { SerialNumber = "200002", Street = "Njegoševa 46" }
            );
        }

        private static void ProcedureTypeCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcedureType>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<ProcedureType>().Ignore(o => o.Specialization); //SpecializationSerialNumber is foreign key in procedure type N:1
            modelBuilder.Entity<ProcedureType>().Ignore(o => o.RequiredEquipment);  //new table N:N
            modelBuilder.Entity<ProcedureType>().HasData(
                new ProcedureType { SerialNumber = "300001", Name = "Appointment with neuropsychiatrist", EstimatedTimeInMinutes = 50, SpecializationSerialNumber = "500001" },
                new ProcedureType { SerialNumber = "300002", Name = "Appointment with general practitioner", EstimatedTimeInMinutes = 30, SpecializationSerialNumber = "500004" },
                new ProcedureType { SerialNumber = "300003", Name = "Operation by neurosurgeon ", EstimatedTimeInMinutes = 40, SpecializationSerialNumber = "500002" },
                new ProcedureType { SerialNumber = "300004", Name = "Operation by kneesurgeon", EstimatedTimeInMinutes = 60, SpecializationSerialNumber = "500003" }
            );
        }

        private static void ProcedureTypeEquipmentUsageCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcedureTypeEquipmentUsage>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<ProcedureTypeEquipmentUsage>().Ignore(o => o.ProcedureType);
            modelBuilder.Entity<ProcedureTypeEquipmentUsage>().Ignore(o => o.Equipment);
            modelBuilder.Entity<ProcedureTypeEquipmentUsage>().HasData(
                new ProcedureTypeEquipmentUsage
                { SerialNumber = "400001", ProcedureTypeSerialNumber = "300001", EquipmentSerialNumber = "81" },
                new ProcedureTypeEquipmentUsage
                { SerialNumber = "400002", ProcedureTypeSerialNumber = "300002", EquipmentSerialNumber = "82" }
            );
        }

        private static void SpecializationCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialization>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Specialization>().HasData(
                new Specialization { SerialNumber = "500001", Name = "Neuropsychiatrist " },
                new Specialization { SerialNumber = "500002", Name = "Neurosurgeon " },
                new Specialization { SerialNumber = "500003", Name = "Kneesurgeon " },
                new Specialization { SerialNumber = "500004", Name = "General practitioner" }
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
            //modelBuilder.Entity<Physician>().Ignore(o => o.AllSpecializations);
            modelBuilder.Entity<Physician>().HasData(
                new Physician
                {
                    SerialNumber = "600001",
                    Name = "Gojko",
                    Surname = "Simic",
                    Id = "600001",
                    DateOfBirth = new DateTime(1975, 11, 11),
                    Contact = "Simic kontakt",
                    Email = "simic@gmail.com",
                    Password = "sifraSimic24dsf1",
                    AddressSerialNumber = "200001"
                },
                new Physician
                {
                    SerialNumber = "600002",
                    Name = "Klara",
                    Surname = "Dicic",
                    Id = "600002",
                    DateOfBirth = new DateTime(1985, 4, 25),
                    Contact = "Dicic kontakt",
                    Email = "dicic@gmail.com",
                    Password = "sifraDicic98754",
                    AddressSerialNumber = "200002"
                }
            );
        }

        private static void AppointmentCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Appointment>().Ignore(o => o.Room);
            modelBuilder.Entity<Appointment>().Ignore(o => o.Patient);
            modelBuilder.Entity<Appointment>().OwnsOne(o => o.TimeInterval).HasData(
                new
                {
                    AppointmentSerialNumber = "200001",
                    Start = DateTime.Now,
                    End = DateTime.Now
                },
                new
                {
                    AppointmentSerialNumber = "200002",
                    Start = DateTime.Now,
                    End = DateTime.Now
                }
            );
            modelBuilder.Entity<Appointment>().Ignore(o => o.ProcedureType);
            modelBuilder.Entity<Appointment>().Ignore(o => o.Physician);
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { SerialNumber = "200001", PatientSerialNumber = "0002", PhysicianSerialNumber = "600001", ProcedureTypeSerialnumber = "300001", Date = DateTime.Now, Urgency = true, RoomSerialNumber = "101" },
                new Appointment { SerialNumber = "200002", PatientSerialNumber = "0002", PhysicianSerialNumber = "600001", ProcedureTypeSerialnumber = "300002", Date = DateTime.Now, Urgency = false, RoomSerialNumber = "102" }
            );
        }

        private static void BedCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bed>().Property(o => o.Quantity).HasDefaultValue(1);
            modelBuilder.Entity<Bed>().Ignore(o => o.IsOccupied);

            modelBuilder.Entity<Bed>().HasData(
                new Bed
                {
                    SerialNumber = "100001",
                    //BuildingSerialNumber = "10001",
                    //FloorSerialNumber = "1001",
                    RoomSerialNumber = "101",
                    Name = "Bed 1",
                    PatientSerialNumber = "0002",
                    Id = "100001",
                    RoomId = "101"
                },
                new Bed
                {
                    SerialNumber = "100002",
                    //BuildingSerialNumber = "10001",
                    //FloorSerialNumber = "1001",
                    RoomSerialNumber = "101",
                    Name = "Bed 2",
                    PatientSerialNumber = "0003",
                    Id = "100002",
                    RoomId = "102"
                },
                new Bed
                {
                    SerialNumber = "100003",
                    //BuildingSerialNumber = "10001",
                    //FloorSerialNumber = "1001",
                    RoomSerialNumber = "102",
                    Name = "Bed 3",
                    PatientSerialNumber = null,
                    Id = "100003",
                    RoomId = "103"
                }
            );
        }

        private static void PhysicianSpecializationCreation(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PhysicianSpecialization>().HasKey(o => new { o.PhysicianSerialNumber, o.SpecializationSerialNumber });
            modelBuilder.Entity<PhysicianSpecialization>().Property(o => o.PhysicianSerialNumber);
            modelBuilder.Entity<PhysicianSpecialization>().Property(o => o.SpecializationSerialNumber);
            modelBuilder.Entity<PhysicianSpecialization>().Ignore(o => o.Physician);
            modelBuilder.Entity<PhysicianSpecialization>().Ignore(o => o.Specialization);
            modelBuilder.Entity<PhysicianSpecialization>().HasData(
                new PhysicianSpecialization
                {
                    SpecializationSerialNumber = "500001",
                    PhysicianSerialNumber = "600001",
                },
                new PhysicianSpecialization
                {
                    SpecializationSerialNumber = "500002",
                    PhysicianSerialNumber = "600001",
                },
                new PhysicianSpecialization
                {
                    SpecializationSerialNumber = "500001",
                    PhysicianSerialNumber = "600002",
                },
                new PhysicianSpecialization
                {
                    SpecializationSerialNumber = "500002",
                    PhysicianSerialNumber = "600002",
                },
                new PhysicianSpecialization
                {
                    SpecializationSerialNumber = "500003",
                    PhysicianSerialNumber = "600002",
                },
                new PhysicianSpecialization
                {
                    SpecializationSerialNumber = "500004",
                    PhysicianSerialNumber = "600002",
                }
            );
        }

        private static void ProcedureEquipmentCreation(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProcedureEquipment>().HasKey(o => new { o.ProcedureTypeSerialNumber, o.EquipmentSerialNumber });
            modelBuilder.Entity<ProcedureEquipment>().Property(o => o.ProcedureTypeSerialNumber);
            modelBuilder.Entity<ProcedureEquipment>().Property(o => o.EquipmentSerialNumber);
            modelBuilder.Entity<ProcedureEquipment>().Ignore(o => o.ProcedureType);
            modelBuilder.Entity<ProcedureEquipment>().Ignore(o => o.Equipment);
            modelBuilder.Entity<ProcedureEquipment>().HasData(
                new ProcedureEquipment
                {
                    ProcedureTypeSerialNumber = "300001",
                    EquipmentSerialNumber = "78",
                },
                new ProcedureEquipment
                {
                    ProcedureTypeSerialNumber = "300001",
                    EquipmentSerialNumber = "80",
                },
                new ProcedureEquipment
                {
                    ProcedureTypeSerialNumber = "300001",
                    EquipmentSerialNumber = "81",
                },
                new ProcedureEquipment
                {
                    ProcedureTypeSerialNumber = "300002",
                    EquipmentSerialNumber = "80",
                },
                new ProcedureEquipment
                {
                    ProcedureTypeSerialNumber = "300002",
                    EquipmentSerialNumber = "83",
                },
                new ProcedureEquipment
                {
                    ProcedureTypeSerialNumber = "300002",
                    EquipmentSerialNumber = "85",
                },
                new ProcedureEquipment
                {
                    ProcedureTypeSerialNumber = "300003",
                    EquipmentSerialNumber = "84",
                },
                new ProcedureEquipment
                {
                    ProcedureTypeSerialNumber = "300004",
                    EquipmentSerialNumber = "82",
                }
            );
        }
    }
}