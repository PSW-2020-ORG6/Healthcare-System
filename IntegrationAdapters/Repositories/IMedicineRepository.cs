using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;
using HealthClinicBackend.Backend.Repository.Generic;

namespace IntegrationAdapters.Repositories
{
    interface IMedicineRepository: IGenericRepository<MedicinePharmacy>
    {
        public List<MedicinePharmacy> GetAll();
        void AddMedicineRepository();
        public MedicinePharmacy GetByID(String ID);
        public MedicinePharmacy GetByName(String Name);
    }
}
