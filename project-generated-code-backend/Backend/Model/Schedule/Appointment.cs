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
        public Room Room { get; set; }
        public Physitian Physitian { get; set; }
        public Patient Patient { get; set; }
        public TimeInterval TimeInterval { get; set; }
        public ProcedureType ProcedureType { get; set; }
        public bool Urgency { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }

        public Appointment(Room room, Physitian physitian, Patient patient, TimeInterval timeInterval,
            ProcedureType procedureType) : base()
        {
            Room = room;
            Physitian = physitian;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
        }
        
        public Appointment(): base()
        {
        }

        [JsonConstructor]
        public Appointment(String serialNumber, Room room, Physitian physitian, Patient patient,
            TimeInterval timeInterval, ProcedureType procedureType) : base(serialNumber)
        {
            Room = room;
            Physitian = physitian;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
        }

        public Appointment(AppointmentDTO appointmentDTO) : base()
        {
            Room = appointmentDTO.Room;
            Physitian = appointmentDTO.Physitian;
            Patient = appointmentDTO.Patient;
            TimeInterval = appointmentDTO.Time;
            ProcedureType = appointmentDTO.ProcedureType;
            Urgency = appointmentDTO.Urgency;
        }

        public override bool Equals(object obj)
        {
            return obj is Appointment other && SerialNumber.Equals(other.SerialNumber);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "patient: " + Patient.FullName + "\nphysitian: " + Physitian.FullName + "\ntime interval: " +
                   TimeInterval + "\nroom: " + Room + "\nprocedure type: " + ProcedureType;
        }
        
        public int CompareTo(Appointment other)
        {
            return Date.CompareTo(other.Date);
        }
        
    }
}