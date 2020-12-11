using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Medicine medicine = new Medicine { MedicineID = "1", Name = "Brufen", MedicineSpecificationID = "1" };
            Medicine medicine1 = new Medicine { MedicineID = "2", Name = "Paracetamol", MedicineSpecificationID = "2" };
            Medicine medicine2 = new Medicine { MedicineID = "3", Name = "Frveks", MedicineSpecificationID = "3" };


            dbContext.AddRange(medicineSpecifications, medicineSpecifications1, medicineSpecifications2);
            dbContext.AddRange(medicine, medicine1, medicine2);
            dbContext.SaveChanges();
        }

        public List<Medicine> GetAll()
        {
            return dbContext.Medicine.ToList();
        }

        public MedicineSpecification GetById(string id)
        {
            return dbContext.MedicineSpecification.Find(id);
        }

        public Medicine GetByID(string ID)
        {
            foreach (Medicine medicine in GetAll())
            {
                if (medicine.MedicineID.Equals(ID)) return medicine;
            }
            return null;
        }

        public Medicine GetByName(string Name)
        {
            foreach (Medicine medicine in GetAll())
            {
                if (medicine.Name.Equals(Name)) return medicine;
            }
            return null;
        }
    }
}
