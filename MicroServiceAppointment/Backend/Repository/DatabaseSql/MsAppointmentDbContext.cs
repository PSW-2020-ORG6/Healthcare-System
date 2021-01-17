using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Model.Util;
using MicroServiceAccount.Backend.Repository.DatabaseSql.RelationHelpers;
using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Model.Hospital;
using MicroServiceAppointment.Backend.Model.Survey;
using MicroServiceAppointment.Backend.Repository.DatabaseSql.RelationHelpers;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceAppointment.Backend.Repository.DatabaseSql
{
    public class MsAppointmentDbContext : DbContext
    {
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Physician> Physician { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Bed> Bed { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Floor> Floor { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<ProcedureType> ProcedureType { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Survey> Survey { get; set; }

        public MsAppointmentDbContext(DbContextOptions<MsAppointmentDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Physician>().HasOne(p => p.Address).WithMany();
            modelBuilder.Entity<Patient>().HasOne(p => p.Address).WithMany();

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

            RoomCreation(modelBuilder);
            RoomTypeCreation(modelBuilder);

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

        private static void RoomTypeCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomType>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType { SerialNumber = "10000001", Name = "Operation room" },
                new RoomType { SerialNumber = "10000002", Name = "Store room" },
                new RoomType { SerialNumber = "10000003", Name = "Examination room" }
            );
        }
    }
}