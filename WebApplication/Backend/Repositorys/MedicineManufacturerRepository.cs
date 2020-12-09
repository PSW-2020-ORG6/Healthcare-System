using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Repositorys
{
    public class MedicineManufacturerRepository : IMedicineManufacturerRepository
    {
        private readonly MedicineManufacturerDatabaseSql _medicineManufacturerRepository;

        public MedicineManufacturerRepository()
        {
            _medicineManufacturerRepository = new MedicineManufacturerDatabaseSql();
        }

        public List<MedicineManufacturer> GetAllMedicineManufacturers()
        {
            return _medicineManufacturerRepository.GetAll();
        }

        public MedicineManufacturer GetMedicineManufacturerBySerialNumber(string serialNumber)
        {
            return _medicineManufacturerRepository.GetById(serialNumber);
        }
    }
}