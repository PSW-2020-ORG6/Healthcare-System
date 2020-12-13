using HealthClinicBackend.Backend.Model.Hospital;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IBedRepository : IGenericRepository<Bed>
    {
        List<Bed> GetByRoomSerialNumber(string roomSerialNumber);
    }
}