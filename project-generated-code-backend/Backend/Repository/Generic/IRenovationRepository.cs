using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IRenovationRepository : IGenericRepository<Renovation>
    {
        List<Renovation> GetRenovationsByRoom(Room room);
    }
}
