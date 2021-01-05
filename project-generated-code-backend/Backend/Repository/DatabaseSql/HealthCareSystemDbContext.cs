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

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class HealthCareSystemDbContext : DbContext
    {
   //     private const string CONNECTION_STRING =
  //          "User ID =postgres;Password=super;Server=localhost;Port=5432;Database=healthcare-system-db;Integrated Security=true;Pooling=true;";

        public DbSet<Address> Address { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }

        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Physician> Physician { get; set; }
        public DbSet<PhysicianSpecialization> PhysicianSpecialization { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Secretary> Secretary { get; set; }

        public DbSet<Equipment> Equipment { get; set; }
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
                .WithOne(f => f.Building) // Floors have one reference to Building
                .OnDelete(DeleteBehavior.Cascade); // On deleting one building all the referenced floors are deleted

            modelBuilder.Entity<Floor>()
                .HasMany(f => f.Rooms) // Floor has many Rooms
                .WithOne(r => r.Floor) // Room has one Floor
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

            // Relation helpers are used for many-to-many relations
            modelBuilder.Entity<PhysicianSpecialization>()
                .HasKey("PhysicianSerialNumber", "SpecializationSerialNumber");
            modelBuilder.Entity<PhysicianSpecialization>()
                .HasOne(ps => ps.Physician)
                .WithMany();
            modelBuilder.Entity<PhysicianSpecialization>()
                .HasOne(ps => ps.Specialization)
                .WithMany();

            modelBuilder.Entity<DiagnosticReferral>()
                .HasKey(x => x.SerialNumber);
            modelBuilder.Entity<SpecialistReferral>()
                .HasKey(x => x.SerialNumber);
            modelBuilder.Entity<FollowUp>()
                .HasKey(x => x.SerialNumber);
            modelBuilder.Entity<Prescription>()
                .HasKey(x => x.SerialNumber);

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

            // Pharmacy support
            modelBuilder.Entity<ActionAndBenefitMessage>()
                .HasAlternateKey(abm => abm.ActionID);
        }
    }
}