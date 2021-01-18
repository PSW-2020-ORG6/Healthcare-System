using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Service.SchedulingService;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Controller
{
    public class RoomRenovationController
    {
        private RoomRenovationService RoomRenovationService;

        public RoomRenovationController()
        {
            RoomRenovationService = new RoomRenovationService();
        }

        public List<RoomRenovation> GetAll()
        {
            return RoomRenovationService.GetAll();
        }

        public RoomRenovation GetBySerialNumber(string serialNumber)
        {
            return RoomRenovationService.GetBySerialNumber(serialNumber);
        }

        public void DeleteRoomRenovation(RoomRenovation roomRenovation)
        {
            RoomRenovationService.DeleteRoomRenovation(roomRenovation);
        }

        public void ExecuteRoomRenovation()
        {
            RoomRenovationService.ExecuteRoomRenovation();
        }

        public void AddRoomRenovation(RoomRenovation roomRenovation)
        {
            RoomRenovationService.AddRoomRenovation(roomRenovation);
        }
    }
}
