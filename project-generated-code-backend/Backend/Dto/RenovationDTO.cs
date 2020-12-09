// File:    RenovationDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RenovationDTO

using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Dto
{
    public class RenovationDto
    {
        public Room Room { get; set; }
        public TimeInterval TimeInterval { get; set; }

        public RenovationDto(Room room, TimeInterval timeInterval)
        {
            Room = room;
            TimeInterval = timeInterval;
        }
    }
}