using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.MedicineService
{
    public class PhysicianMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IRejectionRepository _rejectionRepository;

        public PhysicianMedicineService(IMedicineRepository medicineRepository,
            IRejectionRepository rejectionRepository)
        {
            _medicineRepository = medicineRepository;
            _rejectionRepository = rejectionRepository;
        }

        public List<Medicine> GetAllFromWaitingList()
        {
            return _medicineRepository.GetWaiting();
        }

        public List<Medicine> GetAllApproved()
        {
            return _medicineRepository.GetApproved();
        }

        public List<Medicine> GetAllMedicine()
        {
            return _medicineRepository.GetAll();
        }

        public List<MedicineManufacturer> GetMedicineManufacturers()
        {
            return GetAllMedicine().Select(m => m.MedicineManufacturer).Distinct().ToList();
        }

        public void Approve(Medicine medicine)
        {
            medicine.IsApproved = true;
            _medicineRepository.Update(medicine);
        }

        public void Reject(Rejection rejection)
        {
            _medicineRepository.Delete(rejection.Medicine.SerialNumber);
            _rejectionRepository.Save(rejection);
        }
    }
}