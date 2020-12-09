using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Repositorys
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomDatabaseSql _roomRepository;

        public RoomRepository()
        {
            _roomRepository = new RoomDatabaseSql();
        }

        public List<Room> GetAllRooms()
        {
            return _roomRepository.GetAll();
        }

        public List<Room> GetRoomsByName(string name)
        {
            return _roomRepository.GetByName(name);
        }

        public Room GetRoomBySerialNumber(string serialNumber)
        {
            return _roomRepository.GetById(serialNumber);
        }

        public List<Room> GetRoomsByFloorSerialNumber(string floorSerialNumber)
        {
            return _roomRepository.GetByFloorSerialNumber(floorSerialNumber);
        }
    }
}