using System;
using System.Configuration;
using IntegrationAdapters;
using IntegrationAdapters.Models;
using IntegrationAdapters.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace IntegrationAdaptersTests
{
    public class RegisterHospitalTests
    {
        public readonly HealthCareSystemDbContext dbContext;
        [Fact]
        public void Is_pharmacy_already_existing_on_hospital()
        {
            var options = new DbContextOptionsBuilder<HealthCareSystemDbContext>()
                .UseMySql(connectionString: "server=localhost;port=3306;database=newmydb;user=root;password=root")
                .Options;

            ApiService service = new ApiService(new HealthCareSystemDbContext(options));

            Api a = new Api("k", "k", "k");

            bool alreadyExists = service.RegisterHospitalOnPharmacy(a);

            Assert.False(alreadyExists);
        }
        [Fact]
        public void Is_pharmacy_not_existing_on_hospital()
        {
            var options = new DbContextOptionsBuilder<HealthCareSystemDbContext>()
                .UseMySql(connectionString: "server=localhost;port=3306;database=newmydb;user=root;password=root")
                .Options;

            ApiService service = new ApiService(new HealthCareSystemDbContext(options));

            Api a = new Api("m", "m", "m");

            bool notExists = service.RegisterHospitalOnPharmacy(a);

            Assert.True(notExists);
        }
    }
}
