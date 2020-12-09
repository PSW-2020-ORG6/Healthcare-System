using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IMedicineTypeRepository
    {
        List<MedicineType> GetAllMedicineTypes();
        MedicineType GetMedicineTypeBySerialNumber(string serialNumber);
    }
}
