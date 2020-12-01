using Model.Hospital;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IMedicineTypeRepository
    {
        List<MedicineType> GetAllMedicineTypes();
        MedicineType GetMedicineTypeBySerialNumber(string serialNumber);
    }
}
