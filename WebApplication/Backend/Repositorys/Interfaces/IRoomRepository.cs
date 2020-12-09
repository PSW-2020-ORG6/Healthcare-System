using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IRoomRepository
    {
        List<Room> GetAllRooms();
        List<Room> GetRoomsByName(string name);
        Room GetRoomBySerialNumber(string serialNumber);
        List<Room> GetRoomsByFloorSerialNumber(string floorSerialNumber);
    }
}
