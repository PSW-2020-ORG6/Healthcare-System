using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Model.Hospital;
using MicroServiceSearch.Backend.Model;
using MicroServiceSearch.Backend.Model.MedicalExam;
using MicroServiceSearch.Backend.Repository.DatabaseSql.RelationHelpers;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceSearch.Backend.Repository.DatabaseSql
{
    public class MsSearchDbContext : DbContext
    {
        //     private const string CONNECTION_STRING =
        //          "User ID =postgres;Password=super;Server=localhost;Port=5432;Database=healthcare-system-db;Integrated Security=true;Pooling=true;";

        //public DbSet<Address> Address { get; set; }
        //public DbSet<Admin> Admin { get; set; }
        //public DbSet<City> City { get; set; }
        //public DbSet<Country> Country { get; set; }
        //public DbSet<Specialization> Specialization { get; set; }
        //public DbSet<Physician> Physician { get; set; }
        //public DbSet<PhysicianSpecialization> PhysicianSpecialization { get; set; }
        //public DbSet<Patient> Patient { get; set; }
        //public DbSet<Secretary> Secretary { get; set; }
        //public DbSet<Equipment> Equipment { get; set; }
        //public DbSet<Bed> Bed { get; set; }
        //public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Room> Room { get; set; }
        //public DbSet<Floor> Floor { get; set; }
        //public DbSet<Building> Building { get; set; }
        public DbSet<Position> Position { get; set; }
        //public DbSet<Rejection> Rejection { get; set; }
        //public DbSet<DiagnosticType> DiagnosticType { get; set; }
        public DbSet<DiagnosticReferral> DiagnosticReferral { get; set; }
        //public DbSet<FollowUp> FollowUp { get; set; }
        public DbSet<SpecialistReferral> SpecialistReferral { get; set; }
        public DbSet<MedicineDosage> MedicineDosage { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PrescriptionMedicineDosage> PrescriptionMedicineDosage { get; set; }
        public DbSet<ReportPrescription> ReportPrescription { get; set; }
        public DbSet<ReportDiagnosticReferral> ReportDiagnosticReferral { get; set; }
        public DbSet<ReportFollowUp> ReportFollowUp { get; set; }
        public DbSet<ReportSpecialistReferral> ReportSpecialistReferral { get; set; }
        public DbSet<Report> Report { get; set; }
        //public DbSet<ProcedureType> ProcedureType { get; set; }
        //public DbSet<Appointment> Appointment { get; set; }
        //public DbSet<Question> Question { get; set; }
        //public DbSet<Survey> Survey { get; set; }
        //public DbSet<Feedback> Feedback { get; set; }
        //public DbSet<ActionAndBenefitMessage> ActionAndBenefitMessage { get; set; }
        public MsSearchDbContext(DbContextOptions<MsSearchDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(CONNECTION_STRING);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Position>().HasNoKey();

            //modelBuilder.Entity<Rejection>()
            //    .HasOne(r => r.Medicine)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Building>()
            //    .HasMany(b => b.Floors) // Building has many references to Floors
            //    .WithOne(f => f.Building) // Floors have one reference to Building
            //    .OnDelete(DeleteBehavior.Cascade); // On deleting one building all the referenced floors are deleted

            //modelBuilder.Entity<Floor>()
            //    .HasMany(f => f.Rooms) // Floor has many Rooms
            //    .WithOne(r => r.Floor) // Room has one Floor
            //    .OnDelete(DeleteBehavior.Cascade); // When Floor is deleted, so are all the referenced Rooms

            //modelBuilder.Entity<Room>()
            //    .HasMany(r => r.Equipment) // Room has many Equipments
            //    .WithOne(); // Equipment 'has' one Room but doesn't reference it

            //modelBuilder.Entity<Room>()
            //    .HasMany(r => r.Beds) // Room has many Beds
            //    .WithOne(); // Bed 'has' one Room but doesn't reference it

            //modelBuilder.Entity<Room>()
            //    .HasOne(r => r.RoomType) // Room has RoomType
            //    .WithMany(); // RoomType can have many Rooms but doesn't reference them

            //modelBuilder.Entity<City>().HasOne(c => c.Country).WithMany();
            //modelBuilder.Entity<Address>().HasOne(a => a.City).WithMany();

            //modelBuilder.Entity<Physician>().HasOne(p => p.Address).WithMany();
            //modelBuilder.Entity<Patient>().HasOne(p => p.Address).WithMany();
            //modelBuilder.Entity<Secretary>().HasOne(s => s.Address).WithMany();

            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Patient)
            //    .WithMany();
            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.ProcedureType)
            //    .WithMany();
            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Physician)
            //    .WithMany();
            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Room)
            //    .WithMany();

            //// Relation helpers are used for many-to-many relations
            //modelBuilder.Entity<PhysicianSpecialization>()
            //    .HasKey("PhysicianSerialNumber", "SpecializationSerialNumber");
            //modelBuilder.Entity<PhysicianSpecialization>()
            //    .HasOne(ps => ps.Physician)
            //    .WithMany();
            //modelBuilder.Entity<PhysicianSpecialization>()
            //    .HasOne(ps => ps.Specialization)
            //    .WithMany();

            //modelBuilder.Entity<DiagnosticReferral>()
            //    .HasKey(x => x.SerialNumber);
            //modelBuilder.Entity<SpecialistReferral>()
            //    .HasKey(x => x.SerialNumber);
            //modelBuilder.Entity<FollowUp>()
            //    .HasKey(x => x.SerialNumber);
            modelBuilder.Entity<Prescription>()
                .HasKey(x => x.SerialNumber);
            //modelBuilder.Entity<Admin>()
            //  .HasKey(x => x.Email);

            //modelBuilder.Entity<DiagnosticReferral>()
            //    .HasOne(dr => dr.DiagnosticType)
            //    .WithMany();
            //modelBuilder.Entity<FollowUp>()
            //    .HasOne(fu => fu.Physician)
            //    .WithMany();
            //modelBuilder.Entity<SpecialistReferral>()
            //    .HasOne(sr => sr.Physician)
            //    .WithMany();
            //modelBuilder.Entity<SpecialistReferral>()
            //    .HasOne(sr => sr.ProcedureType)
            //    .WithMany();
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
            modelBuilder.Entity<Report>()
                .HasOne(rp => rp.ProcedureType)
                .WithMany();
            modelBuilder.Entity<ReportPrescription>()
                .HasOne(rp => rp.Prescription)
                .WithOne();

            //    modelBuilder.Entity<ReportDiagnosticReferral>()
            //        .HasOne(x => x.Report)
            //        .WithMany();
            //    modelBuilder.Entity<ReportDiagnosticReferral>()
            //        .HasOne(x => x.DiagnosticReferral)
            //        .WithOne();

            //    modelBuilder.Entity<ReportSpecialistReferral>()
            //        .HasOne(x => x.Report)
            //        .WithMany();
            //    modelBuilder.Entity<ReportSpecialistReferral>()
            //        .HasOne(x => x.SpecialistReferral)
            //        .WithOne();

            //    modelBuilder.Entity<ReportFollowUp>()
            //        .HasOne(x => x.Report)
            //        .WithMany();
            //    modelBuilder.Entity<ReportFollowUp>()
            //        .HasOne(x => x.FollowUp)
            //        .WithOne();

            //    // Pharmacy support
            //    modelBuilder.Entity<ActionAndBenefitMessage>()
            //        .HasAlternateKey(abm => abm.ActionID);

            RoomCreation(modelBuilder);
        }

        private static void RoomCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Room>().Ignore(o => o.RoomType);
            modelBuilder.Entity<Room>().Ignore(o => o.Equipment);
            modelBuilder.Entity<Room>().Ignore(o => o.Beds);
            modelBuilder.Entity<Room>().Ignore(o => o.Medicines);


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
    }
}