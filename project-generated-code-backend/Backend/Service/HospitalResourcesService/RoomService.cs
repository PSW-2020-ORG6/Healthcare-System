using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomService()
        {
            _roomRepository = new RoomDatabaseSql();
            _roomTypeRepository = new RoomTypeDatabaseSql();
        }

        public RoomService(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository)
        {
            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;
        }

        public RoomService(IRoomRepository roomRepository)
        {
            this._roomRepository = roomRepository;
        }

        public Room GetById(string id)
        {
            return _roomRepository.GetById(id);
        }

        public Room GetBySerialNumber(String serialNumber)
        {
            return _roomRepository.GetBySerialNumber(serialNumber);
        }

        public List<Room> GetByName(string name)
        {
            return _roomRepository.GetByName(name);
        }

        public List<Room> GetByFloorSerialNumber(string floorSerialNumber)
        {
            return _roomRepository.GetByFloorSerialNumber(floorSerialNumber);
        }

        public List<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public void EditRoom(Room room)
        {
            _roomRepository.Update(room);
        }

        public void NewRoom(Room room)
        {
            _roomRepository.Save(room);
        }

        public void DeleteRoom(Room room)
        {
            _roomRepository.Delete(room.SerialNumber);
        }

        public void AddEquipment(Equipment equipment, Room room)
        {
            room.AddEquipment(equipment);
            _roomRepository.Update(room);
        }

        public void RemoveEquipmentById(String id, Room room)
        {
            foreach (Equipment e in room.Equipment.ToList())
            {
                if (e.SerialNumber.Equals(id))
                {
                    room.RemoveEquipment(e);
                }
            }

            _roomRepository.Update(room);
        }

        public List<RoomType> GetAllRoomTypes()
        {
            return _roomTypeRepository.GetAll();
        }

        public List<RoomType> GetAutoAllRoomTypes()
        {
            List<RoomType> types = new List<RoomType>();
            types.AddRange(_roomTypeRepository.GetAll());
            return types;
        }

        public void AddRoomType(RoomType roomType)
        {
            _roomTypeRepository.Save(roomType);
        }

        public bool RoomNumberExists(int RoomNumber)
        {
            bool exists = false;
            foreach (Room r in _roomRepository.GetAll())
            {
                if (r.Id == RoomNumber)
                {
                    exists = true;
                }
            }

            return exists;
        }

        public List<Equipment> GetAllEquipment(Room room)
        {
            return _roomRepository.GetById(room.SerialNumber).Equipment;
        }
    }
}