// File:    AppointmentDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class AppointmentDTO

using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using Model.Accounts;
using System;
using WebApplication.Backend.DTO;

namespace Backend.Dto
{
    public class AppointmentDT
    {
        public bool IsPreferedPhysitianSelected()
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
            return !date.Equals(defaultDate);
        }

        public bool IsPreferedRoomSelected()
        {
            return (Room != null);
        }

        private string serialNumber;
        private ProcedureType procedureType;
        private TimeInterval time;
        private DateTime date;
        private Physician physician;
        private Patient patient;
        private Room room;
        private bool urgency;
        private int restrictedHours;
        private bool active;

        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public ProcedureType ProcedureType { get => procedureType; set => procedureType = value; }
        public TimeInterval Time { get => time; set => time = value; }
        public Physician Physician { get => physician; set => physician = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public Room Room { get => room; set => room = value; }
        public bool Urgency { get => urgency; set => urgency = value; }
        public int RestrictedHours { get => restrictedHours; set => restrictedHours = value; }
        public DateTime Date { get => date; set => date = value; }
        public bool Active { get => active; set => active = value; }

        public AppointmentDT(Room room, Physician physitian, Patient patient, TimeInterval timeInterval, ProcedureType procedureType, DateTime date)
        {
            this.room = room;
            this.physician = physitian;
            this.patient = patient;
            this.time = timeInterval;
            this.procedureType = procedureType;
            this.date = date;
        }

        public AppointmentDT(string physicianId, string date, string timeIntervalId)
        {
            this.Physician = new Physician { SerialNumber = physicianId};
            this.date = DateTime.Parse(date);
            this.time = new TimeInterval { Id = timeIntervalId};
            this.active = true;
        }

        public AppointmentDT()
        {
        }
    }
}