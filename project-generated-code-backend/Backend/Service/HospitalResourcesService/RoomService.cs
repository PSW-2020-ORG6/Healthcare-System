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
        private readonly IBedRepository _bedRepository;
        private readonly IMedicineRepository _medicineRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public RoomService()
        {
            _roomRepository = new RoomDatabaseSql();
            _roomTypeRepository = new RoomTypeDatabaseSql();
            _medicineRepository = new MedicineDatabaseSql();
            _equipmentRepository = new EquipmentDatabaseSql();
            _bedRepository = new BedDatabaseSql();
        }

        public RoomService(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository, IMedicineRepository medicineRepository, IEquipmentRepository equipmentRepository)
        {
            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;
            _medicineRepository = medicineRepository;
            _equipmentRepository = equipmentRepository;
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
            Room room = _roomRepository.GetBySerialNumber(serialNumber);
            FillComplexedProperties(room);
            return room;
        }

        public List<Room> GetByName(string name)
        {
            return _roomRepository.GetByName(name);
        }

        public List<Room> GetByFloorSerialNumber(string floorSerialNumber)
        {
            return _roomRepository.GetByFloorSerialNumber(floorSerialNumber);
        }

        public Room GetByPosition(Position position)
        {
            return _roomRepository.GetByPosition(position);
        }

        public List<Room> GetAll()
        {
            List<Room> rooms = new List<Room>();
            foreach (Room room in _roomRepository.GetAll())
            {
                FillComplexedProperties(room);
                rooms.Add(room);
            }
            return rooms;
        }

        public void EditRoom(Room room)
        {
            foreach (Bed bed in _bedRepository.GetByRoomSerialNumber(room.SerialNumber))
                _bedRepository.Update(bed);
            foreach (Equipment equipment in _equipmentRepository.GetByRoomSerialNumber(room.SerialNumber))
                _equipmentRepository.Update(equipment);
            foreach (Medicine medicine in _medicineRepository.GetByRoomSerialNumber(room.SerialNumber))
                _medicineRepository.Update(medicine);
            _roomRepository.Update(room);
        }

        public void NewRoom(Room room)
        {
            _roomRepository.Save(room);
        }

        public void DeleteRoom(Room room)
        {
            foreach (Medicine medicine in _medicineRepository.GetByRoomSerialNumber(room.SerialNumber))
                _medicineRepository.Delete(medicine.SerialNumber);
            foreach (Bed bed in _bedRepository.GetByRoomSerialNumber(room.SerialNumber))
                _bedRepository.Delete(bed.SerialNumber);
            foreach (Equipment equipment in _equipmentRepository.GetByRoomSerialNumber(room.SerialNumber))
                _equipmentRepository.Delete(equipment.SerialNumber);
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

        private void FillComplexedProperties(Room room)
        {
            FillMedicine(room);
            FillBed(room);
            FillEquipment(room);
        }

        private void FillMedicine(Room room)
        {
            if (_medicineRepository != null)
                room.Medicines = _medicineRepository.GetByRoomSerialNumber(room.SerialNumber);
            else
                room.Medicines = new List<Medicine>();
        }

        private void FillBed(Room room)
        {
            if (_bedRepository != null)
                room.Beds = _bedRepository.GetByRoomSerialNumber(room.SerialNumber);
            else
                room.Beds = new List<Bed>();
        }

        private void FillEquipment(Room room)
        {
            if (_equipmentRepository != null)
                room.Equipment = _equipmentRepository.GetByRoomSerialNumber(room.SerialNumber);
            else
                room.Equipment = new List<Equipment>();
        }
    }
}