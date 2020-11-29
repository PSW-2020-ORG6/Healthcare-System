using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories
{
    public class MedicineReportRepository
    {
        public DbContextOptions<HealthCareSystemDbContext> options = new DbContextOptionsBuilder<HealthCareSystemDbContext>()
                .UseMySql(connectionString: "server=localhost;port=3306;database=newmydb;user=root;password=root").UseLazyLoadingProxies()
                .Options;
        public readonly HealthCareSystemDbContext dbContext;

        public MedicineReportRepository()
        {
            this.dbContext = new HealthCareSystemDbContext(options);
        }

        public void AddPrescription()
        {
            List<MedicineDosage> medicineDosages = new List<MedicineDosage> { new MedicineDosage(1,"Brufen", 5), new MedicineDosage(2,"Paracetamol", 10), new MedicineDosage(3,"Andol", 4) };
            MedicineReport medicineReport = new MedicineReport { Id = "mr1", date = new DateTime(2020, 5, 21), dosage = medicineDosages };
            dbContext.Add(medicineReport);
            dbContext.SaveChanges();
        } 

        public List<MedicineReport> GetAll()
        {
            return dbContext.Reports.ToList();
        }

    }
}
