using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using System;

namespace HealthClinicBackend.Backend.Model.Schedule
{
    public class EquipmentRelocation : Entity
    {
        public virtual Equipment equipment { get; set; }

        public TimeInterval TimeInterval { get; set; }
        public string roomToRelocateToSerialNumber { get; set; }
        public string equipmentSerialNumber { get; set; }
        public uint quantity { get; set; }
        public EquipmentRelocation() : base() { }

        public EquipmentRelocation(DateTime startTime, DateTime endTime, Equipment equipment, string roomSerialNumToRelocateTo, uint quantity) : base()
        {
            this.quantity = quantity;
            this.TimeInterval = new TimeInterval(startTime, endTime);
            this.roomToRelocateToSerialNumber = roomSerialNumToRelocateTo;
            this.equipment = equipment;
            this.equipmentSerialNumber = equipment.SerialNumber;
        }

    }
}
