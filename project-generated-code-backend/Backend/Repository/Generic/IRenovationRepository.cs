using HealthClinicBackend.Backend.Model.Hospital;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IRenovationRepository : IGenericRepository<Renovation>
    {
        List<Renovation> GetRenovationsByRoom(Room room);
    }
}
