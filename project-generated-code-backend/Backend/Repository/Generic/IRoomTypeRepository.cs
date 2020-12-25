using HealthClinicBackend.Backend.Model.Hospital;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IRoomTypeRepository : IGenericRepository<RoomType>
    {
        List<RoomType> GetByName(string name);
    }
}
