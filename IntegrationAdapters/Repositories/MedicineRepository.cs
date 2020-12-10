using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;

namespace IntegrationAdapters.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        public DbContextOptions<IAHealthCareSystemDbContext> options = new DbContextOptionsBuilder<IAHealthCareSystemDbContext>()
               .UseMySql(connectionString: "server=localhost;port=3306;database=newmydb;user=root;password=root").UseLazyLoadingProxies()
               .Options;
        public readonly IAHealthCareSystemDbContext dbContext;

        public MedicineRepository()
        {
            this.dbContext = new IAHealthCareSystemDbContext(options);
        }
        public void AddMedicineRepository()
        {
            MedicineSpecification medicineSpecifications = new MedicineSpecification("1", "sastav", "tip", "tableta", "poruka", "sa receptom", "jankovic", new List<string>() { "123", "123" });
            MedicineSpecification medicineSpecifications1 = new MedicineSpecification("2", "sastav4", "tip4", "tableta", "poruka4", "sa receptom", "zgin", new List<string>() { "123", "123" });
            MedicineSpecification medicineSpecifications2 = new MedicineSpecification("3", "sastav7", "tip7", "tableta", "poruka7", "sa receptom", "jankovic", new List<string>() { "123", "123" });
            MedicinePharmacy medicinePharmacy = new MedicinePharmacy { MedicineID = "1", Name = "Brufen", MedicineSpecificationID = "1" };
            MedicinePharmacy medicine1 = new MedicinePharmacy { MedicineID = "2", Name = "Paracetamol", MedicineSpecificationID = "2" };
            MedicinePharmacy medicine2 = new MedicinePharmacy { MedicineID = "3", Name = "Frveks", MedicineSpecificationID = "3" };


            dbContext.AddRange(medicineSpecifications, medicineSpecifications1, medicineSpecifications2);
            dbContext.AddRange(medicinePharmacy, medicine1, medicine2);
            dbContext.SaveChanges();
        }

        public List<MedicinePharmacy> GetAll()
        {
            return dbContext.Medicine.ToList();
        }

        public MedicinePharmacy GetByID(string ID)
        {
            foreach (MedicinePharmacy medicine in GetAll())
            {
                if (medicine.MedicineID.Equals(ID)) return medicine;
            }
            return null;
        }

        public MedicinePharmacy GetByName(string Name)
        {
            foreach (MedicinePharmacy medicine in GetAll())
            {
                if (medicine.Name.Equals(Name)) return medicine;
            }
            return null;
        }
    }
}
