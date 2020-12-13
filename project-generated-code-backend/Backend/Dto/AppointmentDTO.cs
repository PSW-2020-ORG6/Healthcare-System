// File:    AppointmentDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class AppointmentDTO

using System;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Dto
{
    public class AppointmentDto
    {
        public ProcedureType ProcedureType { get; set; }
        public TimeInterval Time { get; set; }
        public Physician Physician { get; set; }
        public Patient Patient { get; set; }
        public Room Room { get; set; }
        public bool Urgency { get; set; }
        public bool Active { get; set; }
        public DateTime Date { get; set; }
        public int RestrictedHours { get; set; }
        public string SerialNumber { get; set; }

        public bool IsPreferedPhysicianSelected()
        {
            return (Physician != null);
        }

        public bool IsPreferredTimeSelected()
        {
            return (Time != null);
        }

        public bool IsPreferredDateSelected()
        {
            DateTime defaultDate = DateTime.MinValue;
            return !Date.Equals(defaultDate);
        }

        public bool IsPreferedRoomSelected()
        {
            return (Room != null);
        }
    }
}