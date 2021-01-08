using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class RoomFileSystem : GenericFileSystem<Room>, IRoomRepository
    {
        public RoomFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/rooms.txt";
            path = @"./../../data/rooms.txt";
        }

        public List<Room> GetByProcedureType(ProcedureType procedureType)
        {
            List<Room> rooms = new List<Room>();
            foreach (Room room in GetAll())
            {
                if (room.ContainsAllEquipment(procedureType.RequiredEquipment))
                {
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public List<Room> GetByRoomType(RoomType roomType)
        {
            List<Room> rooms = new List<Room>();
            foreach (Room room in GetAll())
            {
                if (room.RoomType.Equals(roomType))
                {
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public List<Room> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<Room> GetByFloorSerialNumber(string floorSerialNumber)
        {
            throw new System.NotImplementedException();
        }

        public override Room Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Room>(objectStringFormat);
        }

        public Room GetBySerialNumber(string serialNumber)
        {
            throw new System.NotImplementedException();
        }

        public Room GetByPosition(Position position)
        {
            throw new System.NotImplementedException();
        }
    }
}