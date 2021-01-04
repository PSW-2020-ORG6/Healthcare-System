using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using WebApplication.Backend.Services;
using HealthClinicBackend.Backend.Dto;
using WebApplication.Backend.DTO;

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

        [HttpGet("allAppointmentsByPatientId")]
        public List<AppointmentDTO> GetAllAppointmentsByPatientId(String patientId)
        {
            return _appointmentService.GetAllAppointmentsByPatientId(patientId);
        }

        [HttpGet("physicians")]
        public List<PhysicianDTO> GetAllPhysicians()
        {
            return _appointmentService.GetAllPhysicians();
        }

        [HttpGet("specializations")]
        public List<SpecializationDTO> GetAllSpecializations()
        {
            return _appointmentService.GetAllSpecializations();
        }

        [HttpGet("allAppointments")]
        public List<AppointmentDTO> GetAllAppointments()
        {
            return _appointmentService.GetAllAppointments();
        }

        [HttpGet("allAppointmentsByPatientIdActive")]
        public List<AppointmentDTO> GetAllAppointmentsByPatientIdActive(String patientId)
        {
            return _appointmentService.GetAllAppointmentsByPatientIdActive(patientId);
        }

        [HttpGet("allAppointmentsByPatientIdCanceled")]
        public List<AppointmentDTO> GetAllAppointmentsByPatientIdCanceled(String patientId)
        {
            return _appointmentService.GetAllAppointmentsByPatientIdCanceled(patientId);
        }

        [HttpGet("appointments")]
        public List<TimeIntervalDTO> GetAllAvailableAppointments(string physicianId, string specializationName,
            string date)
        {
            if (_dateFromStringConverter.IsPreferredTimeValid(date))
                return _appointmentService.GetAllAvailableAppointments(physicianId, specializationName, date);
            else
                return null;
        }

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

        [HttpGet("allAppointmentsByPatientIdPast")]
        public List<AppointmentDTO> GellAllAppointmentsByPatientIdPast(String patientId)
        {
            return _appointmentService.GetAllAppointmentsByPatientIdPast(patientId);
        }


        [HttpGet("allAppointmentsWithSurvey")]
        public List<AppointmentDTO> GetAllAppointmentsWithDoneSurvey()
        {
            AppointmentDTO appointment = new AppointmentDTO();
            return appointment.ConvertListToAppointmentDTO(_appointmentService.GetAllAppointmentsWithDoneSurvey());
        }

        [HttpGet("allAppointmentsWithoutSurvey")]
        public List<AppointmentDTO> GetAllAppointmentsWithoutSurvey()
        {
            return _appointmentService.GetAllAppointmentsWithoutDoneSurvey();
        }

        [HttpGet("isSurveyDoneByPatientIdAppointmentDatePhysicianName")]
        public bool IsSurveyDoneByPatientIdAppointmentDatePhysicianName([FromQuery] String patientId,
            [FromQuery] String appointmentDate, [FromQuery] String physicianName)
        {
            return _appointmentService.isSurveyDoneByPatientIdAppointmentDatePhysicianName(patientId, appointmentDate,
                physicianName);
        }

        [HttpPut("setSurveyDoneOnAppointment")]
        public void SetSurveyDoneOnAppointment(AppointmentDTO appointmentDto)
        {
            _appointmentService.setSurveyDoneOnAppointment(appointmentDto);
        }

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

        [HttpPut("cancelAppointment")]
        public bool CancelAppointment(AppointmentDTO appointment)
        {
            return _appointmentService.CancelAppointment(appointment.SerialNumber);
        }

        [HttpGet("IsUserMalicious")]
        public bool IsUserMalicious(string patientId)
        {
            return _appointmentService.IsUserMalicious(patientId);
        }

        [HttpPut("SetUserToMalicious")]
        public bool SetUserToMalicious(AppointmentDTO appointment)
        {
            return _appointmentService.SetUserToMalicious(appointment.PatientDTO.Id);
        }
    }
}