// File:    RoomFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RoomFileSystem

using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

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

    }
}