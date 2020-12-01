using Model.Hospital;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IMedicineRepository
    {
        List<Medicine> GetMedicinesByName(string name);
        List<Medicine> GetAllMedicines();
    }
}
