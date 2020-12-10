using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;
using HealthClinicBackend.Backend.Repository.DatabaseSql;

namespace IntegrationAdapters.Repositories
{
    public class MedicineReportRepository : GenericDatabaseSql<MedicineReport>, IMedicineReportRepository
    {
        // public DbContextOptions<IAHealthCareSystemDbContext> options = new DbContextOptionsBuilder<IAHealthCareSystemDbContext>()
        //         .UseMySql(connectionString: "server=localhost;port=3306;database=newmydb;user=root;password=root").UseLazyLoadingProxies()
        //         .Options;
        // public readonly IAHealthCareSystemDbContext dbContext;

        public MedicineReportRepository()
        {
            // this.dbContext = new IAHealthCareSystemDbContext(options);
        }

        public void AddPrescription()
        {
            List<MedicineDosagePharmacy> medicineDosages = new List<MedicineDosagePharmacy> { new MedicineDosagePharmacy(1,"Brufen", 5), new MedicineDosagePharmacy(2,"Paracetamol", 10), new MedicineDosagePharmacy(3,"Andol", 4) };
            List<MedicineDosagePharmacy> medicineDosages1 = new List<MedicineDosagePharmacy> { new MedicineDosagePharmacy(4, "Brufen", 3), new MedicineDosagePharmacy(5, "Paracetamol", 11), new MedicineDosagePharmacy(6, "Andol", 7) };
            List<MedicineDosagePharmacy> medicineDosages2 = new List<MedicineDosagePharmacy> { new MedicineDosagePharmacy(7, "Brufen", 2), new MedicineDosagePharmacy(8, "Paracetamol", 5), new MedicineDosagePharmacy(9, "Andol", 20) };
            MedicineReport medicineReport = new MedicineReport { Id = "mr1", Date = new DateTime(2020, 5, 21), Dosage = medicineDosages };
            MedicineReport medicineReport1 = new MedicineReport { Id = "mr2", Date = new DateTime(2020, 6, 4), Dosage = medicineDosages1 };
            MedicineReport medicineReport2 = new MedicineReport { Id = "mr3", Date = new DateTime(2020, 10, 11), Dosage = medicineDosages2 };
            dbContext.AddRange(medicineReport,medicineReport1,medicineReport2);
            dbContext.SaveChanges();
        } 

        public override List<MedicineReport> GetAll()
        {
            return dbContext.MedicineReport.ToList();
        }

    }
}
