// File:    Appointment.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Appointment

using Backend.Dto;
using Backend.Model.Util;
using Model.Accounts;
using Model.Hospital;
using Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Schedule
{
    public class Appointment : Entity
    {
        private Room room;
        private Physitian physitian;
        private Patient patient;
        private TimeInterval timeInterval;
        private ProcedureType procedureType;
        private bool urgency;
        private bool active;
        private DateTime date;

        public Room Room { get => room; set => room = value; }
        public Physitian Physitian { get => physitian; set => physitian = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public TimeInterval TimeInterval { get => timeInterval; set => timeInterval = value; }
        public ProcedureType ProcedureType { get => procedureType; set => procedureType = value; }
        public bool Urgency { get => urgency; set => urgency = value; }
        public bool Active { get => active; set => active = value; }
        public DateTime Date { get => date; set => date = value; }

        public Appointment(Room room, Physitian physitian, Patient patient, TimeInterval timeInterval, ProcedureType procedureType, Boolean active,DateTime date) : base(Guid.NewGuid().ToString())
        {
            this.room = room;
            this.physitian = physitian;
            this.patient = patient;
            this.timeInterval = timeInterval;
            this.procedureType = procedureType;
            this.active = active;
            this.date = date;
        }

        [JsonConstructor]
        public Appointment(String serialNumber, Room room, Physitian physitian, Patient patient, TimeInterval timeInterval, ProcedureType procedureType, Boolean active,DateTime date) : base(serialNumber)
        {
            this.room = room;
            this.physitian = physitian;
            this.patient = patient;
            this.timeInterval = timeInterval;
            this.procedureType = procedureType;
            this.active = active;
            this.date = date;
        }

        public Appointment(AppointmentDTO appointmentDTO) : base(Guid.NewGuid().ToString())
        {
            this.room = appointmentDTO.Room;
            this.physitian = appointmentDTO.Physitian;
            this.patient = appointmentDTO.Patient;
            this.timeInterval = appointmentDTO.Time;
            this.procedureType = appointmentDTO.ProcedureType;
            this.urgency = appointmentDTO.Urgency;
            this.active = appointmentDTO.Active;
            this.date = appointmentDTO.Date;
        }

        public Appointment()
        {
        }

        public override bool Equals(object obj)
        {
            Appointment other = obj as Appointment;
            if (other == null)
            {
                return false;
            }
            return this.SerialNumber.Equals(other.SerialNumber);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "patient: " + patient.FullName + "\nphysitian: " + physitian.FullName + "\ntime interval: "
                + timeInterval.ToString() + "\nroom: " + room.ToString() + "\nprocedure type: " + procedureType.ToString();
        }
        /*
        public int CompareTo(Appointment other)
        {
            return Date.CompareTo(other.Date);
        }
        */
    }
}