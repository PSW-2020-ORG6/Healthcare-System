using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;

namespace IntegrationAdapters.Repositories
{
    interface IMedicineRepository
    {
        public List<MedicinePharmacy> GetAll();
        void AddMedicineRepository();
        public MedicinePharmacy GetByID(String ID);
        public MedicinePharmacy GetByName(String Name);
    }
}
