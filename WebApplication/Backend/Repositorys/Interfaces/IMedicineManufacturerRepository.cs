using Model.Hospital;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IMedicineManufacturerRepository
    {
        List<MedicineManufacturer> GetAllMedicineManufacturers();
        MedicineManufacturer GetMedicineManufacturerBySerialNumber(string serialNumber);
    }
}
