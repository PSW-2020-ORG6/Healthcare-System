using Model.Hospital;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Service.MedicineService;

namespace Backend.Controller.SuperintendentControllers
{
    public class SuperintendentMedicineController
    {
        private SuperintendentMedicineService superintendentMedicineService;
        public SuperintendentMedicineController()
        {
            superintendentMedicineService = new SuperintendentMedicineService();
        }
        public List<Medicine> getAllApproved()
        {
            return superintendentMedicineService.GetAllApproved();
        }

        public List<Rejection> getAllRejected()
        {
            return superintendentMedicineService.GetAllRejected();
        }

        public List<Medicine> getAllWaiting()
        {
            return superintendentMedicineService.GetAllWaiting();
        }

        public void DeleteWaitingMedicine(Medicine medicine)
        {
            superintendentMedicineService.DeleteWaitingMedicine(medicine);
        }

        public void NewWaitinMedicine(Medicine medicine)
        {
            superintendentMedicineService.NewWaitingMedicine(medicine);
        }

        public void EditWaitingMedicine(Medicine medicineDTO)
        {
            superintendentMedicineService.EditWaitingMedicine(medicineDTO);
        }

        public void DeleteRejection(Rejection rejection)
        {
            superintendentMedicineService.DeleteRejection(rejection);
        }

        public void NewRejection(Rejection rejection)
        {
            superintendentMedicineService.NewRejection(rejection);
        }

        public void EditRejection(Rejection rejection)
        {
            superintendentMedicineService.EditRejection(rejection);
        }

        public void DeleteApprovedMedicine(Medicine medicine)
        {
            superintendentMedicineService.DeleteApprovedMedicine(medicine);
        }
        public void NewApprovedMedicine(Medicine medicine)
        {
            superintendentMedicineService.NewApprovedMedicine(medicine);
        }
    }
}
