using MedicineUsage.Models;
using MedicineUsage.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineUsage
{
    public class IAHealthCareSystemDbContext : DbContext
    {
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<MedicineSpecification> MedicineSpecification { get; set; }
        public DbSet<MedicineReport> Reports { get; set; }

        public IAHealthCareSystemDbContext(DbContextOptions<IAHealthCareSystemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}