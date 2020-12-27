// File:    RoomControler.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RoomControler

using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class RoomController
    {
        private readonly RoomService _roomService;

        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }


        public RoomController()
        {
            _roomService = new RoomService();
        }

        public Room GetById(String id)
        {
            return _roomService.GetById(id);
        }

        public Room GetBySerialNumber(String serialNumber)
        {
            return roomService.GetBySerialNumber(serialNumber);
        }

        public List<Room> GetByName(string name)
        {
            return _roomService.GetByName(name);
        }

        public List<Room> GetByFloorSerialNumber(string floorSerialNumber)
        {
            return roomService.GetByFloorSerialNumber(floorSerialNumber);
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