using Backend.Dto;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;
using Model.Blog;
using Model.Util;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;

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

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { Id = "1", PatientId = "Ime1", Text = "tekst komentara1", Date = new DateTime(2017, 1, 18), Approved = true }

            );
            modelBuilder.Entity<Patient>().HasAlternateKey(o=>o.Id);
            modelBuilder.Ignore<Address>();
            modelBuilder.Entity<Patient>().HasData(
                 new Patient { Name = "Tanja", Surname = "Tanjic", Id = "0001", DateOfBirth = new DateTime(2017, 1, 18), Contact = "kontakt", Password = "sifra", Address = new Address("neka adresa"), ParentName = "otac", Gender = "Zensko", Email = "email", Guest = true }
                );
        }
    }
}
