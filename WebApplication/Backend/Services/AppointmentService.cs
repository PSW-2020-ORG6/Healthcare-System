using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using Model.Accounts;
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

        public List<TimeIntervalDTO> GetAllAvailableAppointments(string physicianId, string specializationName, string date)
        {
            Physician physician = physicianRepository.GetPhysicianBySerialNumber(physicianId);
            List<Appointment> appointments = appointmentRepository.GetAppointmentsByDate(date);
            return GetAvailableAppointments(appointments, physician, specializationName);
        }

        private List<TimeIntervalDTO> GetAvailableAppointments(List<Appointment> appointments, Physician physician, string specializationName)
        {
            List<TimeIntervalDTO> result = new List<TimeIntervalDTO>();
            DateTime time = physician.WorkSchedule.Start;
            while (time <= physician.WorkSchedule.End)
            {
                bool existance = false;
                if (appointments.Any())
                {
                    foreach (Appointment appointment in appointments)
                    {
                        if (timeIntervalDTO.CompareTimeIntervals(time, appointment.TimeInterval.Start) && appointment.Physician.SerialNumber == physician.SerialNumber && appointment.ProcedureType.Specialization.Name == specializationName && appointment.Active)
                        {
                            existance = true;
                            break;
                        }
                    }
                }
                if (!existance)
                    result.Add(new TimeIntervalDTO(time));
                time = time.Add(new TimeSpan(0, 20, 0));
            }
            return result;
        }
        public bool AddAppointment(Appointment appointment)
        {
            return appointmentRepository.AddAppointment(appointment);
        }
    }
}
