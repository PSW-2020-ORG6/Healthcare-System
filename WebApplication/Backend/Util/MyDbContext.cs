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
            modelBuilder.Entity<Building>().HasKey(o => o.Id);
            modelBuilder.Entity<Equipment>().HasKey(o => o.Id);
            modelBuilder.Entity<Floor>().HasKey(o => o.Id);
            modelBuilder.Entity<RoomGEA>().HasKey(o => o.Id);
            modelBuilder.Entity<MedicineManufacturer>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<MedicineType>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Medicine>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Patient>().HasAlternateKey(o => o.Id);
            modelBuilder.Ignore<Address>();
            modelBuilder.Entity<Patient>().HasData(
                 new Patient { Name = "Jelena", Surname = "Tanjic", Id = "0002", DateOfBirth = new DateTime(2017, 1, 18), Contact = "kontakt", Password = "sifra", Address = new Address("neka adresa"), ParentName = "otac", Gender = "Zensko", Email = "email", Guest = true },
                 new Patient { Name = "Sara", Surname = "Milic", Id = "0003", DateOfBirth = new DateTime(2018, 1, 18), Contact = "kontaktMica", Password = "sifraMica", Address = new Address("neka adresaMica"), ParentName = "mama", Gender = "Zensko", Email = "emailMica", Guest = true }
            );
            modelBuilder.Entity<RoomGEA>().HasData(
                new RoomGEA { SerialNumber = "Room1", Id = "9001", FloorId = "1001" },
                new RoomGEA { SerialNumber = "Room2", Id = "9002", FloorId = "1001" },
                new RoomGEA { SerialNumber = "Room3", Id = "9003", FloorId = "1001" },
                new RoomGEA { SerialNumber = "Room4", Id = "9004", FloorId = "1001" },
                new RoomGEA { SerialNumber = "Room5", Id = "9005", FloorId = "1001" },
                new RoomGEA { SerialNumber = "Operation room1", Id = "9006", FloorId = "1002" },
                new RoomGEA { SerialNumber = "Operation room2", Id = "9007", FloorId = "1002" },
                new RoomGEA { SerialNumber = "Store room", Id = "9008", FloorId = "1002" }
            );
            modelBuilder.Entity<Floor>().HasData(
              new Floor { Id = "1001", Name = "Floor1", BuildingId = "10001" },
              new Floor { Id = "1002", Name = "Floor2", BuildingId = "10001" }
            );
            modelBuilder.Entity<Building>().HasData(
              new Building { Id = "10001", Name = "Cardiology", Color = "Orange", Shape = "Square" }
            );
        }
    }
}
