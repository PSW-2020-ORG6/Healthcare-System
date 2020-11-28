using health_clinic_class_diagram.Backend.Model.Hospital;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public interface IRoomRepository
    {
        List<RoomGEA> GetAllRooms();
        List<RoomGEA> GetRoomsByName(string name);
    }
}
