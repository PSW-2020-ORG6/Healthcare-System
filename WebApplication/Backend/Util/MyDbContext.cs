using Microsoft.EntityFrameworkCore;
using Model.Accounts;
using Model.Blog;
using Model.Util;
using System;

namespace WebApplication.Backend.Model
{
    public class MyDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Patient> Patients { get; set; }


        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasKey(o => o.SerialNumber);
            modelBuilder.Entity<Patient>().HasAlternateKey(o=>o.Id);
            modelBuilder.Ignore<Address>();
            modelBuilder.Entity<Patient>().HasData(
                 new Patient { Name = "Jelena", Surname = "Tanjic", Id = "0002", DateOfBirth = new DateTime(2017, 1, 18), Contact = "kontakt", Password = "sifra", Address = new Address("neka adresa"), ParentName = "otac", Gender = "Zensko", Email = "email", Guest = true },
                 new Patient { Name = "Sara", Surname = "Milic", Id = "0003", DateOfBirth = new DateTime(2018, 1, 18), Contact = "kontaktMica", Password = "sifraMica", Address = new Address("neka adresaMica"), ParentName = "mama", Gender = "Zensko", Email = "emailMica", Guest = true }
            );
        }
    }
}
