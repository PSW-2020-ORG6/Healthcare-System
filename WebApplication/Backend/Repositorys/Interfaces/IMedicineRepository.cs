using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IMedicineRepository
    {
        List<Medicine> GetMedicinesByName(string name);
        List<Medicine> GetAllMedicines();
    }
}
