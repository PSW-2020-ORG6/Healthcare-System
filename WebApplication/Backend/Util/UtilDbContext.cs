using health_clinic_class_diagram.Backend.Model.Survey;
using health_clinic_class_diagram.Backend.Model.Hospital;
using health_clinic_class_diagram.Backend.Model.Survey;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;
using Model.Blog;
using Model.Hospital;
using Model.MedicalExam;
using Model.Util;
using System;

namespace WebApplication.Backend.Model
{
    public class UtilDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<MedicineManufacturer> MedicineManufacturers { get; set; }
        public DbSet<MedicineType> MedicineTypes { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<MedicineGEA> MedicineGEA { get; set; }

        public UtilDbContext(DbContextOptions<UtilDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Report>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Feedback>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Building>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Building>().Ignore(o => o.Floors);
            modelBuilder.Entity<Equipment>().HasKey(o => o.Id);
            modelBuilder.Entity<Equipment>().Ignore(o => o.Building);
            modelBuilder.Entity<Equipment>().Ignore(o => o.Floor);
            modelBuilder.Entity<Equipment>().Ignore(o => o.Room);
            modelBuilder.Entity<Floor>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Floor>().Ignore(o => o.Rooms);
            modelBuilder.Entity<Room>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Room>().Ignore(o => o.RoomType);
            modelBuilder.Entity<Room>().Ignore(o => o.Equipment);
            modelBuilder.Entity<MedicineManufacturer>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<MedicineType>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Medicine>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Medicine>().Ignore(o => o.MedicineManufacturer);
            modelBuilder.Entity<Medicine>().Ignore(o => o.MedicineType);
            modelBuilder.Entity<Patient>().HasAlternateKey(o => o.Id);
            modelBuilder.Entity<RoomType>().HasKey(o => o.SerialNumber);

            modelBuilder.Ignore<AdditionalDocument>();
            modelBuilder.Ignore<Address>();

            modelBuilder.Entity<Patient>().HasData(
                 new Patient { Name = "Jelena", Surname = "Tanjic", Id = "0002", DateOfBirth = new DateTime(2017, 1, 18), Contact = "kontakt", Password = "sifra", Address = new Address("neka adresa"), ParentName = "otac", Gender = "Zensko", Email = "email", Guest = true },
                 new Patient { Name = "Sara", Surname = "Milic", Id = "0003", DateOfBirth = new DateTime(2018, 1, 18), Contact = "kontaktMica", Password = "sifraMica", Address = new Address("neka adresaMica"), ParentName = "mama", Gender = "Zensko", Email = "emailMica", Guest = true }
            );
            

            

            modelBuilder.Entity<Building>().HasData(
              new Building { SerialNumber = "10001", Name = "Cardiology", Color = "Orange", Row = 5, Column = 1, Style = "TriangleBuildingButtonStyle" },
              new Building { SerialNumber = "10002", Name = "Orthopedy", Color = "Red", Row = 5, Column = 3, Style = "UBuildingButtonStyle" }
            );

            modelBuilder.Entity<Floor>().HasData(
              new Floor { SerialNumber = "1001", Name = "Floor1", BuildingSerialNumber = "10001" },
              new Floor { SerialNumber = "1002", Name = "Floor2", BuildingSerialNumber = "10001" },
              new Floor { SerialNumber = "1003", Name = "Floor1", BuildingSerialNumber = "10002" }
            );

            modelBuilder.Entity<Equipment>().HasData(
               new Equipment { SerialNumber = "73", RoomId = "101", Name = "Bed", Id = "11", BuildingSerialNumber = "10001", FloorSerialNumber = "1001", RoomSerialNumber = "101" },
               new Equipment { SerialNumber = "74", RoomId = "102", Name = "Bed", Id = "12", BuildingSerialNumber = "10001", FloorSerialNumber = "1001", RoomSerialNumber = "101" },
               new Equipment { SerialNumber = "75", RoomId = "103", Name = "Bed", Id = "13", BuildingSerialNumber = "10001", FloorSerialNumber = "1001", RoomSerialNumber = "101" },
               new Equipment { SerialNumber = "76", RoomId = "101", Name = "Bed", Id = "14", BuildingSerialNumber = "10001", FloorSerialNumber = "1001", RoomSerialNumber = "101" },
               new Equipment { SerialNumber = "77", RoomId = "102", Name = "Bed", Id = "15", BuildingSerialNumber = "10001", FloorSerialNumber = "1002", RoomSerialNumber = "106" },
               new Equipment { SerialNumber = "78", RoomId = "104", Name = "Table", Id = "16", BuildingSerialNumber = "10001", FloorSerialNumber = "1002", RoomSerialNumber = "106" },
               new Equipment { SerialNumber = "79", RoomId = "111", Name = "Table", Id = "17", BuildingSerialNumber = "10001", FloorSerialNumber = "1002", RoomSerialNumber = "107" },
               new Equipment { SerialNumber = "80", RoomId = "111", Name = "Table", Id = "18", BuildingSerialNumber = "10001", FloorSerialNumber = "1002", RoomSerialNumber = "107" },
               new Equipment { SerialNumber = "81", RoomId = "112", Name = "Bed", Id = "19", BuildingSerialNumber = "10002", FloorSerialNumber = "1003", RoomSerialNumber = "114" },
               new Equipment { SerialNumber = "82", RoomId = "112", Name = "Bed", Id = "20", BuildingSerialNumber = "10002", FloorSerialNumber = "1003", RoomSerialNumber = "114" }
            );

            modelBuilder.Entity<RoomType>().HasData(
               new RoomType { SerialNumber = "10000001", Name = "Operation room" },
               new RoomType { SerialNumber = "10000002", Name = "Store room" },
               new RoomType { SerialNumber = "10000003", Name = "Examination room" }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { SerialNumber = "101", Name = "Examination room 101", Id = 101, FloorSerialNumber = "1001", BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000003", Row = 0, Column = 0, RowSpan = 3, ColumnSpan = 5, Style = "RoomButtonStyle" },
                new Room { SerialNumber = "102", Name = "Examination room 102", Id = 102, FloorSerialNumber = "1001", BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000003", Row = 0, Column = 10, RowSpan = 2, ColumnSpan = 4, Style = "RoomButtonStyle" },
                new Room { SerialNumber = "103", Name = "Store room 103", Id = 103, FloorSerialNumber = "1001", BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000002", Row = 0, Column = 5, RowSpan = 2, ColumnSpan = 3, Style = "RoomButtonStyle" },
                new Room { SerialNumber = "104", Name = "Examination room 104", Id = 104, FloorSerialNumber = "1001", BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000003", Row = 0, Column = 14, RowSpan = 3, ColumnSpan = 5, Style = "RoomButtonStyle" },
                new Room { SerialNumber = "105", Name = "Store room 105", Id = 105, FloorSerialNumber = "1001", BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000002", Row = 10, Column = 9, RowSpan = 2, ColumnSpan = 5, Style = "RoomButtonStyle" },
                new Room { SerialNumber = "106", Name = "Operation room 106", Id = 106, FloorSerialNumber = "1002", BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000001", Row = 0, Column = 0, RowSpan = 4, ColumnSpan = 7, Style = "RoomButtonStyle" },
                new Room { SerialNumber = "107", Name = "Operation room 107", Id = 107, FloorSerialNumber = "1002", BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000001", Row = 8, Column = 0, RowSpan = 4, ColumnSpan = 7, Style = "RoomButtonStyle" },
                new Room { SerialNumber = "108", Name = "Store room 108", Id = 108, FloorSerialNumber = "1002", BuildingSerialNumber = "10001", RoomTypeSerialNumber = "10000002", Row = 0, Column = 10, RowSpan = 2, ColumnSpan = 3, Style = "RoomButtonStyle" },
                new Room { SerialNumber = "109", Name = "Examination room 109", Id = 109, FloorSerialNumber = "1003", BuildingSerialNumber = "10002", RoomTypeSerialNumber = "10000003" },
                new Room { SerialNumber = "110", Name = "Operation room 110", Id = 110, FloorSerialNumber = "1003", BuildingSerialNumber = "10002", RoomTypeSerialNumber = "10000001" },
                new Room { SerialNumber = "111", Name = "Examination room 111", Id = 111, FloorSerialNumber = "1003", BuildingSerialNumber = "10002", RoomTypeSerialNumber = "10000003" },
                new Room { SerialNumber = "112", Name = "Store room 112", Id = 112, FloorSerialNumber = "1003", BuildingSerialNumber = "10002", RoomTypeSerialNumber = "10000002" },
                new Room { SerialNumber = "113", Name = "Examination room 113", Id = 113, FloorSerialNumber = "1003", BuildingSerialNumber = "10002", RoomTypeSerialNumber = "10000003" },
                new Room { SerialNumber = "114", Name = "Examination room 114", Id = 114, FloorSerialNumber = "1003", BuildingSerialNumber = "10002", RoomTypeSerialNumber = "10000003" }
            );

            modelBuilder.Entity<MedicineManufacturer>().HasData(
                new MedicineManufacturer { SerialNumber = "1", Name = "manufacturer1" },
                new MedicineManufacturer { SerialNumber = "2", Name = "manufacturer2" }
            );

            modelBuilder.Entity<MedicineType>().HasData(
                    new MedicineType { SerialNumber = "11", Type = "Antibiotic" },
                    new MedicineType { SerialNumber = "12", Type = "Brufen" }
            );

            modelBuilder.Entity<Medicine>().HasData(
                   new Medicine { SerialNumber = "21", CopyrightName = "Brufen", GenericName = "Brufen", MedicineManufacturerSerialNumber = "1", MedicineTypeSerialNumber = "11" },
                   new Medicine { SerialNumber = "22", CopyrightName = "Probiotic", GenericName = "Probiotic", MedicineManufacturerSerialNumber = "2", MedicineTypeSerialNumber = "12" }
            );

            modelBuilder.Entity<Bed>().HasData(
                new Bed
                {
                    SerialNumber = "100001",
                    BuildingSerialNumber = "10001",
                    FloorSerialNumber = "1001",
                    RoomSerialNumber = "101",
                    Name = "Bed 1",
                    PatientID = "0002",
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
                    PatientID = "0003",
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
                    PatientID = null,
                    Id = "100003",
                    RoomId = "103"
                }
            );
        }
    }
}
