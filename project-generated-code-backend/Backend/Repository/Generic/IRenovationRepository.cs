using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;

namespace Backend.Repository
{
    public interface IRenovationRepository : IGenericRepository<Renovation>
    {
        List<Renovation> GetRenovationsByRoom(Room room);
    }
}
