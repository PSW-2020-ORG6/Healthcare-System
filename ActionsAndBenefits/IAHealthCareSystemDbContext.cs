using ActionsAndBenefits.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;

namespace ActionsAndBenefits
{
    public class IAHealthCareSystemDbContext : DbContext
    {
        public DbSet<Api> Apis { get; set; }
        public DbSet<ActionAndBenefitMessage> ActionAndBenefitMessage { get; set; }


        public IAHealthCareSystemDbContext(DbContextOptions<IAHealthCareSystemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionAndBenefitMessage>().HasAlternateKey(abm => abm.ActionID);
        }
    }
}