using health_clinic_class_diagram.Backend.Model.Hospital;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public interface IRoomRepository
    {
        List<RoomGEA> GetRooms(String sqlDml);
        List<RoomGEA> GetAllRooms();
        RoomGEA GetRoomById(String sqlDml);
        RoomGEA GetRoomByName(String sqlDml);
        RoomGEA GetRoomByFloorId(String sqlDml);
    }
}
