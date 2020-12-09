using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services
{
    public class MedicineService
    {
        private IMedicineRepository medicineRepository;

        public MedicineService()
        {
            this.medicineRepository = new MedicineRepository();
        }
      /*  public MedicineService(IMedicineRepository medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }*/
        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
        }
        public Medicine GetMedicineByID(String ID)
        {
            return medicineRepository.GetByID(ID);
        }
        public Medicine GetMedicineByName(String Name)
        {
            return medicineRepository.GetByName(Name);
        }
        public void AddMedicine()
        {
            medicineRepository.AddMedicineRepository();
        }
    }
}
