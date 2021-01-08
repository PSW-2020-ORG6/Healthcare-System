using System;
using System.Collections.Generic;
using System.Text;
using HealthClinicBackend.Backend.Events.Model;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Events.Repository
{
    class EventDbContext : DbContext
    {
        public DbSet<PatientRegisteredEvent> PatientRegisteredEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}