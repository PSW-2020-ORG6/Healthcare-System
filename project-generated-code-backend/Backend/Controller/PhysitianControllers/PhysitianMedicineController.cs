using health_clinic_class_diagram.Backend.Service.MedicineService;
using Model.Hospital;
using System.Collections.Generic;

namespace Backend.Controller.PhysitianControllers
{
    public class PhysitianMedicineController
    {
        private PhysitianMedicineService physitianMedicineService;
        public PhysitianMedicineController()
        {
            this.physitianMedicineService = new PhysitianMedicineService();
        }

        public List<MedicineManufacturer> GetMedicineManufacturers()
        {
            return physitianMedicineService.GetMedicineManufacturers();
        }
        public List<Medicine> getAllFromWaitingList()
        {
            return physitianMedicineService.getAllFromWaitingList();
        }
        public List<Medicine> getAllApproved()
        {
            return physitianMedicineService.getAllApproved();
        }
        public void Approve(Medicine medicine)
        {
            physitianMedicineService.Approve(medicine);
        }
        public void Reject(Rejection rejection)
        {
            physitianMedicineService.Reject(rejection);
        }
    }
}
