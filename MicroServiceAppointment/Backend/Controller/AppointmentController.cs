using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MicroServiceAppointment.Backend.Service;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;
using MicroServiceAppointment.Backend.Util;
using MicroServiceAppointment.Backend.Dto;
using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Repository.Generic;

namespace MicroServiceAppointment.Backend.Controllers
{
    [Route("appointmentMicroservice")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;
        private readonly DateFromStringConverter _dateFromStringConverter;
        private readonly AppointmentDto _appointmentDto;

        public AppointmentController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
            _dateFromStringConverter = new DateFromStringConverter();
            _appointmentDto = new AppointmentDto();
        }

        [Authorize]
        [HttpGet("allAppointmentsByPatientId/{patientId}")]
        public List<AppointmentDto> GetAllAppointmentsByPatientId(String patientId)
        {
            HttpRequest.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                   , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            List<AppointmentDto> appointments = _appointmentService.GetAllAppointmentsByPatientId(patientId);
            foreach (AppointmentDto appointment in appointments)
                appointment.PhysicianDTO = HttpRequest.GetPhysiciantByIdAsync(appointment.PhysicianDTO.Id).Result;
            return appointments;
        }

        [Authorize]
        [HttpGet("allAppointments")]
        public List<AppointmentDto> GetAllAppointments()
        {

            List<AppointmentDto> appointments = _appointmentService.GetAllAppointments();
            foreach (AppointmentDto appointment in appointments)
                appointment.PhysicianDTO = HttpRequest.GetPhysiciantByIdAsync(appointment.PhysicianDTO.Id).Result;
            return appointments;
        }

        [Authorize]
        [HttpGet("allAppointmentsByPatientIdActive/{patientId}")]
        public List<AppointmentDto> GetAllAppointmentsByPatientIdActive(String patientId)
        {

            List<AppointmentDto> appointments = _appointmentService.GetAllAppointmentsByPatientIdActive(patientId);
            foreach (AppointmentDto appointment in appointments)
                appointment.PhysicianDTO = HttpRequest.GetPhysiciantByIdAsync(appointment.PhysicianDTO.Id).Result;
            return appointments;
        }

        [Authorize]
        [HttpGet("allAppointmentsByPatientIdCanceled/{patientId}")]
        public List<AppointmentDto> GetAllAppointmentsByPatientIdCanceled(String patientId)
        {
            List<AppointmentDto> appointments = _appointmentService.GetAllAppointmentsByPatientIdCanceled(patientId);
            foreach (AppointmentDto appointment in appointments)
                appointment.PhysicianDTO = HttpRequest.GetPhysiciantByIdAsync(appointment.PhysicianDTO.Id).Result;
            return appointments;
        }

            [Authorize]
        [HttpGet("avaliableTimeIntervals/{physicianId}/{specializationName}/{date}")]
        public List<TimeIntervalsDTO> GetAllAvailableAppointments(string physicianId, string specializationName,
            string date)
        {
            if (_dateFromStringConverter.IsPreferredTimeValid(date))
                return _appointmentService.GetAllAvailableAppointments(physicianId, specializationName, date);
            else
                return null;
        }

