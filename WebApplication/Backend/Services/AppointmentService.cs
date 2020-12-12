using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using WebApplication.Backend.DTO;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Services
{
    public class AppointmentService
    {
        private ISpecializationRepository specializationRepository;
        private ITimeIntervalRepository timeIntervalRepository = new TimeIntervalRepository();
        private IAppointmentRepository appointmentRepository = new AppointmentRepository();
        private IPhysicianRepository physicianRepository = new PhysicianRepository();
        private PhysicianDTO physitianDTO = new PhysicianDTO();
        private TimeIntervalDTO timeIntervalDTO = new TimeIntervalDTO();
        private SpecializationDTO specializationDTO = new SpecializationDTO();

        public AppointmentService()
        {
            this.specializationRepository = new SpecializationRepository();
        }
        public AppointmentService(ISpecializationRepository specializationRepository)
        {
            this.specializationRepository = specializationRepository;
        }
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
        public AppointmentService(IAppointmentRepository appointmentRepository, ITimeIntervalRepository timeIntervalRepository)
        {
            this.appointmentRepository = appointmentRepository;
            this.timeIntervalRepository = timeIntervalRepository;
        }

        public List<Appointment> GetAllAppointmentsByPatientId(string patientId)
        {
            return appointmentRepository.GetAllAppointmentByPatientId(patientId);
        }

        public List<Appointment> GetAllAppointments()
        {
            return appointmentRepository.GetAllAppointments();
        }

        internal List<Appointment> GetAllAppointmentsByPatientIdActive(string patientId)
        {
            return appointmentRepository.GetAllAppointmentsByPatientIdActive(patientId);
        }

        internal List<Appointment> GetAllAppointmentsByPatientIdCanceled(string patientId)
        {
            return appointmentRepository.GetAllAppointmentsByPatientIdCanceled(patientId);
        }
        public List<PhysicianDTO> GetAllPhysicians()
        {
            return physitianDTO.ConvertListToPhysicianDTO(physicianRepository.GetAllPhysicians());
        }

        public List<SpecializationDTO> GetAllSpecializations()
        {
            return specializationDTO.ConvertListToSpecializationDTO(specializationRepository.GetAllSpecializations());
        }

        public List<TimeIntervalDTO> GetAllAvailableAppointments(string physitianId, string specializationName, string date)
        {
            List<TimeIntervalDTO> timeIntervals = timeIntervalDTO.ConvertListToTimeIntervalDTO(timeIntervalRepository.GetAllTimeIntervals());
            List<Appointment> appointments = appointmentRepository.GetAppointmentsByDate(date);
            if (!appointments.Any())
                return timeIntervals;
            else
                return GetAvailableAppointments(timeIntervals, appointments, physitianId, specializationName, date);
        }

        private List<TimeIntervalDTO> GetAvailableAppointments(List<TimeIntervalDTO> timeIntervals, List<Appointment> appointments, string physitianId, string specializationName, string date)
        {
            List<TimeIntervalDTO> result = new List<TimeIntervalDTO>();
            foreach (TimeIntervalDTO timeInterval in timeIntervals)
            {
                bool existance = false;
                foreach (Appointment appointment in appointments)
                {
                    if (timeInterval.Start == appointment.TimeInterval.Start && appointment.Physician.SerialNumber == physitianId && appointment.ProcedureType.Specialization.Name == specializationName && appointment.Active)
                    {
                        existance = true;
                        break;
                    }
                }
                if (!existance)
                    result.Add(timeInterval);
            }
            return result;
        }
        public bool AddAppointment(Appointment appointment)
        {
            return appointmentRepository.AddAppointment(appointment);
        }
    }
}
