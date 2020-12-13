using HealthClinicBackend.Backend.Model.Hospital;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IBuildingRepository : IGenericRepository<Building>
    {
        List<Building> GetByName(string name);
    }
}
