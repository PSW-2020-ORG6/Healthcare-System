using health_clinic_class_diagram.Backend.Model.Hospital;
using health_clinic_class_diagram.Backend.Model.Survey;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;
using Model.Hospital;
using Model.MedicalExam;
using Model.Schedule;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class HealthCareSystemDbContext : DbContext
    {
        // public DbSet<Patient> Patients { get; set; }
        // public DbSet<Specialization> Specializations { get; set; }
        // public DbSet<Physician> Physicians { get; set; }
        // public DbSet<Secretary> Secretaries { get; set; }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Building> Buildings { get; set; }

        // public DbSet<MedicineManufacturer> MedicineManufacturers { get; set; }
        // public DbSet<MedicineType> MedicineTypes { get; set; }
        // public DbSet<Medicine> Medicines { get; set; }
        // public DbSet<Rejection> Rejections { get; set; }
        //
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
        }
    }
}