using health_clinic_class_diagram.Backend.Model.Hospital;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        List<RoomGEA> GetAllRooms();
        List<RoomGEA> GetRoomsByName(string name);
    }
}
