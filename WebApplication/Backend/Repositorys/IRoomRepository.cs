using health_clinic_class_diagram.Backend.Model.Hospital;
using Model.Hospital;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public interface IRoomRepository
    {
        List<Room> GetAllRooms();
        List<Room> GetRoomsByName(string name);
    }
}
