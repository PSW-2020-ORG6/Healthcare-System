using health_clinic_class_diagram.Backend.Model.Hospital;
using health_clinic_class_diagram.Backend.Model.Survey;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model.Accounts;
using Model.Hospital;
using Model.MedicalExam;
using Model.Schedule;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class HealthCareSystemDbContext : DbContext
    {
        private const string CONNECTION_STRING =
            "User ID =postgres;Password=super;Server=localhost;Port=5432;Database=healthcare-system-db;Integrated Security=true;Pooling=true;";

        // public DbSet<Patient> Patients { get; set; }
        // public DbSet<Specialization> Specializations { get; set; }
        // public DbSet<Physician> Physicians { get; set; }
        // public DbSet<Secretary> Secretaries { get; set; }

        // public DbSet<Equipment> Equipments { get; set; }
        // public DbSet<Bed> Beds { get; set; }
        // public DbSet<RoomType> RoomTypes { get; set; }
        // public DbSet<Room> Rooms { get; set; }
        // public DbSet<Floor> Floors { get; set; }
        // public DbSet<Building> Buildings { get; set; }

        public DbSet<MedicineManufacturer> MedicineManufacturers { get; set; }
        public DbSet<MedicineType> MedicineTypes { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Rejection> Rejections { get; set; }

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

            // modelBuilder.Entity<Building>()
            //     .HasMany(b => b.Floors) // Building has many references to Floors
            //     .WithOne(f => f.Building) // Floors have one reference to Building
            //     .OnDelete(DeleteBehavior.Cascade); // On deleting one building all the referenced floors are deleted
            //
            // modelBuilder.Entity<Floor>()
            //     .HasMany(f => f.Rooms) // Floor has many Rooms
            //     .WithOne(r => r.Floor) // Room has one Floor
            //     .OnDelete(DeleteBehavior.Cascade); // When Floor is deleted, so are all the referenced Rooms
            //
            // modelBuilder.Entity<Room>()
            //     .HasMany(r => r.Equipment) // Room has many Equipments
            //     .WithOne(); // Equipment 'has' one Room but doesn't reference it
            //
            // modelBuilder.Entity<Room>()
            //     .HasMany(r => r.Beds) // Room has many Beds
            //     .WithOne(); // Bed 'has' one Room but doesn't reference it
            //
            // modelBuilder.Entity<Room>()
            //     .HasOne(r => r.RoomType) // Room has RoomType
            //     .WithMany(); // RoomType can have many Rooms but doesn't reference them
        }
    }
}