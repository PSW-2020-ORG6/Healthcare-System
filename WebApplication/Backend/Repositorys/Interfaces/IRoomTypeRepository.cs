using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IRoomTypeRepository
    {
        List<RoomType> GetAllGetRoomTypes();
        RoomType GetRoomTypeBySerialNumber(string serialNumber);

    }
}
