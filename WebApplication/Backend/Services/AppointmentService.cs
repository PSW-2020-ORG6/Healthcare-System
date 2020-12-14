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
        private AppointmentDTO appointmentDTO = new AppointmentDTO();
        private AppointmentWithRecommendationDTO appointmentWithRecommendationDTO = new AppointmentWithRecommendationDTO();
        private DateFromStringConverter dateTimeDTO = new DateFromStringConverter();
  
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

        /// <summary>
        ///calls method for get all available appointments
        ///</summary>
        ///<returns>
        ///list of appointments
        ///</returns>
        ///<param name="appointments"> Appointment list type object
        ///<param name="physician"> Physician type object
        ///<param name="specializationName"> String type object
        ///</param>>
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

        /// <summary>
        ///method for recommending appointment with physician priority 
        ///</summary>
        ///<returns>
        ///list of appointments
        ///</returns>
        ///<param name="physicianId"> String type object
        ///<param name="specializationName"> String type object
        ///<param name="dates"> String array type object
        ///</param>>
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

        /// <summary>
        ///method for extension date interval when there is not available appointments
        ///</summary>
        ///<returns>
        ///list of appointments
        ///</returns>
        ///<param name="physicianId"> String type object
        ///<param name="specializationName"> String type object
        ///<param name="dates"> String array type object
        ///</param>>
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
             return date.ToString("yyyy-MM-dd");
        }

        public bool AddAppointment(Appointment appointment)
        {
            return appointmentRepository.AddAppointment(appointment);
        }
        public List<AppointmentDTO> GetAllAppointmentsByPatientId(string patientId)
        {
            return appointmentDTO.ConvertListToAppointmentDTO(appointmentRepository.GetAllAppointmentByPatientId(patientId));
        }

        public List<AppointmentDTO> GetAllAppointments()
        {
            return appointmentDTO.ConvertListToAppointmentDTO(appointmentRepository.GetAllAppointments());
        }

        internal List<AppointmentDTO> GetAllAppointmentsByPatientIdActive(string patientId)
        {
            return appointmentDTO.ConvertListToAppointmentDTO(appointmentRepository.GetAllAppointmentsByPatientIdActive(patientId));
        }

        internal List<AppointmentDTO> GetAllAppointmentsByPatientIdCanceled(string patientId)
        {
            return appointmentDTO.ConvertListToAppointmentDTO(appointmentRepository.GetAllAppointmentsByPatientIdCanceled(patientId));
        }

        public List<AppointmentDTO> GetAllAppointmentsByPatientIdPast(string patientId)
        {
            return appointmentDTO.ConvertListToAppointmentDTO(appointmentRepository.GetAllAppointmentsByPatientIdPast(patientId));
        }

        internal bool isSurveyDoneByPatientIdAppointmentDatePhysicianName(string patientId, string appointmentDate, string physicianName)
        {
            return appointmentRepository.IsSurveyDoneByPatientIdAppointmentDatePhysicianName(patientId, appointmentDate, physicianName);
        }

        internal void setSurveyDoneOnAppointment(string patientId, string appointmentDate, string physicianName)
        {
            appointmentRepository.SetSurveyDoneOnAppointment(patientId, appointmentDate, physicianName);
        }

        internal List<AppointmentDTO> GetAllAppointmentsWithoutDoneSurvey()
        {
            return appointmentDTO.ConvertListToAppointmentDTO(appointmentRepository.GetAllAppointmentsWithoutSurvey());

        }

        public List<Appointment> GetAllAppointmentsWithDoneSurvey()
        {
            return appointmentRepository.GetAllAppointmentsWithSurvey();
        }

        public bool IsUserMalicious(string patientId)
        {

            List<DateTime> dates = appointmentRepository.GetCancelingDates(patientId);

            DateTime date = DateTime.Now;

            dates.Sort((date1, date2) => date2.CompareTo(date1));

            if (dates.Count >= 2)
            {
                System.TimeSpan difference = dates[1].Subtract(date);
                if (Math.Abs(difference.Days) <= 30)
                    return true;
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CancelAppointment(string appointmentSerialNumber)
        {
            return appointmentRepository.CancelAppointment(appointmentSerialNumber);

        }

        public bool SetUserToMalicious(string patientId)
        {
            return appointmentRepository.SetUserToMalicious(patientId);
        }

        /// <summary>
        ///method for recommending appointment with date priority 
        ///</summary>
        ///<returns>
        ///list of appointments
        ///</returns>
        ///<param name="physicianId"> String type object
        ///<param name="specializationName"> String type object
        ///<param name="dates"> String array type object
        ///</param>>
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
