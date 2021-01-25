﻿using HealthClinicBackend.Backend.Events.EventLogging;

namespace HealthClinicBackend.Backend.Events.EventRoomSelection
{
    public class RoomSelectionEvent : Event
    {
        public string UsernameSerialNbr { get; set; }
        public string FloorSerialNbr { get; set; }
        public string RoomSerialNbr { get; set; }
    }
}