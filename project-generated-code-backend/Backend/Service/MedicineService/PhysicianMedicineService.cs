﻿using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.FileSystem;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Service.MedicineService
{
    public class PhysicianMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IRejectionRepository _rejectionRepository;

        public PhysicianMedicineService()
        {
            _medicineRepository = new MedicineDatabaseSql();
            _rejectionRepository = new RejectionFileSystem();
        }

        public PhysicianMedicineService(IMedicineRepository medicineRepository)
        {
            this._medicineRepository = medicineRepository;
        }

        public List<Medicine> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return _medicineRepository.GetByRoomSerialNumber(roomSerialNumber);
        }

        public List<Medicine> GetAll()
        {
            return _medicineRepository.GetAll();
        }

        public List<Medicine> GetByName(string name)
        {
            return _medicineRepository.GetByName(name);
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