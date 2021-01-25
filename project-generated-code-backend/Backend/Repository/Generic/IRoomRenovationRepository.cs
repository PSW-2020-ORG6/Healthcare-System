using HealthClinicBackend.Backend.Model.Schedule;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    interface IRoomRenovationRepository : IGenericRepository<RoomRenovation>
    {
        List<RoomRenovation> GetByTimeInterval(string roomRenovationSerialNumber);
    }
}
