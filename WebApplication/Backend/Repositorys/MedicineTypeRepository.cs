using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Repositorys
{
    public class MedicineTypeRepository : IMedicineTypeRepository
    {
        private MedicineTypeDatabaseSql _medicineTypeRepository;

        public List<MedicineType> GetAllMedicineTypes()
        {
            return _medicineTypeRepository.GetAll();
        }

        public MedicineType GetMedicineTypeBySerialNumber(string serialNumber)
        {
            return _medicineTypeRepository.GetById(serialNumber);
        }
    }
}
