using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IBuildingRepository : IGenericRepository<Building>
    {
        List<Building> GetByName(string name);
    }
}
