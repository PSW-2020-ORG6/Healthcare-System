﻿using HealthClinicBackend.Backend.Events.EventLogging;

namespace HealthClinicBackend.Backend.Events.EventFloorChange
{
    public class FloorChangeEvent : Event
    {
        public string UsernameSerialNbr { get; set; }
        public string BuildingSerialNbr { get; set; }
        public string FloorSerialNbr { get; set; }
    }
}