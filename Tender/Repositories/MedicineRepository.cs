using TenderProcurement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderProcurement.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        public DbContextOptions<IAHealthCareSystemDbContext> options = new DbContextOptionsBuilder<IAHealthCareSystemDbContext>()
               .UseNpgsql(connectionString: "server=localhost;port=5432;database=newmydb;User ID=postgres;password=super").UseLazyLoadingProxies()
               .Options;
        public readonly IAHealthCareSystemDbContext dbContext;

        public MedicineRepository()
        {
            this.dbContext = new IAHealthCareSystemDbContext(options);
        }


         public void AddMedicine(Medicine medicine)
        {
            dbContext.Add(medicine);
            dbContext.SaveChanges();
        }

        public List<Medicine> GetAll()
        {
            return dbContext.Medicine.ToList();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public Medicine GetByName(string Name)
        {
            foreach (Medicine medicine in GetAll())
            {
                if (medicine.Name.Equals(Name)) return medicine;
            }
            return null;
        }
        public bool DoesMedicineExist(Medicine medicine)
        {
            List<Medicine> medicines = dbContext.Medicine.ToList();
            foreach (Medicine m in medicines)
            {
                if (m.MedicineID.Equals(medicine.MedicineID)) return true;
            }
            return false;
        }
    }
}
