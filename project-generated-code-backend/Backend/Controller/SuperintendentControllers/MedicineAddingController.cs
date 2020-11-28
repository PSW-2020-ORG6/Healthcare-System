using health_clinic_class_diagram.Backend.Service.MedicineService;
using Model.Hospital;
using System;

namespace Backend.Controller.SuperintendentControllers
{
    class MedicineAddingController
    {
        private MedicineAddingService medicineAddingService;
        public void addMedicineToWaiting(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void removeFromRejected(Rejection rejectedMedicine)
        {
            throw new NotImplementedException();
        }

        public void editRejectedMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public Rejection getFromRejected(Rejection rejectedMedicine)
        {
            throw new NotImplementedException();
        }
    }
}
