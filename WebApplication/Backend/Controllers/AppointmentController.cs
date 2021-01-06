using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using WebApplication.Backend.Services;
using HealthClinicBackend.Backend.Dto;
using WebApplication.Backend.DTO;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Backend.Controllers
{
    [Route("appointment")]
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
        [HttpGet("allAppointmentsByPatientId")]
        public List<AppointmentDTO> GetAllAppointmentsByPatientId(String patientId)
        {
            return _appointmentService.GetAllAppointmentsByPatientId(patientId);
        }

        [Authorize]
        [HttpGet("physicians")]
        public List<PhysicianDTO> GetAllPhysicians()
        {
            return _appointmentService.GetAllPhysicians();
        }

        [Authorize]
        [HttpGet("specializations")]
        public List<SpecializationDTO> GetAllSpecializations()
        {
            return _appointmentService.GetAllSpecializations();
        }

        [Authorize]
        [HttpGet("allAppointments")]
        public List<AppointmentDTO> GetAllAppointments()
        {
            return _appointmentService.GetAllAppointments();
        }

        [Authorize]
        [HttpGet("allAppointmentsByPatientIdActive")]
        public List<AppointmentDTO> GetAllAppointmentsByPatientIdActive(String patientId)
        {
            return _appointmentService.GetAllAppointmentsByPatientIdActive(patientId);
        }

        [Authorize]
        [HttpGet("allAppointmentsByPatientIdCanceled")]
        public List<AppointmentDTO> GetAllAppointmentsByPatientIdCanceled(String patientId)
        {
            return _appointmentService.GetAllAppointmentsByPatientIdCanceled(patientId);
        }

        [Authorize]
        [HttpGet("appointments")]
        public List<TimeIntervalDTO> GetAllAvailableAppointments(string physicianId, string specializationName,
            string date)
        {
            if (_dateFromStringConverter.IsPreferredTimeValid(date))
                return _appointmentService.GetAllAvailableAppointments(physicianId, specializationName, date);
            else
                return null;
        }

        [Authorize]
        [HttpPost("makeAppointment/{physicianId}/{timeIntervalStart}/{date}")]
        public IActionResult MakeAppointment(string physicianId, DateTime timeIntervalStart, string date)
        {
            if (physicianId != null && timeIntervalStart != null && _appointmentDto.IsDataValid(date))
            {
                if (_appointmentService.AddAppointment(new Appointment(physicianId, date, timeIntervalStart)))
                    return Ok();
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [Authorize]
        [HttpGet("allAppointmentsByPatientIdPast")]
        public List<AppointmentDTO> GellAllAppointmentsByPatientIdPast(String patientId)
        {
            return _appointmentService.GetAllAppointmentsByPatientIdPast(patientId);
        }

        [Authorize]
        [HttpGet("allAppointmentsWithSurvey")]
        public List<AppointmentDTO> GetAllAppointmentsWithDoneSurvey()
        {
            AppointmentDTO appointment = new AppointmentDTO();
            return appointment.ConvertListToAppointmentDTO(_appointmentService.GetAllAppointmentsWithDoneSurvey());
        }

        [Authorize]
        [HttpGet("allAppointmentsWithoutSurvey")]
        public List<AppointmentDTO> GetAllAppointmentsWithoutSurvey()
        {
            return _appointmentService.GetAllAppointmentsWithoutDoneSurvey();
        }

        [Authorize]
        [HttpGet("isSurveyDoneByPatientIdAppointmentDatePhysicianName")]
        public bool IsSurveyDoneByPatientIdAppointmentDatePhysicianName([FromQuery] String patientId,
            [FromQuery] String appointmentDate, [FromQuery] String physicianName)
        {
            return _appointmentService.isSurveyDoneByPatientIdAppointmentDatePhysicianName(patientId, appointmentDate,
                physicianName);
        }

        [Authorize]
        [HttpPut("setSurveyDoneOnAppointment")]
        public void SetSurveyDoneOnAppointment(AppointmentDTO appointmentDto)
        {
            _appointmentService.setSurveyDoneOnAppointment(appointmentDto);
        }

        [Authorize]
        [HttpGet("appointmentsWithReccomendation")]
        public List<AppointmentWithRecommendationDTO> GetAllAvailableAppointmentsWithRecommendation(string physicianId,
            string specializationName, string dates)
        {
            if (_dateFromStringConverter.IsPreferredTimeIntervalValid(dates))
                return _appointmentService.AppointmentRecomendation(physicianId, specializationName,
                    _dateFromStringConverter.DateGeneration(dates));
            else
                return null;
        }

        [Authorize]
        [HttpGet("appointmentsWithPhysicianPriority")]
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
        public bool CancelAppointment(AppointmentDTO appointment)
        {
            return _appointmentService.CancelAppointment(appointment.SerialNumber);
        }

        [Authorize]
        [HttpGet("IsUserMalicious")]
        public bool IsUserMalicious(string patientId)
        {
            return _appointmentService.IsUserMalicious(patientId);
        }

        [Authorize]
        [HttpPut("SetUserToMalicious")]
        public bool SetUserToMalicious(AppointmentDTO appointment)
        {
            return _appointmentService.SetUserToMalicious(appointment.PatientDTO.Id);
        }
    }
}
