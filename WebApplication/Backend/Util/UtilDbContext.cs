using Microsoft.EntityFrameworkCore;
using Model.Accounts;
using Model.Util;

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
        public DbSet<RoomGEA> Rooms { get; set; }
        public DbSet<MedicineManufacturer> MedicineManufacturers { get; set; }
        public DbSet<MedicineType> MedicineTypes { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<MedicineGEA> MedicineGEA { get; set; }

        public UtilDbContext(DbContextOptions<UtilDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Building>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Equipment>().HasKey(o => o.Id);
            modelBuilder.Entity<Floor>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<RoomGEA>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<MedicineManufacturer>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<MedicineType>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Medicine>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<MedicineGEA>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Patient>().HasAlternateKey(o => o.Id);
            modelBuilder.Entity<Address>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Patient>().HasData(
                 new Patient { Name = "Jelena", Surname = "Tanjic", Id = "0002", DateOfBirth = new DateTime(2017, 1, 18), Contact = "kontakt", Password = "sifra", Address = new Address("neka adresa"), ParentName = "otac", Gender = "Zensko", Email = "email", Guest = true },
                 new Patient { Name = "Sara", Surname = "Milic", Id = "0003", DateOfBirth = new DateTime(2018, 1, 18), Contact = "kontaktMica", Password = "sifraMica", Address = new Address("neka adresaMica"), ParentName = "mama", Gender = "Zensko", Email = "emailMica", Guest = true }
            );
            // TODO: Comments
            //modelBuilder.Entity<Building>().HasData(
            //  new Building { SerialNumber = "10001", Name = "Cardiology", Color = "Orange", Shape = "Square" },
            //  new Building { SerialNumber = "10002", Name = "Orthopedy", Color = "Dark Orange", Shape = "Square" }
            //);
            //modelBuilder.Entity<Floor>().HasData(
            //  new Floor { SerialNumber = "1001", Name = "Floor1", BuildingName = "Cardiology" },
            //  new Floor { SerialNumber = "1002", Name = "Floor2", BuildingName = "Cardiology" },
            //  new Floor { SerialNumber = "1003", Name = "Floor1", BuildingName = "Orthopedy" }
            //);
            modelBuilder.Entity<RoomGEA>().HasData(
                new RoomGEA { SerialNumber = "101", Name = "Examination room", FloorName = "Floor 1", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "102", Name = "Examination room", FloorName = "Floor 1", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "103", Name = "Store room", FloorName = "Floor 1", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "104", Name = "Examination room", FloorName = "Floor 1", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "105", Name = "Store room", FloorName = "Floor 1", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "106", Name = "Operation room", FloorName = "Floor 2", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "107", Name = "Operation room", FloorName = "Floor 2", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "108", Name = "Store room", FloorName = "Floor 2", BuildingName = "Cardiology" },
                new RoomGEA { SerialNumber = "109", Name = "Examination room", FloorName = "Floor 1", BuildingName = "Orthopedy" },
                new RoomGEA { SerialNumber = "110", Name = "Operation room", FloorName = "Floor 1", BuildingName = "Orthopedy" },
                new RoomGEA { SerialNumber = "111", Name = "Examination room", FloorName = "Floor 1", BuildingName = "Orthopedy" },
                new RoomGEA { SerialNumber = "112", Name = "Store room", FloorName = "Floor 1", BuildingName = "Orthopedy" },
                new RoomGEA { SerialNumber = "113", Name = "Examination room", FloorName = "Floor 1", BuildingName = "Orthopedy" },
                new RoomGEA { SerialNumber = "114", Name = "Examination room", FloorName = "Floor 1", BuildingName = "Orthopedy" }
            );
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { SerialNumber = "73", RoomId = "101", Name = "Bed", Id = "11" },
                new Equipment { SerialNumber = "74", RoomId = "102", Name = "Bed", Id = "12" },
                new Equipment { SerialNumber = "75", RoomId = "103", Name = "Bed", Id = "13" },
                new Equipment { SerialNumber = "76", RoomId = "101", Name = "Bed", Id = "14" },
                new Equipment { SerialNumber = "77", RoomId = "102", Name = "Bed", Id = "15" },
                new Equipment { SerialNumber = "78", RoomId = "104", Name = "Table", Id = "16" },
                new Equipment { SerialNumber = "79", RoomId = "111", Name = "Table", Id = "17" },
                new Equipment { SerialNumber = "80", RoomId = "111", Name = "Table", Id = "18" },
                new Equipment { SerialNumber = "81", RoomId = "112", Name = "Bed", Id = "19" },
                new Equipment { SerialNumber = "82", RoomId = "112", Name = "Bed", Id = "20" }

                );
            modelBuilder.Entity<MedicineManufacturer>().HasData(
                new MedicineManufacturer { Name = "manufacturer1", SerialNumber = "1" },
                new MedicineManufacturer { Name = "manufacturer2", SerialNumber = "2" }
                );
            modelBuilder.Entity<MedicineType>().HasData(
                    new MedicineType { SerialNumber = "11", Type = "Antibiotic" },
                    new MedicineType { SerialNumber = "12", Type = "Brufen" }
                );
            modelBuilder.Entity<MedicineGEA>().HasData(
                   new MedicineGEA { SerialNumber = "21", CopyrightName = "Brufen", GenericName = "Brufen", MedicineManufacturerId = "1", MedicineTypeId = "11" },
                   new MedicineGEA { SerialNumber = "22", CopyrightName = "Probiotic", GenericName = "Probiotic", MedicineManufacturerId = "2", MedicineTypeId = "12" }
                );
        }
    }
}