        [Authorize]
        [HttpPost("makeAppointment")]
        public IActionResult MakeAppointment(AppointmentSchedulingDTO appointmentSchedulingDTO)
        {
            if (appointmentSchedulingDTO!= null && appointmentSchedulingDTO.IsDataValid(appointmentSchedulingDTO.Date))
            {
                var dtStart = DateTime.ParseExact(appointmentSchedulingDTO.TimeIntervalStart, "s", null);
                var dtEnd = DateTime.ParseExact(appointmentSchedulingDTO.TimeIntervalEnd, "s", null);
                if (_appointmentService.AddAppointment(new Appointment(appointmentSchedulingDTO.PhysicianId,
                    appointmentSchedulingDTO.Date, dtStart, appointmentSchedulingDTO.PatientId, dtEnd)))
                    return Ok();
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }
        [Authorize]
        [HttpGet("allAppointmentsByPatientIdPast/{patientId}")]
        public List<AppointmentDto> GellAllAppointmentsByPatientIdPast(String patientId)
        {

            List<AppointmentDto> appointments = _appointmentService.GetAllAppointmentsByPatientIdPast(patientId);
            foreach (AppointmentDto appointment in appointments)
                appointment.PhysicianDTO = HttpRequest.GetPhysiciantByIdAsync(appointment.PhysicianDTO.Id).Result;
            return appointments;
        }
        [Authorize]
        [HttpGet("allAppointmentsWithSurvey/{patientId}")]
        public List<AppointmentDto> GetAllAppointmentsWithDoneSurvey(String patientId)
        {
            HttpRequest.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                 , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            List<AppointmentDto> appointments = _appointmentService.GetAllAppointmentsWithDoneSurvey(patientId);
            foreach (AppointmentDto appointment in appointments)
                appointment.PhysicianDTO = HttpRequest.GetPhysiciantByIdAsync(appointment.PhysicianDTO.Id).Result;
            return appointments;
        }
        [Authorize]
        [HttpGet("allAppointmentsWithoutSurvey/{patientId}")]
        public List<AppointmentDto> GetAllAppointmentsWithoutSurvey(String patientId)
        {
            HttpRequest.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            List<AppointmentDto> appointments = _appointmentService.GetAllAppointmentsWithoutDoneSurvey(patientId);
            foreach (AppointmentDto appointment in appointments)
                appointment.PhysicianDTO = HttpRequest.GetPhysiciantByIdAsync(appointment.PhysicianDTO.Id).Result;
            return appointments;
        }
        [Authorize]
        [HttpGet("isSurveyDoneByPatientIdAppointmentDatePhysicianName/{patientId}/{appointmentDate}/{physicianName}")]
        public bool IsSurveyDoneByPatientIdAppointmentDatePhysicianName( String patientId,
            String appointmentDate, String physicianName)
        {
            HttpRequest.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            return _appointmentService.isSurveyDoneByPatientIdAppointmentDatePhysicianName(patientId,appointmentDate,physicianName);
        }
        [Authorize]
        [HttpPut("update")]
        public void SetSurveyDoneOnAppointment(AppointmentDto appointmentDto)
        {
            _appointmentService.Update(appointmentDto);
        }

        [Authorize]
        [HttpGet("appointmentsWithReccomendation/{physicianId}/{specializationName}/{dates}")]
        public List<AppointmentWithRecommendationDTO> GetAllAvailableAppointmentsWithRecommendation(string physicianId,
            string specializationName, string dates)
        {
            HttpRequest.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            if (_dateFromStringConverter.IsPreferredTimeIntervalValid(dates))
                return _appointmentService.AppointmentRecomendation(physicianId, specializationName,
                    _dateFromStringConverter.DateGeneration(dates));
            else
                return null;
        }
        
        [Authorize]
        [HttpGet("appointmentsWithPhysicianPriority/{physicianId}/{specializationName}/{dates}")]
        public List<AppointmentWithRecommendationDTO> GetAllAvailableAppointmentsWithPhysicianPriority(
            string physicianId, string specializationName, string dates)
        {
            if (_dateFromStringConverter.IsPreferredTimeIntervalValid(dates))
                return _appointmentService.AppointmentRecomendationWithPhysicianPriority(physicianId,
                    specializationName,
                    _dateFromStringConverter.DateGeneration(dates));
            else
                return null;
        }

        [Authorize]
        [HttpPut("cancelAppointment")]
        public bool CancelAppointment(AppointmentDto appointment)
        {
            return _appointmentService.CancelAppointment(appointment.SerialNumber);
        }

        [Authorize]
        [HttpGet("IsUserMalicious/{patientId}")]
        public bool IsUserMalicious(string patientId)
        {
            return _appointmentService.IsUserMalicious(patientId);
        }

        [Authorize]
        [HttpGet("getProcedureTypeById/{procedureTypeId}")]
        public ProcedureTypeDTO GetProcedureType(string procedureTypeId)
        {
            HttpRequest.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                  , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            return _appointmentService.GetProcedureType(procedureTypeId);
        }

        [Authorize]
        [HttpGet("getMedicineById/{medicineId}")]
        public MedicineDTO GetMedicine(string medicineId)
        {
            HttpRequest.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                  , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            return _appointmentService.GetMedicine(medicineId);
        }

        [Authorize]
        [HttpGet("getAllAppointmentsByPatientIdDateAndDoctor/{patientId}/{date}/{doctorName}")]
        public List<AppointmentDto> GetAllAppointmentsByPatientIdDateAndDoctor(String patientId, String date, string doctorName)
        {
            HttpRequest.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                   , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            List<AppointmentDto> appointments = _appointmentService.GetAllAppointmentsByPatientIdDateAndDoctor(patientId, date, doctorName);
            foreach (AppointmentDto appointment in appointments)
                appointment.PhysicianDTO = HttpRequest.GetPhysiciantByIdAsync(appointment.PhysicianDTO.Id).Result;
            return appointments;
        }
    }
}
