using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class RoomController
    {
        public RoomService roomService;

        public RoomController()
        {
            roomService = new RoomService();
        }

        public Room GetById(String id)
        {
            return roomService.GetById(id);
        }

        public Room GetBySerialNumber(String serialNumber)
        {
            return roomService.GetBySerialNumber(serialNumber);
        }

        public List<Room> GetByName(string name)
        {
            return roomService.GetByName(name);
        }

        public List<Room> GetByFloorSerialNumber(string floorSerialNumber)
        {
            return roomService.GetByFloorSerialNumber(floorSerialNumber);
        }

        public Room GetByPositionSerialNumber(string positionSerialNumber)
        {
            return roomService.GetByPositionSerialNumber(positionSerialNumber);
        }

        public List<Room> GetAll()
        {
            return roomService.GetAll();
        }

        public void EditRoom(Room room)
        {
            roomService.EditRoom(room);
        }

        public void NewRoom(Room room)
        {
            roomService.NewRoom(room);
        }

        public void DeleteRoom(Room room)
        {
            roomService.DeleteRoom(room);
        }

        public void AddEquipment(Equipment equipment, Room room)
        {
            roomService.AddEquipment(equipment, room);
        }

        public void RemoveEquipmentById(String id, Room room)
        {
            roomService.RemoveEquipmentById(id, room);
        }

        public List<Equipment> GetAllEquipment(Room room)
        {
            return roomService.GetAllEquipment(room);
        }

        public List<RoomType> GetAllRoomTypes()
        {
            return roomService.GetAllRoomTypes();
        }

        public List<RoomType> GetAllAutoRoomTypes()
        {
            return roomService.GetAutoAllRoomTypes();
        }

        public void AddRoomTypes(RoomType roomType)
        {
            roomService.AddRoomType(roomType);
        }

        public bool RoomNumberExists(int RoomNumber)
        {
            return roomService.RoomNumberExists(RoomNumber);
        }
    }
}