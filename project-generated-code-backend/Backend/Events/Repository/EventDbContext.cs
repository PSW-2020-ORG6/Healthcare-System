using System;
using System.Collections.Generic;
using System.Text;
using HealthClinicBackend.Backend.Events.Model;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Events.Repository
{
    public class EventDbContext : DbContext
    {
        public DbSet<PatientRegisteredEvent> PatientRegisteredEvents { get; set; }

        public EventDbContext() : base()
        {
        }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "userid=postgres;server=localhost;port=5432;database=healthcare-system-events;password=super;");
        }
    }
}