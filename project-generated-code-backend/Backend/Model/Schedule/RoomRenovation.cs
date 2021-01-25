using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinicBackend.Backend.Model.Schedule
{
    public class RoomRenovation : Entity
    {
        public List<Room> RenovatingRooms { get; set; }

        public Room RenovatedRoom { get; set; }

        [ForeignKey("RenovatedRoomSerialNumber")]
        public string RenovatedRoomSerialNumber { get; set; }

        public TimeInterval TimeInterval { get; set; }

        public string Description { get; set; }

        public RoomRenovation() : base()
        {
            RenovatingRooms = new List<Room>();
        }
    }
}
