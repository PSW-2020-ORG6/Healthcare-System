using System.Collections.Generic;
using HealthClinicBackend.Backend.Service.MedicineService;
using Model.Hospital;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class SuperintendentMedicineController
    {
        private SuperintendentMedicineService superintendentMedicineService;
        public SuperintendentMedicineController()
        {
            superintendentMedicineService = new SuperintendentMedicineService();
        }
        public List<Medicine> GetAllApproved()
        {
            return superintendentMedicineService.GetAllApproved();
        }

        public List<Rejection> GetAllRejected()
        {
            return superintendentMedicineService.GetAllRejected();
        }

        public List<Medicine> GetAllWaiting()
        {
            return superintendentMedicineService.GetAllWaiting();
        }

        public void DeleteWaitingMedicine(Medicine medicine)
        {
            superintendentMedicineService.DeleteWaitingMedicine(medicine);
        }

        public void NewWaitingMedicine(Medicine medicine)
        {
            superintendentMedicineService.NewWaitingMedicine(medicine);
        }

        public void EditWaitingMedicine(Medicine medicineDto)
        {
            superintendentMedicineService.EditWaitingMedicine(medicineDto);
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
