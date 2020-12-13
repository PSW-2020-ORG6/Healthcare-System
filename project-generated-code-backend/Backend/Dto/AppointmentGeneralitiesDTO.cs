// File:    AppointmentGeneralitiesDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class AppointmentGeneralitiesDTO

using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using Model.Accounts;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Dto
{
    public class AppointmentGeneralitiesDto
    {
        public List<Physician> AvailablePhysitians { get; set; }
        public List<Room> AvailableRooms { get; set; }
        public List<TimeInterval> AvailableTimeIntervals { get; set; }
    }
}