using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.MedicineService;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class PhysicianMedicineController
    {
        private PhysicianMedicineService _physicianMedicineService;

        public PhysicianMedicineController(PhysicianMedicineService physicianMedicineService)
        {
            _physicianMedicineService = physicianMedicineService;
        }

        public List<MedicineManufacturer> GetMedicineManufacturers()
        {
            return _physicianMedicineService.GetMedicineManufacturers();
        }

        public List<Medicine> GetAllFromWaitingList()
        {
            return _physicianMedicineService.GetAllFromWaitingList();
        }

        public List<Medicine> GetAllApproved()
        {
            return _physicianMedicineService.GetAllApproved();
        }

        public void Approve(Medicine medicine)
        {
            _physicianMedicineService.Approve(medicine);
        }

        public void Reject(Rejection rejection)
        {
            _physicianMedicineService.Reject(rejection);
        }
    }
}