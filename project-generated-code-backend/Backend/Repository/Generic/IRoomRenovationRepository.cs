using HealthClinicBackend.Backend.Model.Schedule;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    interface IRoomRenovationRepository : IGenericRepository<RoomRenovation>
    {
        List<RoomRenovation> GetByTimeInterval(string roomRenovationSerialNumber);
    }
}
