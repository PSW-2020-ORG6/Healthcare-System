using Model.Hospital;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IMedicineManufacturerRepository
    {
        List<MedicineManufacturer> GetAllMedicineManufacturers();
        MedicineManufacturer GetMedicineManufacturerBySerialNumber(string serialNumber);
    }
}
