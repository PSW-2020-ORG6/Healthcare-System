//using MicroServiceAccount.Backend.Dto;
using MicroServiceAccount.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Schedule;

namespace HealthClinicBackend.Backend.Dto
{
    public class AppointmentDto
    {
        public RoomDTO RoomDTO {get;set;}
        public TimeIntervalDTO TimeIntervalDTO { get; set; }
        public PhysicianDTO PhysicianDTO { get; set; }
        public ProcedureTypeDTO ProcedureTypeDTO { get; set; }
        public bool Urgency { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public bool IsSurveyDone { get; set; }
        public string SerialNumber { get; set; }
        public PatientDto PatientDTO { get; set; }

        public AppointmentDto() 
        {
        }

        public AppointmentDto(Appointment appointment)
        {
            RoomDTO = new RoomDTO(appointment.Room);
            TimeIntervalDTO = new TimeIntervalDTO(appointment.TimeInterval);
            PhysicianDTO = new PhysicianDTO(appointment.Physician);
            ProcedureTypeDTO = new ProcedureTypeDTO(appointment.ProcedureType);
            Urgency = appointment.Urgency;
            Active = appointment.Active;
            IsSurveyDone = appointment.IsSurveyDone;
            Date = appointment.Date;
            SerialNumber = appointment.SerialNumber;
            PatientDTO = new PatientDto(appointment.Patient);
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

    }
}
