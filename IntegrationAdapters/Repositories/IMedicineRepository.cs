using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories
{
    public interface IMedicineRepository
    {
        public List<Medicine> GetAll();
	public void SaveChanges();
        void AddMedicineRepository();
        public Medicine GetByName(String Name);

        public MedicineSpecification GetById(string id);
        public List<MedicineSpecification> GetAllSpecifications();
        public bool DoesMedicineExist(Medicine medicine);
	public void AddMedicine(Medicine medicine);    
}
}
