using Model.Hospital;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IRoomTypeRepository
    {
        List<RoomType> GetAllGetRoomTypes();
        RoomType GetRoomTypeBySerialNumber(string serialNumber);

    }
}
