using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Service.SchedulingService
{
    public class RoomRenovationService
    {
        private RoomRenovationDatabaseSql RoomRenovationRepository;
        private RoomDatabaseSql RoomRepository;
        private MedicineDatabaseSql MedicineRepository;
        private EquipmentDatabaseSql EquipmentRepository;
        private BedDatabaseSql BedRepository;
        public RoomRenovationService()
        {
            RoomRenovationRepository = new RoomRenovationDatabaseSql();
            RoomRepository = new RoomDatabaseSql();
            MedicineRepository = new MedicineDatabaseSql();
            EquipmentRepository = new EquipmentDatabaseSql();
            BedRepository = new BedDatabaseSql();
        }

        public void AddRoomRenovation(RoomRenovation roomRenovation)
        {
            RoomRenovationRepository.Save(roomRenovation);
        }

        public void DeleteRoomRenovation(RoomRenovation roomRenovation)
        {
            RoomRenovationRepository.Delete(roomRenovation.SerialNumber);
        }

        public List<RoomRenovation> GetAll()
        {
            List<RoomRenovation> roomRenovations = RoomRenovationRepository.GetAll();
            foreach (RoomRenovation roomRenovation in roomRenovations)
            {
                AddMissingProperties(roomRenovation);
            }
            return roomRenovations;
        }

        public RoomRenovation GetBySerialNumber(string serialNumber)
        {
            RoomRenovation roomRenovation = RoomRenovationRepository.GetBySerialNumber(serialNumber);
            AddMissingProperties(roomRenovation);
            return roomRenovation;
        }

        public List<Room> GetRoomsByOverlappingTimeInterval()
        {
            List<RoomRenovation> roomRenovations = RoomRenovationRepository.GetAll();
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
            foreach (Room room in RoomRepository.GetByRoomRenovationSerialNumber(roomRenovation.SerialNumber))
            {
                foreach (Equipment equipment in EquipmentRepository.GetByRoomSerialNumber(room.SerialNumber))
                {
                    equipment.RoomSerialNumber = roomRenovation.RenovatedRoomSerialNumber;
                    EquipmentRepository.Update(equipment);
                }
                foreach (Medicine medicine in MedicineRepository.GetByRoomSerialNumber(room.SerialNumber))
                {
                    medicine.RoomSerialNumber = roomRenovation.RenovatedRoomSerialNumber;
                    MedicineRepository.Update(medicine);
                }
                foreach (Bed bed in BedRepository.GetByRoomSerialNumber(room.SerialNumber))
                {
                    bed.RoomSerialNumber = roomRenovation.RenovatedRoomSerialNumber;
                    BedRepository.Update(bed);
                }
                room.IsWaitingToBeRenovated = false;
                room.IsBeingRenovated = true;
                RoomRepository.Update(room);
            }
            Room renovatedRoom = RoomRepository.GetBySerialNumber(roomRenovation.RenovatedRoomSerialNumber);
            renovatedRoom.IsWaitingToBeRenovated = false;
            renovatedRoom.IsBeingRenovated = true;
            RoomRepository.Update(roomRenovation.RenovatedRoom);
        }

        private void EndRenovating(RoomRenovation roomRenovation)
        {
            foreach (Room room in RoomRepository.GetByRoomRenovationSerialNumber(roomRenovation.SerialNumber))
            {
                if (room.SerialNumber.Equals(roomRenovation.RenovatedRoomSerialNumber)) continue;
                RoomRepository.Delete(room.SerialNumber);
            }

            Room newRoom = RoomRepository.GetBySerialNumber(roomRenovation.RenovatedRoomSerialNumber);
            newRoom.IsBeingRenovated = false;
            RoomRepository.Update(newRoom);
            RoomRenovationRepository.Delete(roomRenovation.SerialNumber);
        }

        private void AddMissingProperties(RoomRenovation roomRenovation)
        {
            roomRenovation.RenovatingRooms = RoomRepository.GetByRoomRenovationSerialNumber(roomRenovation.SerialNumber);
            roomRenovation.RenovatedRoom = RoomRepository.GetBySerialNumber(roomRenovation.RenovatedRoomSerialNumber);
        }
    }
}
