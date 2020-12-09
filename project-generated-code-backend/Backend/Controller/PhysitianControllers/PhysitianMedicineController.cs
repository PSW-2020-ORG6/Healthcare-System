using Model.Hospital;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Service.MedicineService;

namespace Backend.Controller.PhysitianControllers
{
    public class PhysitianMedicineController
    {
        private PhysicianMedicineService _physicianMedicineService;
        public PhysitianMedicineController()
        {
            this._physicianMedicineService = new PhysicianMedicineService();
        }

        public List<MedicineManufacturer> GetMedicineManufacturers()
        {
            return _physicianMedicineService.GetMedicineManufacturers();
        }
        public List<Medicine> getAllFromWaitingList()
        {
            return _physicianMedicineService.GetAllFromWaitingList();
        }
        public List<Medicine> getAllApproved()
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
