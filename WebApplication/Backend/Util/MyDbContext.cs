using health_clinic_class_diagram.Backend.Model.Hospital;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;
using Model.Blog;
using Model.Hospital;
using Model.Util;
using System;

namespace WebApplication.Backend.Model
{
    public class MyDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<RoomGEA> Rooms { get; set; }
        public DbSet<MedicineManufacturer> MedicineManufacturers { get; set; }
        public DbSet<MedicineType> MedicineTypes { get; set; }
        public DbSet<Medicine> Medicine { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // only for testing purposes
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
            modelBuilder.Entity<Patient>().HasAlternateKey(o => o.Id);
            modelBuilder.Ignore<Address>();
            modelBuilder.Entity<Patient>().HasData(
                 new Patient { Name = "Jelena", Surname = "Tanjic", Id = "0002", DateOfBirth = new DateTime(2017, 1, 18), Contact = "kontakt", Password = "sifra", Address = new Address("neka adresa"), ParentName = "otac", Gender = "Zensko", Email = "email", Guest = true },
                 new Patient { Name = "Sara", Surname = "Milic", Id = "0003", DateOfBirth = new DateTime(2018, 1, 18), Contact = "kontaktMica", Password = "sifraMica", Address = new Address("neka adresaMica"), ParentName = "mama", Gender = "Zensko", Email = "emailMica", Guest = true }
            );
            modelBuilder.Entity<Building>().HasData(
              new Building { SerialNumber = "10001", Name = "Cardiology", Color = "Orange", Shape = "Square" },
              new Building { SerialNumber = "10002", Name = "Orthopedy", Color = "Dark Orange", Shape = "Square" }
            );
            modelBuilder.Entity<Floor>().HasData(
              new Floor { SerialNumber = "1001", Name = "Floor1", BuildingName = "Cardiology" },
              new Floor { SerialNumber = "1002", Name = "Floor2", BuildingName = "Cardiology" },
              new Floor { SerialNumber = "1003", Name = "Floor1", BuildingName = "Orthopedy" }
            );
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
        }
    }
}
