using HealthClinic.Backend.Model.Hospital;
using Model.Hospital;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface RenovationRepository : GenericRepository<Renovation>
    {
        List<Renovation> GetRenovationsByRoom(Room room);
    }
}
