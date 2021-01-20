using TenderProcurement.Models;
using TenderProcurement.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderProcure = TenderProcurement.Models.Tender;


namespace TenderProcurement
{
    public class IAHealthCareSystemDbContext : DbContext
    {
        public DbSet<TenderProcure> Tender { get; set; }
        public DbSet<TenderOffer> TenderOffer { get; set; }
        public DbSet<MedicineDTO> MedicineDTOs { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public IAHealthCareSystemDbContext(DbContextOptions<IAHealthCareSystemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}