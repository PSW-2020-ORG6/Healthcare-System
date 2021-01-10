using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MicroServiceAppointment.Backend.Service;
using MicroServiceAppointment.Backend.Dto;
using Microsoft.AspNetCore.Authorization;
using MicroServiceAppointment.Backend.Util;
using MicroServiceAccount.Backend.Dto;
using HealthClinicBackend.Backend.Model.Schedule;

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
        public List<AppointmentDto> GetAllAppointments()
        {
            return _appointmentService.GetAllAppointments();
        }

        [Authorize]
        [HttpGet("allAppointmentsByPatientIdActive/{patientId}")]
        public List<AppointmentDto> GetAllAppointmentsByPatientIdActive(String patientId)
        {
            return _appointmentService.GetAllAppointmentsByPatientIdActive(patientId);
        }

        [Authorize]
        [HttpGet("allAppointmentsByPatientIdCanceled/{patientId}")]
        public List<AppointmentDto> GetAllAppointmentsByPatientIdCanceled(String patientId)
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

        //[Authorize]
        //[HttpPost("makeAppointment/{physicianId}/{timeIntervalStart}/{date}")]
        //public IActionResult MakeAppointment(string physicianId, DateTime timeIntervalStart, string date)
        //{
        //    if (physicianId != null && timeIntervalStart != null && _appointmentDto.IsDataValid(date))
        //    {
        //        if (_appointmentService.AddAppointment(new Appointment(physicianId, date, timeIntervalStart)))
        //            return Ok();
        //        else
        //            return BadRequest();
        //    }
        //    else
        //        return BadRequest();
        //}

        [Authorize]
        [HttpGet("allAppointmentsByPatientIdPast/{patientId}")]
        public List<AppointmentDto> GellAllAppointmentsByPatientIdPast(String patientId)
        {
            return _appointmentService.GetAllAppointmentsByPatientIdPast(patientId);
        }

        [Authorize]
        [HttpGet("allAppointmentsWithSurvey")]
        public List<AppointmentDto> GetAllAppointmentsWithDoneSurvey()
        {
            AppointmentDto appointment = new AppointmentDto();
            return appointment.ConvertListToAppointmentDTO(_appointmentService.GetAllAppointmentsWithDoneSurvey());
        }

        [Authorize]
        [HttpGet("allAppointmentsWithoutSurvey")]
        public List<AppointmentDto> GetAllAppointmentsWithoutSurvey()
        {
            return _appointmentService.GetAllAppointmentsWithoutDoneSurvey();
        }

        [Authorize]
        [HttpGet("isSurveyDoneByPatientIdAppointmentDatePhysicianName/{patientId}/{appointmentDate}/{physicianName}")]
        public bool IsSurveyDoneByPatientIdAppointmentDatePhysicianName([FromQuery] String patientId,
            [FromQuery] String appointmentDate, [FromQuery] String physicianName)
        {
            return _appointmentService.isSurveyDoneByPatientIdAppointmentDatePhysicianName(patientId, appointmentDate,
                physicianName);
        }

        [Authorize]
        [HttpPut("setSurveyDoneOnAppointment")]
        public void SetSurveyDoneOnAppointment(AppointmentDto appointmentDto)
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
        public bool CancelAppointment(AppointmentDto appointment)
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
        public bool SetUserToMalicious(AppointmentDto appointment)
        {
            return _appointmentService.SetUserToMalicious(appointment.PatientDTO.Id);
        }
    }
}
