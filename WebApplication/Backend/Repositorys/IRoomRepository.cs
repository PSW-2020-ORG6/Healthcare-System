using Model.Hospital;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public interface IRoomRepository
    {
        List<Room> GetAllRooms();
        List<Room> GetRoomsByName(string name);
        Room GetRoomBySerialNumber(string serialNumber);
        List<Room> GetRoomsByFloorSerialNumber(string floorSerialNumber);
    }
}
