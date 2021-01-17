using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Model.Util;
using MicroServiceAccount.Backend.Repository.DatabaseSql.RelationHelpers;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceAccount.Backend.Repository.DatabaseSql
{
    public class MsAccountDbContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Physician> Physician { get; set; }
        public DbSet<PhysicianSpecialization> PhysicianSpecialization { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<ActionAndBenefitMessage> ActionAndBenefitMessage { get; set; }
        public MsAccountDbContext(DbContextOptions<MsAccountDbContext> options) : base(options)
        {
        }

        public MsAccountDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasOne(c => c.Country).WithMany();
            modelBuilder.Entity<Address>().HasOne(a => a.City).WithMany();

            modelBuilder.Entity<Physician>().HasOne(p => p.Address).WithMany();
            modelBuilder.Entity<Patient>().HasOne(p => p.Address).WithMany();

            // Relation helpers are used for many-to-many relations
            modelBuilder.Entity<PhysicianSpecialization>()
                .HasKey("PhysicianSerialNumber", "SpecializationSerialNumber");
            modelBuilder.Entity<PhysicianSpecialization>()
                .HasOne(ps => ps.Physician)
                .WithMany();
            modelBuilder.Entity<PhysicianSpecialization>()
                .HasOne(ps => ps.Specialization)
                .WithMany();

            modelBuilder.Entity<Admin>()
              .HasKey(x => x.Email);

            // Pharmacy support
            modelBuilder.Entity<ActionAndBenefitMessage>()
                .HasAlternateKey(abm => abm.ActionID);
        }
    }
}