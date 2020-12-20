using HealthClinicBackend.Backend.Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.DTO
{
    public class RoomDTO
    {
        private string name;
        public RoomDTO(Room room)
        {
            Name = room.Name;
        }
        public RoomDTO() { }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<RoomDTO> ConvertListToRoomDTO(List<Room> rooms)
        {
            List<RoomDTO> roomsDTO = new List<RoomDTO>();
            foreach (Room room in rooms)
                roomsDTO.Add(new RoomDTO(room));
            return roomsDTO;
        }
    }
}
