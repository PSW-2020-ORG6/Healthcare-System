using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Service.SchedulingService
{
    public class RoomRenovationService
    {
        private IRoomRenovationRepository _roomRenovationRepository;
        private IRoomRepository _roomRepository;
        private IMedicineRepository _medicineRepository;
        private IEquipmentRepository _equipmentRepository;
        private IBedRepository _bedRepository;
        public RoomRenovationService()
        {
            _roomRenovationRepository = new RoomRenovationDatabaseSql();
            _roomRepository = new RoomDatabaseSql();
            _medicineRepository = new MedicineDatabaseSql();
            _equipmentRepository = new EquipmentDatabaseSql();
            _bedRepository = new BedDatabaseSql();
        }

        public void AddRoomRenovation(RoomRenovation roomRenovation)
        {
            _roomRenovationRepository.Save(roomRenovation);
        }

        public void DeleteRoomRenovation(RoomRenovation roomRenovation)
        {
            _roomRenovationRepository.Delete(roomRenovation.SerialNumber);
        }

        public List<RoomRenovation> GetAll()
        {
            List<RoomRenovation> roomRenovations = _roomRenovationRepository.GetAll();
            foreach (RoomRenovation roomRenovation in roomRenovations)
            {
                AddMissingProperties(roomRenovation);
            }
            return roomRenovations;
        }

        public RoomRenovation GetBySerialNumber(string serialNumber)
        {
            RoomRenovation roomRenovation = _roomRenovationRepository.GetById(serialNumber);
            AddMissingProperties(roomRenovation);
            return roomRenovation;
        }

        public List<Room> GetRoomsByOverlappingTimeInterval()
        {
            List<RoomRenovation> roomRenovations = _roomRenovationRepository.GetAll();
            List<Room> returnList = new List<Room>();

            foreach(RoomRenovation rr in roomRenovations)
            {
                AddMissingProperties(rr);
                if (hasStarted(rr)) returnList.AddRange(rr.RenovatingRooms);
            }
            return returnList;
        }

        public void ExecuteRoomRenovation()
        {
            foreach (RoomRenovation roomRenovation in GetAll())
            {
                AddMissingProperties(roomRenovation);
                if (hasStarted(roomRenovation)) StartRenovating(roomRenovation);
                if (hasEnded(roomRenovation)) EndRenovating(roomRenovation);
            }
        }

        private bool hasStarted(RoomRenovation roomRenovation)
        {
            if (roomRenovation.TimeInterval.IsOverLapping(new TimeInterval(DateTime.Now, DateTime.Now))) return true;
            return false;
        }

        private bool hasEnded(RoomRenovation roomRenovation)
        {
            if (roomRenovation.TimeInterval.End < DateTime.Now) return true;
            return false;
        }

        private void StartRenovating(RoomRenovation roomRenovation)
        {
            if(!roomRenovation.Description.Contains("Split"))
            {
                foreach (Room room in _roomRepository.GetByRoomRenovationSerialNumber(roomRenovation.SerialNumber))
                {
                    if (room.IsBeingRenovated) continue;

                    foreach (Equipment equipment in _equipmentRepository.GetByRoomSerialNumber(room.SerialNumber))
                    {
                        equipment.RoomSerialNumber = roomRenovation.RenovatedRoomSerialNumber;
                        _equipmentRepository.Update(equipment);
                    }
                    foreach (Medicine medicine in _medicineRepository.GetByRoomSerialNumber(room.SerialNumber))
                    {
                        medicine.RoomSerialNumber = roomRenovation.RenovatedRoomSerialNumber;
                        _medicineRepository.Update(medicine);
                    }
                    foreach (Bed bed in _bedRepository.GetByRoomSerialNumber(room.SerialNumber))
                    {
                        bed.RoomSerialNumber = roomRenovation.RenovatedRoomSerialNumber;
                        _bedRepository.Update(bed);
                    }
                    room.IsWaitingToBeRenovated = false;
                    room.IsBeingRenovated = true;
                    _roomRepository.Update(room);
                }
                Room renovatedRoom = _roomRepository.GetBySerialNumber(roomRenovation.RenovatedRoomSerialNumber);
                if (renovatedRoom.IsBeingRenovated) return;
                renovatedRoom.IsWaitingToBeRenovated = false;
                renovatedRoom.IsBeingRenovated = true;
                _roomRepository.Update(roomRenovation.RenovatedRoom);
            }
            else
            {
                foreach (Room room in _roomRepository.GetAll())
                {
                    if (!room.IsWaitingToBeRenovated) continue;

                    room.IsWaitingToBeRenovated = false;
                    room.IsBeingRenovated = true;
                    _roomRepository.Update(room);
                }
                Room renovatedRoom = _roomRepository.GetBySerialNumber(roomRenovation.RenovatedRoomSerialNumber);
                if (renovatedRoom.IsBeingRenovated) return;
                renovatedRoom.IsWaitingToBeRenovated = false;
                renovatedRoom.IsBeingRenovated = true;
                _roomRepository.Update(roomRenovation.RenovatedRoom);
            }   
        }

        private void EndRenovating(RoomRenovation roomRenovation)
        {
            if (!roomRenovation.Description.Contains("Split"))
            {
                foreach (Room room in _roomRepository.GetByRoomRenovationSerialNumber(roomRenovation.SerialNumber))
                {
                    if (room.SerialNumber.Equals(roomRenovation.RenovatedRoomSerialNumber)) continue;
                    if (room.IsBeingRenovated) _roomRepository.Delete(room.SerialNumber);
                }

                Room newRoom = _roomRepository.GetBySerialNumber(roomRenovation.RenovatedRoomSerialNumber);
                newRoom.IsBeingRenovated = false;
                newRoom.RoomRenovationSerialNumber = null;
                _roomRepository.Update(newRoom);
                _roomRenovationRepository.Delete(roomRenovation.SerialNumber);
            }
            else
            {
                foreach (Room room in _roomRepository.GetAll())
                {
                    if (!room.IsBeingRenovated) continue;
                    room.IsBeingRenovated = false;
                    room.RoomRenovationSerialNumber = null;
                    _roomRepository.Update(room);

                }

                _roomRepository.Delete(roomRenovation.RenovatedRoomSerialNumber);
                _roomRenovationRepository.Delete(roomRenovation.SerialNumber);
            }
                
        }

        private void AddMissingProperties(RoomRenovation roomRenovation)
        {
            roomRenovation.RenovatingRooms = _roomRepository.GetByRoomRenovationSerialNumber(roomRenovation.SerialNumber);
            roomRenovation.RenovatedRoom = _roomRepository.GetBySerialNumber(roomRenovation.RenovatedRoomSerialNumber);
        }
    }
}
