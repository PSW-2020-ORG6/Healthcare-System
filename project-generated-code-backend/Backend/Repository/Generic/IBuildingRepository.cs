using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.Hospital;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IBuildingRepository : IGenericRepository<Building>
    {
        List<Building> GetByName(string name);
    }
}
