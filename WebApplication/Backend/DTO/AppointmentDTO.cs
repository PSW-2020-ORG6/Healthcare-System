using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.DTO
{
    public class AppointmentDTO
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

        public AppointmentDTO() { }

        public AppointmentDTO(Appointment appointment)
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

        public List<AppointmentDTO> ConvertListToAppointmentDTO(List<Appointment> appointments)
        {
            List<AppointmentDTO> appointmentsDTO = new List<AppointmentDTO>();
            if(appointments == null)
                return appointmentsDTO;
            foreach (Appointment appointment in appointments)
                appointmentsDTO.Add(new AppointmentDTO(appointment));
            return appointmentsDTO;
        }
    }
}
