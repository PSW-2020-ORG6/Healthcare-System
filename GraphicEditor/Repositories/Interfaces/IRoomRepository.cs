using health_clinic_class_diagram.Backend.Model.Hospital;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        List<RoomGEA> GetRooms(String sqlDml);
        List<RoomGEA> GetAllRooms();
        List<RoomGEA> GetRoomsByName(string name);
    }
}
