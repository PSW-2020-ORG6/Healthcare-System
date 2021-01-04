using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
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
                List<TimeIntervalDTO> appointments = GetAllAvailableAppointments(physicianId, specializationName, date);
                if(appointments.Count > 0)
                    availableAppointments.Add(new AppointmentWithRecommendationDTO(date, physicianId, appointments, ""));
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

        /// <summary>
        ///method for getting patient's appointments 
        ///</summary>
        ///<param name="patientId"> String type object
        ///<returns>
        ///list of appointments
        ///</returns>
        public List<AppointmentDTO> GetAllAppointmentsByPatientId(string patientId)
        {
            return appointmentDTO.ConvertListToAppointmentDTO(appointmentRepository.GetAllAppointmentByPatientId(patientId));
        }

        /// <summary>
        ///method for getting all appointments 
        ///</summary>
        ///<returns>
        ///list of appointments
        ///</returns>
        public List<AppointmentDTO> GetAllAppointments()
        {
            return appointmentDTO.ConvertListToAppointmentDTO(appointmentRepository.GetAllAppointments());
        }

        /// <summary>
        ///method for getting patient's scheduled appointments 
        ///</summary>
        ///<param name="patientId"> String type object
        ///<returns>
        ///list of appointments
        ///</returns>
        internal List<AppointmentDTO> GetAllAppointmentsByPatientIdActive(string patientId)
        {
            List<Appointment> allAppointments = appointmentRepository.GetAllAppointmentsByPatientIdActive(patientId);
            DateTime dateNow = DateTime.Now;
            List<Appointment> appotintmentsInFuture = new List<Appointment>();
            foreach (Appointment appointment in allAppointments)
            {
                if (appointment.Date > dateNow)
                {
                    appotintmentsInFuture.Add(appointment);
                }
            }
            return appointmentDTO.ConvertListToAppointmentDTO(appotintmentsInFuture);
        }

        /// <summary>
        ///method for getting patient's canceled appointments
        ///</summary>
        ///<param name="patientId"> String type object
        ///<returns>
        ///list of appointments
        ///</returns>
        internal List<AppointmentDTO> GetAllAppointmentsByPatientIdCanceled(string patientId)
        {
            return appointmentDTO.ConvertListToAppointmentDTO(appointmentRepository.GetAllAppointmentsByPatientIdCanceled(patientId));
        }

        /// <summary>
        ///method for getting patient's all past appointments 
        ///</summary>
        ///<param name="patientId"> String type object
        ///<returns>
        ///list of appoitnemtns
        ///</returns>
        public List<AppointmentDTO> GetAllAppointmentsByPatientIdPast(string patientId)
        {
            List<Appointment> allAppointments =appointmentRepository.GetAllAppointmentsByPatientIdPast(patientId);
            DateTime dateNow = DateTime.Now;
            List<Appointment> appotintmentsInPast = new List<Appointment>();
            foreach (Appointment appointment in allAppointments)
            {
                if (appointment.Date < dateNow)
                {
                    appotintmentsInPast.Add(appointment);
                }
            }
            return appointmentDTO.ConvertListToAppointmentDTO(appotintmentsInPast);
        }

        /// <summary>
        ///method for checking if survey is done on specific appointment
        ///</summary>
        ///<param name="patientId"> String type object
        ///<param name="appointmentDate"> String type object
        ///<param name="physicianName"> String array type object
        ///<returns>
        ///bool value
        ///</returns>
        internal bool isSurveyDoneByPatientIdAppointmentDatePhysicianName(string patientId, string appointmentDate, string physicianName)
        {
            List<Physician> physitianResult = physicianRepository.GetPhysiciansByFullName(physicianName);
            List<String> physicianId = new List<string>();
            foreach (Physician physician in physitianResult)
            {
                physicianId.Add(physician.Id);
            }
            return appointmentRepository.IsSurveyDoneByPatientIdAppointmentDatePhysicianName(patientId, appointmentDate, physitianResult[0].Id);
        }

        /// <summary>
        ///method for setting value of isSurveyDone on true in database
        ///</summary>
        internal void setSurveyDoneOnAppointment(AppointmentDTO appointmentDto)
        {
            String dateD;

            String[] dateVar = appointmentDto.Date.ToString().Split(" ")[0].Split(".");
            if (dateVar[1].Length == 1)
                dateD = dateVar[2] + "-" + "0" + dateVar[1] + "-" + dateVar[0];
            else
                dateD = dateVar[2] + "-" + dateVar[1] + "-" + dateVar[0];

            List<Physician> physitianResult = physicianRepository.GetPhysiciansByFullName(appointmentDto.PhysicianDTO.FullName);
            List<String> physicianId = new List<string>();
            foreach (Physician physician in physitianResult)
            {
                physicianId.Add(physician.Id);
            }
            appointmentRepository.SetSurveyDoneOnAppointment(appointmentDto.PatientDTO.Id,dateD, physicianId[0]);
        }

        /// <summary>
        ///method for getting all appointments without survey done
        ///</summary>
        ///<returns>
        ///list of appointments
        ///</returns>
        internal List<AppointmentDTO> GetAllAppointmentsWithoutDoneSurvey()
        {
            List<Appointment> allAppointments = appointmentRepository.GetAllAppointmentsWithoutSurvey();
            DateTime dateNow = DateTime.Now;
            List<Appointment> appotintmentsInPastWitohutSurvey = new List<Appointment>();
            foreach (Appointment appointment in allAppointments)
            {
                if (appointment.Date < dateNow)
                {
                    appotintmentsInPastWitohutSurvey.Add(appointment);
                }
            }
            return appointmentDTO.ConvertListToAppointmentDTO(appotintmentsInPastWitohutSurvey);
        }

        /// <summary>
        ///method for getting all appointments with survey done
        ///</summary>
        ///<returns>
        ///list of appointments
        ///</returns>
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
                List<TimeIntervalDTO> appointments = GetAllAvailableAppointments(physicianId, specializationName, date);
                if (appointments.Count > 0)
                    availableAppointments.Add(new AppointmentWithRecommendationDTO(date, physicianId, appointments, ""));
            }
            if (!availableAppointments.Any())
            {
                List<Physician> physicians = physicianRepository.GetPhysicianBySpecialization(specializationName, physicianId);
                foreach(Physician physician in physicians)
                {
                    foreach (string date in dates)
                    {
                        availableAppointments.Add(new AppointmentWithRecommendationDTO(date, physician.Id, GetAllAvailableAppointments(physician.Id, specializationName, date), physician.Name + " " + physician.Surname));
                    }
                }
            }
            return availableAppointments;
        }
    }
}
