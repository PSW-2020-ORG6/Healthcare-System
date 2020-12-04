// File:    AppointmentGeneralitiesDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class AppointmentGeneralitiesDTO

using Model.Accounts;
using Model.Hospital;
using Model.Util;
using System.Collections.Generic;

namespace Backend.Dto
{
    public class AppointmentGeneralitiesDTO
    {
        private List<Physician> availablePhysitians;
        private List<Room> availableRooms;
        private List<TimeInterval> availableTimeIntervals;

        public List<Physician> AvailablePhysitians { get => availablePhysitians; set => availablePhysitians = value; }
        public List<Room> AvailableRooms { get => availableRooms; set => availableRooms = value; }
        public List<TimeInterval> AvailableTimeIntervals { get => availableTimeIntervals; set => availableTimeIntervals = value; }
    }
}