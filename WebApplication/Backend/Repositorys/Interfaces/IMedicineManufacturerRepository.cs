using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IMedicineManufacturerRepository
    {
        List<MedicineManufacturer> GetAllMedicineManufacturers();
        MedicineManufacturer GetMedicineManufacturerBySerialNumber(string serialNumber);
    }
}
