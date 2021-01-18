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
        public DbSet<Room> Room { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<DiagnosticReferral> DiagnosticReferral { get; set; }
        public DbSet<SpecialistReferral> SpecialistReferral { get; set; }
        public DbSet<MedicineDosage> MedicineDosage { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PrescriptionMedicineDosage> PrescriptionMedicineDosage { get; set; }
        public DbSet<ReportPrescription> ReportPrescription { get; set; }
        public DbSet<ReportDiagnosticReferral> ReportDiagnosticReferral { get; set; }
        public DbSet<ReportFollowUp> ReportFollowUp { get; set; }
        public DbSet<ReportSpecialistReferral> ReportSpecialistReferral { get; set; }
        public DbSet<Report> Report { get; set; }
        public MsSearchDbContext(DbContextOptions<MsSearchDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>()
                .HasKey(x => x.SerialNumber);
            
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