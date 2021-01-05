// File:    RoomControler.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RoomControler

using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class RoomController
    {
        private readonly RoomService _roomService;

        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

        public Room GetById(String id)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAll()
        {
            return _roomService.GetAll();
        }

        public void EditRoom(Room room)
        {
            _roomService.EditRoom(room);
        }

        public void NewRoom(Room room)
        {
            _roomService.NewRoom(room);
        }

        public void DeleteRoom(Room room)
        {
            _roomService.DeleteRoom(room);
        }

        public void AddEquipment(Equipment equipment, Room room)
        {
            _roomService.AddEquipment(equipment, room);
        }

        public void RemoveEquipmentById(String id, Room room)
        {
            _roomService.RemoveEquipmentById(id, room);
        }

        public List<Equipment> GetAllEquipment(Room room)
        {
            return _roomService.GetAllEquipment(room);
        }

        public List<RoomType> GetAllRoomTypes()
        {
            return _roomService.GetAllRoomTypes();
        }

        public List<RoomType> GetAllAutoRoomTypes()
        {
            return _roomService.GetAutoAllRoomTypes();
        }


        public void AddRoomTypes(RoomType roomType)
        {
            _roomService.AddRoomType(roomType);
        }

        public bool RoomNumberExists(int RoomNumber)
        {
            return _roomService.RoomNumberExists(RoomNumber);
        }
    }
}