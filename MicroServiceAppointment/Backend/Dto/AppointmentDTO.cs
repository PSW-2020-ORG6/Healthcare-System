using MicroServiceAccount.Backend.Dto;
using MicroServiceAppointment.Backend.Model;
using System;
using System.Collections.Generic;

namespace MicroServiceAppointment.Backend.Dto
{
    public class AppointmentDto
    {
        public RoomDTO RoomDTO {get;set;}
        public TimeIntervalsDTO TimeIntervalDTO { get; set; }
        public PhysiciansDTO PhysicianDTO { get; set; }
        public ProcedureTypeDTO ProcedureTypeDTO { get; set; }
        public bool Urgency { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public bool IsSurveyDone { get; set; }
        public string SerialNumber { get; set; }
        public PatientsDTO PatientsDTO { get; set; }

        public AppointmentDto() 
        {
        }

        public AppointmentDto(Appointment appointment)
        {
            RoomDTO = new RoomDTO(appointment.Room);
            TimeIntervalDTO = new TimeIntervalsDTO(appointment.TimeInterval);
            PhysicianDTO = new PhysiciansDTO(appointment.Physician);
            ProcedureTypeDTO = new ProcedureTypeDTO(appointment.ProcedureType);
            Urgency = appointment.Urgency;
            Active = appointment.Active;
            IsSurveyDone = appointment.IsSurveyDone;
            Date = appointment.Date;
            SerialNumber = appointment.SerialNumber;
            PatientsDTO = new PatientsDTO(appointment.Patient);
        }

        public List<AppointmentDto> ConvertListToAppointmentDTO(List<Appointment> appointments)
        {
            List<AppointmentDto> appointmentsDTO = new List<AppointmentDto>();
            if(appointments == null)
                return appointmentsDTO;
            foreach (Appointment appointment in appointments)
                appointmentsDTO.Add(new AppointmentDto(appointment));
            return appointmentsDTO;
        }

        public bool IsPreferedPhysicianSelected()
        {
            return (PhysicianDTO != null);
        }

        public bool IsPreferredTimeSelected()
        {
            return (TimeIntervalDTO != null);
        }

        public bool IsPreferredDateSelected()
        {
            DateTime defaultDate = DateTime.MinValue;
            return !Date.Equals(defaultDate);
        }

        public bool IsPreferedRoomSelected()
        {
            return (RoomDTO != null);
        }

        public bool IsDataValid(string date)
        {
            string[] parts = date.Split("-");
            DateTime dateTime = new DateTime(Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2]), 0, 0, 0);
            return date != null && dateTime > DateTime.Today.AddDays(2);
        }

       /* public AppointmentDTO(string physicianId, string date, DateTime timeIntervalStart)
        {
            this.PhysicianDTO = new Physician { SerialNumber = physicianId };
            string[] parts = date.Split("-");
            this.Date = new DateTime(Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2]), 0, 0, 0);
            this.Time = new TimeInterval { Start = timeIntervalStart };
            this.Active = true;
        }*/
    }
}
