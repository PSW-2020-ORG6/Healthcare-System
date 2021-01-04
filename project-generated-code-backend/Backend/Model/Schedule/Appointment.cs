// File:    Appointment.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Appointment

using System;
using System.ComponentModel.DataAnnotations.Schema;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

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
        public string DateOfCanceling { get; set; }

        public bool IsSurveyDone { get; set; }
        
        public Appointment(Room room, Physician physician, Patient patient, TimeInterval timeInterval,
            ProcedureType procedureType, Boolean active, DateTime date) : base()
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
            Active = active;
            Date = date;
        }
        public Appointment(Room room, Physician physician, Patient patient, TimeInterval timeInterval,
            ProcedureType procedureType, Boolean active, DateTime date,Boolean isSurveyDone) : base()
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
            Active = active;
            Date = date;
            IsSurveyDone = isSurveyDone;
        }

        public Appointment(Room room, Physician physician, Patient patient, TimeInterval timeInterval,
            ProcedureType procedureType, DateTime date) : base()
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
            Date = date;
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
            Date = appointmentDTO.Date;
        }

        public Appointment(string physicianId, string date, DateTime timeIntervalStart)
        {
            this.Physician = new Physician { SerialNumber = physicianId };
            string[] parts = date.Split("-");
            this.Date = new DateTime(Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2]), 0, 0, 0);
            this.TimeInterval = new TimeInterval { Start = timeIntervalStart };
            this.Active = true;
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
            return "patient: " + Patient.Name + " " + Patient.Surname + "\nphysitian: " + Physician.Name + " " + Physician.Surname + "\ntime interval: " +
                   TimeInterval + "\nroom: " + Room + "\nprocedure type: " + ProcedureType;
        }

        public int CompareTo(Appointment other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}