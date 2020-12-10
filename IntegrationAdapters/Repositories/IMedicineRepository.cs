using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;

namespace IntegrationAdapters.Repositories
{
    public interface IMedicineRepository
    {
        public List<MedicinePharmacy> GetAll();
        void AddMedicineRepository();
        public Medicine GetByName(String Name);

        public MedicineSpecification GetById(string id);
        public List<MedicineSpecification> GetAllSpecifications();
        public bool DoesMedicineExist(Medicine medicine);
    }
}
