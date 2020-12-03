using Model.Hospital;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IMedicineRepository
    {
        List<Medicine> GetMedicinesByName(string name);
        List<Medicine> GetAllMedicines();
    }
}
