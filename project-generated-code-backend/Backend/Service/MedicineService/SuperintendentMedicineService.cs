using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Service.MedicineService
{
    public class SuperintendentMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IRejectionRepository _rejectionRepository;

        public SuperintendentMedicineService()
        {
            _medicineRepository = new MedicineDatabaseSql();
            _rejectionRepository = new RejectionDatabaseSql();
        }

        public SuperintendentMedicineService(IMedicineRepository medicineRepository,
            IRejectionRepository rejectionRepository)
        {
            _medicineRepository = medicineRepository;
            _rejectionRepository = rejectionRepository;
        }

        public SuperintendentMedicineService(IMedicineRepository medicineRepository)
        {
            this._medicineRepository = medicineRepository;
        }

        public List<Medicine> GetAll()
        {
            return _medicineRepository.GetAll();
        }

        public List<Medicine> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return _medicineRepository.GetByRoomSerialNumber(roomSerialNumber);
        }

        public List<Medicine> GetByName(string name)
        {
            return _medicineRepository.GetByName(name);
        }

        public List<Medicine> GetAllApproved()
        {
            return _medicineRepository.GetApproved();
        }

        public List<Rejection> GetAllRejected()
        {
            return _rejectionRepository.GetAll();
        }

        public List<Medicine> GetAllWaiting()
        {
            return _medicineRepository.GetWaiting();
        }

        public void DeleteWaitingMedicine(Medicine medicine)
        {
            _medicineRepository.Delete(medicine.SerialNumber);
        }

        public void NewWaitingMedicine(Medicine medicine)
        {
            medicine.IsApproved = false;
            _medicineRepository.Save(medicine);
        }

        public void EditWaitingMedicine(Medicine medicineDto)
        {
            _medicineRepository.Update(medicineDto);
        }

        public void DeleteRejection(Rejection rejection)
        {
            _rejectionRepository.Delete(rejection.SerialNumber);
        }

        public void NewRejection(Rejection rejection)
        {
            _rejectionRepository.Save(rejection);
        }

        public void EditRejection(Rejection rejection)
        {
            _medicineRepository.Save(rejection.Medicine);
            _rejectionRepository.Delete(rejection.SerialNumber);
        }

        public void DeleteApprovedMedicine(Medicine medicine)
        {
            _medicineRepository.Delete(medicine.SerialNumber);
        }

        public void NewApprovedMedicine(Medicine medicine)
        {
            medicine.IsApproved = true;
            _medicineRepository.Save(medicine);
        }
    }
}