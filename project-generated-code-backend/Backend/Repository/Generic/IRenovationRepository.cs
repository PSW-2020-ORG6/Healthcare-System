using HealthClinic.Backend.Model.Hospital;
using Model.Hospital;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IRenovationRepository : IGenericRepository<Renovation>
    {
        List<Renovation> GetRenovationsByRoom(Room room);
    }
}
