// File:    RoomService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RoomService

using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomService(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository)
        {
            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;
        }

        public Room GetById(String id)
        {
            throw new NotImplementedException();
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