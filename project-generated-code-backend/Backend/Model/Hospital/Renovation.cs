using System;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Renovation : Entity
    {
        public TimeInterval TimeInterval { get; set; }
        public Room Room { get; set; }

        public Renovation(Room room, TimeInterval timeInteval) : base()
        {
            TimeInterval = timeInteval;
            Room = room;
        }

        public Renovation(String serialNumber, Room room, TimeInterval timeInteval) : base(serialNumber)
        {
            Room = room;
            TimeInterval = timeInteval;
        }

        public Renovation()
        {
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Renovation other))
            {
                return false;
            }

            return Room.Equals(other.Room) && TimeInterval.Equals(other.TimeInterval);
        }
    }
}