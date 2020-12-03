using Model.Hospital;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IMedicineTypeRepository
    {
        List<MedicineType> GetAllMedicineTypes();
        MedicineType GetMedicineTypeBySerialNumber(string serialNumber);
    }
}
