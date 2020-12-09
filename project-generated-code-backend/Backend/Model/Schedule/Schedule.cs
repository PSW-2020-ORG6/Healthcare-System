// File:    Schedule.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Schedule

using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Model.Schedule
{
    public class Schedule
    {
        public List<Appointment> Appointment { get; set; }
    }
}