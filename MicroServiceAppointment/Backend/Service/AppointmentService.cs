using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MicroServiceAppointment.Backend.Util;
using MicroServiceAccount.Backend.Repository.Generic;
using MicroServiceAppointment.Backend.Repository.Generic;
using MicroServiceAccount.Backend.Model;
using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Dto;

namespace MicroServiceAppointment.Backend.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IProcedureTypeRepository _procedureTypeRepository;
        private readonly ISpecializationRepository _specializationRepository;


        private PhysiciansDTO physitianDTO = new PhysiciansDTO();
        private SpecializationsDTO specializationDTO = new SpecializationsDTO();
        private AppointmentDto appointmentDTO = new AppointmentDto();
        private TimeIntervalsDTO timeIntervalDTO = new TimeIntervalsDTO();

        private DateFromStringConverter dateFromStringConverter = new DateFromStringConverter();

        static readonly HttpClient client = new HttpClient();

        private AppointmentWithRecommendationDTO appointmentWithRecommendationDTO =
            new AppointmentWithRecommendationDTO();

        private DateFromStringConverter dateTimeDTO = new DateFromStringConverter();


        public AppointmentService(IAppointmentRepository appointmentRepository,
            IPhysicianRepository physicianRepository,IProcedureTypeRepository procedureTypeRepository)
        {
            _appointmentRepository = appointmentRepository;
            _physicianRepository = physicianRepository;
            _procedureTypeRepository = procedureTypeRepository;
        }

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public AppointmentService(IAppointmentRepository appointmentRepository,
            IPhysicianRepository physicianRepository, IProcedureTypeRepository procedureTypeRepository,ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
            _appointmentRepository = appointmentRepository;
            _physicianRepository = physicianRepository;
            _procedureTypeRepository = procedureTypeRepository;
        }


        public List<TimeIntervalsDTO> GetAllAvailableAppointments(string physicianId, string specializationName,
            string date)
        {
            Physician physician = _physicianRepository.GetById(physicianId);
            DateTime dateParsed = dateFromStringConverter.CreateDateTime(date);
            List<Appointment> appointments = _appointmentRepository.GetAppointmentsByDate(dateParsed);
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
        private List<TimeIntervalsDTO> GetAvailableAppointments(List<Appointment> appointments, Physician physician,
            string specializationName)
        {
            List<TimeIntervalsDTO> result = new List<TimeIntervalsDTO>();
            DateTime time = physician.WorkSchedule.Start;
            while (time < physician.WorkSchedule.End)
            {
                bool existance = false;
                if (appointments.Any())
                {
                    foreach (Appointment appointment in appointments)
                    {
                        if (CompareTimeIntervals(time, appointment.TimeInterval.Start) &&
                            appointment.Physician.SerialNumber == physician.SerialNumber &&
                            appointment.ProcedureType.Specialization.Name == specializationName && appointment.Active)
                        {
                            existance = true;
                            break;
                        }
                    }
                }

                if (!existance)
                    result.Add(new TimeIntervalsDTO(time));
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
        public List<AppointmentWithRecommendationDTO> AppointmentRecomendationWithPhysicianPriority(string physicianId,
            string specializationName, string[] dates)
        {
            List<AppointmentWithRecommendationDTO> availableAppointments = new List<AppointmentWithRecommendationDTO>();
            foreach (string date in dates)
            {
                List<TimeIntervalsDTO> appointments = GetAllAvailableAppointments(physicianId, specializationName, date);
                if (appointments.Count > 0)
                    availableAppointments.Add(
                        new AppointmentWithRecommendationDTO(date, physicianId, appointments, ""));
            }

            if (!availableAppointments.Any())
            {
                foreach (string date in AdditionalDates(dates))
                {
                    availableAppointments.Add(new AppointmentWithRecommendationDTO(date, physicianId,
                        GetAllAvailableAppointments(physicianId, specializationName, date), ""));
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
            //_appointmentRepository.Save(appointment);
            //return true;
            throw new NotImplementedException();
        }

        /// <summary>
        ///method for getting patient's appointments 
        ///</summary>
        ///<param name="patientId"> String type object
        ///<returns>
        ///list of appointments
        ///</returns>
        public List<AppointmentDto> GetAllAppointmentsByPatientId(string patientId)
        {
            return GetAppointmentDtos(_appointmentRepository.GetByPatientId(patientId));
        }

        /// <summary>
        ///method for getting all appointments 
        ///</summary>
        ///<returns>
        ///list of appointments
        ///</returns>
        public List<AppointmentDto> GetAllAppointments()
        {
            return GetAppointmentDtos(_appointmentRepository.GetAll());
        }

        private List<AppointmentDto> GetAppointmentDtos(List<Appointment> appointments)
        {
            List<AppointmentDto> appointmentsDto = new List<AppointmentDto>();
            foreach (Appointment a in appointments)
            {
                AppointmentDto appointmentDTO = new AppointmentDto(a);
                appointmentDTO.PhysicianDTO = HttpRequest.GetPhysiciantByIdAsync(a.PhysicianSerialNumber).Result;
                appointmentDTO.PatientsDTO = HttpRequest.GetPatientByIdAsync(a.PatientSerialNumber).Result;
                appointmentsDto.Add(appointmentDTO);
            }
            return appointmentsDto;
        }

        internal List<AppointmentDto> GetAllAppointmentsByPatientIdDateAndDoctor(string patientId, string date, string doctorName)
        {
            List<PhysiciansDTO> physician = HttpRequest.GetPhysycianByName(doctorName).Result;

            List<Appointment> appointments = _appointmentRepository.GetAllAppointmentsByPatientIdDateAndDoctor(patientId, dateFromStringConverter.CreateDateTime1(date.Split(" ")[0]), physician[0].Id);
            List<Appointment> resultAppointments = new List<Appointment>();
            foreach (Appointment a in appointments)
            {
                if (DateTime.Now > a.Date)
                    resultAppointments.Add(a);
            }
            return GetAppointmentDtos(resultAppointments);

        }
        internal ProcedureTypeDTO GetProcedureType(string procedureTypeId)
        {
            var procedureType=_procedureTypeRepository.GetById(procedureTypeId);
            procedureType.Specialization = new Specialization();
            procedureType.Specialization.Name= HttpRequest.GetSpecializationByIdAsync(procedureType.SpecializationSerialNumber).Result.Name;
            return new ProcedureTypeDTO(procedureType);
        }

        /// <summary>
        ///method for getting patient's scheduled appointments 
        ///</summary>
        ///<param name="patientId"> String type object
        ///<returns>
        ///list of appointments
        ///</returns>
        internal List<AppointmentDto> GetAllAppointmentsByPatientIdActive(string patientId)
        {
            List<AppointmentDto> allAppointments = GetAppointmentDtos(_appointmentRepository.GetByPatientIdActive(patientId));
            List<AppointmentDto> appotintmentsInFuture = new List<AppointmentDto>();
            foreach (AppointmentDto appointment in allAppointments)
            {
                if (appointment.Date > DateTime.Now)
                    appotintmentsInFuture.Add(appointment);
            }
            return appotintmentsInFuture;
        }

        /// <summary>
        ///method for getting patient's canceled appointments
        ///</summary>
        ///<param name="patientId"> String type object
        ///<returns>
        ///list of appointments
        ///</returns>
        internal List<AppointmentDto> GetAllAppointmentsByPatientIdCanceled(string patientId)
        {
            List<Appointment> appointments = _appointmentRepository.GetByPatientIdCanceled(patientId);
            return appointmentDTO.ConvertListToAppointmentDTO(appointments);
        }

        /// <summary>
        ///method for getting patient's all past appointments 
        ///</summary>
        ///<param name="patientId"> String type object
        ///<returns>
        ///list of appoitnemtns
        ///</returns>
        public List<AppointmentDto> GetAllAppointmentsByPatientIdPast(string patientId)
        {
            List<Appointment> allAppointments = _appointmentRepository.GetByPatientId(patientId);
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in allAppointments)
            {
                if (appointment.Date < DateTime.Now)
                    appointments.Add(appointment);
            }
            if (appointments.Count == 0)
                return null;
            return GetAppointmentDtos(appointments);
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
        internal bool isSurveyDoneByPatientIdAppointmentDatePhysicianName(string patientId, string appointmentDate,
            string physicianName)
        {
            List<Physician> physitianResult = _physicianRepository.GetByName(physicianName);
            List<String> physicianId = new List<string>();
            foreach (Physician physician in physitianResult)
            {
                physicianId.Add(physician.Id);
            }
             List<Appointment>appointments= _appointmentRepository.IsSurveyDoneByPatientIdAppointmentDatePhysicianNameAppointments(patientId, appointmentDate,physitianResult[0].Id);
            if (appointments.Count==0)
                return false;
            if (appointments[0].IsSurveyDone)
                return true;
            return false;
        }

        /// <summary>
        ///method for setting value of isSurveyDone on true in database
        ///</summary>
        internal void Update(AppointmentDto appointmentDto)
        {
            var appointment = _appointmentRepository.GetById(appointmentDto.SerialNumber);
            appointment.IsSurveyDone = true;
            _appointmentRepository.Update(appointment);
        }

        /// <summary>
        ///method for getting all appointments without survey done
        ///</summary>
        ///<returns>
        ///list of appointments
        ///</returns>
        internal List<AppointmentDto> GetAllAppointmentsWithoutDoneSurvey(String patientId)
        {
            List<AppointmentDto> appotintmentsWithoutSurvey = GetAppointmentDtos(_appointmentRepository.GetByPatientIdWithoutSurvey(patientId));
            List<AppointmentDto> appoitmentsResult = new List<AppointmentDto>();
            foreach (AppointmentDto appointment in appotintmentsWithoutSurvey)
            {
                if (appointment.Date < DateTime.Now)
                    appoitmentsResult.Add(appointment);
            }
            return appoitmentsResult;
        }

        /// <summary>
        ///method for getting all appointments with survey done
        ///</summary>
        ///<returns>
        ///list of appointments
        ///</returns>
        public List<AppointmentDto> GetAllAppointmentsWithDoneSurvey(String patientId)
        {
            List<AppointmentDto> appotintmentsWithSurvey = GetAppointmentDtos(_appointmentRepository.GetByPatientIdWithSurvey(patientId));
            List<AppointmentDto> appoitmentsResult = new List<AppointmentDto>();
            foreach (AppointmentDto appointment in appotintmentsWithSurvey)
            {
                if (appointment.Date < DateTime.Now)
                    appoitmentsResult.Add(appointment);
            }
            return appoitmentsResult;
        }

        public bool IsUserMalicious(string patientId)
        {
            List<DateTime> dates = _appointmentRepository.GetByPatientIdCanceledDates(patientId);

            dates.Sort((date1, date2) => date2.CompareTo(date1));
            TimeSpan difference = dates[1].Subtract(DateTime.Now);
            if (dates.Count >= 2 && Math.Abs(difference.Days) <= 30)
                return true;
            else
                return false;
        }

        public bool CancelAppointment(string appointmentSerialNumber)
        {
            var appointment = _appointmentRepository.GetById(appointmentSerialNumber);
            if (!appointment.Active) return false;
            appointment.Active = false;
            _appointmentRepository.Update(appointment);
            return true;
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
       
        public List<AppointmentWithRecommendationDTO> AppointmentRecomendation(string physicianId,
            string specializationName, string[] dates)
        {
            List<AppointmentWithRecommendationDTO> availableAppointments = new List<AppointmentWithRecommendationDTO>();
            foreach (string date in dates)
            {
                List<TimeIntervalsDTO> appointments = GetAllAvailableAppointments(physicianId, specializationName, date);
                if (appointments.Count > 0)
                    availableAppointments.Add(
                        new AppointmentWithRecommendationDTO(date, physicianId, appointments, ""));
            }

            if (!availableAppointments.Any())
            {
                List<Physician> physicians = _physicianRepository.GetBySpecializationName(specializationName);
                foreach (Physician physician in physicians)
                {
                    foreach (string date in dates)
                    {
                        availableAppointments.Add(new AppointmentWithRecommendationDTO(date, physician.Id,
                            GetAllAvailableAppointments(physician.Id, specializationName, date),
                            physician.Name + " " + physician.Surname));
                    }
                }
            }

            return availableAppointments;

        }
       
    }
}