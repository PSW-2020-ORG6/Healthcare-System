using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using health_clinic_class_diagram.Backend.Model.Hospital;

namespace IntegrationAdapters
{
    public class IAHealthCareSystemDbContext : DbContext
    {
        public DbSet<Api> Apis { get; set; }
        public DbSet<ActionAndBenefitMessage> ActionAndBenefitMessage { get; set; }
        public DbSet<MedicineReport> Reports { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<MedicineSpecification> MedicineSpecification { get; set; }

        public IAHealthCareSystemDbContext(DbContextOptions<IAHealthCareSystemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}