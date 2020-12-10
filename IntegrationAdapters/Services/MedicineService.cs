using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;

namespace IntegrationAdapters.Services
{
    public class MedicineService
    {
        private IMedicineRepository medicineRepository;

        public MedicineService()
        {
            this.medicineRepository = new MedicineRepository();
        }
        public List<MedicinePharmacy> GetAll()
        {
            return medicineRepository.GetAll();
        }
        public MedicinePharmacy GetMedicineByID(String ID)
        {
            return medicineRepository.GetByID(ID);
        }
        public MedicinePharmacy GetMedicineByName(String Name)
        {
            return medicineRepository.GetByName(Name);
        }
        public void AddMedicine()
        {
            medicineRepository.AddMedicineRepository();
        }
    }
}
