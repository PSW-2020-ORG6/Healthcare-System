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
    public class AppointmentService : IAppointmentService
    {
        private ISpecializationRepository specializationRepository;
        private ITimeIntervalRepository timeIntervalRepository = new TimeIntervalRepository();
        private IAppointmentRepository appointmentRepository = new AppointmentRepository();
        private IPhysicianRepository physicianRepository = new PhysicianRepository();
        private PhysicianDTO physitianDTO = new PhysicianDTO();
        private TimeIntervalDTO timeIntervalDTO = new TimeIntervalDTO();
        private SpecializationDTO specializationDTO = new SpecializationDTO();
        private AppointmentWithRecommendationDTO appointmentWithRecommendationDTO = new AppointmentWithRecommendationDTO();
        private DateTimeDTO dateTimeDTO = new DateTimeDTO();

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
            while (time < physician.WorkSchedule.End) 
            {
                bool existance = false;
                if (appointments.Any())
                {
                    foreach (Appointment appointment in appointments)
                    {
                        if (CompareTimeIntervals(time, appointment.TimeInterval.Start) && appointment.Physician.SerialNumber == physician.SerialNumber && appointment.ProcedureType.Specialization.Name == specializationName && appointment.Active)
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

        private bool CompareTimeIntervals(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1.Hour == dateTime2.Hour && dateTime1.Minute == dateTime2.Minute;
        }

        public List<AppointmentWithRecommendationDTO> AppointmentRecomendationWithPhysicianPriority(string physicianId, string specializationName, string[] dates)
        {
            List<AppointmentWithRecommendationDTO> availableAppointments = new List<AppointmentWithRecommendationDTO>();
            foreach (string date in dates)
            {
                availableAppointments.Add(new AppointmentWithRecommendationDTO(date, physicianId, GetAllAvailableAppointments(physicianId, specializationName, date), ""));
            }
            if (!availableAppointments.Any())
            {
                foreach (string date in AdditionalDates(dates))
                {
                    availableAppointments.Add(new AppointmentWithRecommendationDTO(date, physicianId, GetAllAvailableAppointments(physicianId, specializationName, date), ""));
                }
            }
            return availableAppointments;
        }

        private List<String> AdditionalDates(string[] dates)
        {
           List<string> newDates = new List<string>();
            DateTime dateTimeFrom = dateTimeDTO.CreateDateTime(dates[0]);
            DateTime dateTimeTo = dateTimeDTO.CreateDateTime(dates[dates.Length - 1]);
            while (newDates.Count < 3)
            {
                dateTimeTo = dateTimeTo.AddDays(1);
                newDates.Add(DateConversion(dateTimeTo));
            }
            while (newDates.Count < 6 && dateTimeDTO.IsPreferredTimeValid(DateConversion(dateTimeFrom)))
            {
                dateTimeFrom = dateTimeFrom.AddDays(-1);
                newDates.Add(DateConversion(dateTimeFrom));
            }
            return newDates;
        }

        private string DateConversion(DateTime date)
        {
            string[] dateString = date.ToString().Split(" ");
            string[] partsOfDate = dateString[0].Split("/");
            return partsOfDate[2] + "-" + partsOfDate[0] + "-" + partsOfDate[1];
        }

        public bool AddAppointment(Appointment appointment)
        {
            return appointmentRepository.AddAppointment(appointment);
        }

        public List<AppointmentWithRecommendationDTO> AppointmentRecomendation(string physicianId, string specializationName, string[] dates)
        {
           List<AppointmentWithRecommendationDTO> availableAppointments = new List<AppointmentWithRecommendationDTO>();
            foreach (string date in dates)
            {
                availableAppointments.Add(new AppointmentWithRecommendationDTO(date, physicianId, GetAllAvailableAppointments(physicianId, specializationName, date), ""));
            }
            if (!availableAppointments.Any())
            {
                List<Physician> physicians = physicianRepository.GetPhysicianBySpecialization(specializationName, physicianId);
                foreach(Physician physician in physicians)
                {
                    foreach (string date in dates)
                    {
                        availableAppointments.Add(new AppointmentWithRecommendationDTO(date, physician.Id, GetAllAvailableAppointments(physician.Id, specializationName, date), physician.FullName));
                    }
                }
            }
            return availableAppointments;
        }
    }
}
