// File:    Appointment.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Appointment

using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using Model.Accounts;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinicBackend.Backend.Model.Schedule
{
    public class Appointment : Entity
    {
        [ForeignKey("Room")] public string RoomSerialNumber { get; set; }
        public Room Room { get; set; }
        [ForeignKey("Physician")] public string PhysicianSerialNumber { get; set; }
        public Physician Physician { get; set; }
        [ForeignKey("Patient")] public string PatientSerialNumber { get; set; }
        public Patient Patient { get; set; }
        public TimeInterval TimeInterval { get; set; }
        [ForeignKey("ProcedureType")] public string ProcedureTypeSerialnumber { get; set; }
        public ProcedureType ProcedureType { get; set; }
        public bool Urgency { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }

        public Appointment(Room room, Physician physician, Patient patient, TimeInterval timeInterval,
            ProcedureType procedureType) : base()
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
        }

        public Appointment() : base()
        {
        }

        [JsonConstructor]
        public Appointment(String serialNumber, Room room, Physician physician, Patient patient,
            TimeInterval timeInterval, ProcedureType procedureType) : base(serialNumber)
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
        }
        
        public Appointment(string serialNumber, string physicianSerialNumber,
            string patientSerialNumber, TimeInterval timeInterval) : base(serialNumber)
        {
            PhysicianSerialNumber = physicianSerialNumber;
            PatientSerialNumber = patientSerialNumber;
            TimeInterval = timeInterval;
        }

        public Appointment(String serialNumber, Room room, Physician physician, Patient patient,
            TimeInterval timeInterval, bool active, ProcedureType procedureType) : base(serialNumber)
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
            Active = active;
        }

        public Appointment(Room room, Physician physician, Patient patient,
            TimeInterval timeInterval, bool active, ProcedureType procedureType) : base()
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
            Active = active;
        }

        public Appointment(AppointmentDto appointmentDTO) : base()
        {
            Room = appointmentDTO.Room;
            Physician = appointmentDTO.Physician;
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
            return "patient: " + Patient.FullName + "\nphysitian: " + Physician.FullName + "\ntime interval: " +
                   TimeInterval + "\nroom: " + Room + "\nprocedure type: " + ProcedureType;
        }

        public int CompareTo(Appointment other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}