using health_clinic_class_diagram.Backend.Model.Hospital;
using health_clinic_class_diagram.Backend.Model.Survey;
using HealthClinicBackend.Backend.Repository.DatabaseSql.RelationHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model.Accounts;
using Model.Hospital;
using Model.MedicalExam;
using Model.Schedule;
using Model.Util;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class HealthCareSystemDbContext : DbContext
    {
        private const string CONNECTION_STRING =
            "User ID =postgres;Password=super;Server=localhost;Port=5432;Database=healthcare-system-db;Integrated Security=true;Pooling=true;";

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

        // public DbSet<DiagnosticType> DiagnosticTypes { get; set; }
        // public DbSet<DiagnosticReferral> DiagnosticReferrals { get; set; }
        // public DbSet<FollowUp> FollowUps { get; set; }
        // public DbSet<SpecialistReferral> SpecialistReferrals { get; set; }
        // public DbSet<MedicineDosage> MedicineDosages { get; set; }
        // public DbSet<Prescription> Prescriptions { get; set; }
        //
        // public DbSet<ProcedureType> ProcedureTypes { get; set; }
        // public DbSet<Appointment> Appointments { get; set; }
        //
        // public DbSet<Question> Questions { get; set; }
        // public DbSet<Survey> Surveys { get; set; }

        public HealthCareSystemDbContext(DbContextOptions<HealthCareSystemDbContext> options) : base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // { 
        //     optionsBuilder.UseNpgsql(CONNECTION_STRING);
        // }

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

            // Relation helpers are used for many-to-many relations
            modelBuilder.Entity<PhysicianSpecialization>().HasKey("PhysicianSerialNumber", "SpecializationSerialNumber");
            modelBuilder.Entity<PhysicianSpecialization>()
                .HasOne(ps => ps.Physician)
                .WithMany();
            modelBuilder.Entity<PhysicianSpecialization>()
                .HasOne(ps => ps.Specialization)
                .WithMany();
        }
    }
}