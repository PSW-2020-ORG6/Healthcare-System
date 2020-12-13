using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories
{
    public class MedicineReportRepository : IMedicineReportRepository
    {
        public DbContextOptions<IAHealthCareSystemDbContext> options = new DbContextOptionsBuilder<IAHealthCareSystemDbContext>()
                .UseMySql(connectionString: "server=localhost;port=3306;database=newmydb;user=root;password=root").UseLazyLoadingProxies()
                .Options;
        public readonly IAHealthCareSystemDbContext dbContext;

        public MedicineReportRepository()
        {
            this.dbContext = new IAHealthCareSystemDbContext(options);
        }

        public void AddPrescription()
        {
            List<MedicineDosage> medicineDosages = new List<MedicineDosage> { new MedicineDosage(1,"Brufen", 5), new MedicineDosage(2,"Paracetamol", 10), new MedicineDosage(3,"Andol", 4) };
            List<MedicineDosage> medicineDosages1 = new List<MedicineDosage> { new MedicineDosage(4, "Brufen", 3), new MedicineDosage(5, "Paracetamol", 11), new MedicineDosage(6, "Andol", 7) };
            List<MedicineDosage> medicineDosages2 = new List<MedicineDosage> { new MedicineDosage(7, "Brufen", 2), new MedicineDosage(8, "Paracetamol", 5), new MedicineDosage(9, "Andol", 20) };
            MedicineReport medicineReport = new MedicineReport { Id = "mr1", Date = new DateTime(2020, 5, 21), Dosage = medicineDosages };
            MedicineReport medicineReport1 = new MedicineReport { Id = "mr2", Date = new DateTime(2020, 6, 4), Dosage = medicineDosages1 };
            MedicineReport medicineReport2 = new MedicineReport { Id = "mr3", Date = new DateTime(2020, 10, 11), Dosage = medicineDosages2 };
            dbContext.AddRange(medicineReport,medicineReport1,medicineReport2);
            dbContext.SaveChanges();
        } 

        public List<MedicineReport> GetAll()
        {
            return dbContext.Reports.ToList();
        }

    }
}
