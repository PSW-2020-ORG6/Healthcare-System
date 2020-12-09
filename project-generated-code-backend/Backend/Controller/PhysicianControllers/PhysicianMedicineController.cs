using System.Collections.Generic;
using HealthClinicBackend.Backend.Service.MedicineService;
using Model.Hospital;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class PhysicianMedicineController
    {
        private PhysicianMedicineService _physicianMedicineService;
        public PhysicianMedicineController()
        {
            this._physicianMedicineService = new PhysicianMedicineService();
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
