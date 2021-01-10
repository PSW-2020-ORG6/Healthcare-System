using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using HealthClinicBackend.Backend.Dto;
using MicroServiceAppointment.Backend.Dto;
using MicroServiceAccount.Backend.Dto;

namespace WebApplication.Backend.Controllers
    {
    [Route("appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        [HttpGet("allAppointmentsByPatientId")]
        public List<AppointmentDto> GetAllAppointmentsByPatientId(String patientId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("physicians")]
        public List<PhysicianDTO> GetAllPhysicians()
        {
            throw new NotImplementedException();
        }

        [HttpGet("specializations")]
        public List<SpecializationDTO> GetAllSpecializations()
        {
            throw new NotImplementedException();
        }

        [HttpGet("allAppointments")]
        public List<AppointmentDto> GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        [HttpGet("allAppointmentsByPatientIdActive")]
        public List<AppointmentDto> GetAllAppointmentsByPatientIdActive(String patientId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("allAppointmentsByPatientIdCanceled")]
        public List<AppointmentDto> GetAllAppointmentsByPatientIdCanceled(String patientId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("appointments")]
        public List<TimeIntervalDTO> GetAllAvailableAppointments(string physicianId, string specializationName,
            string date)
        {
            throw new NotImplementedException();

        }

        [HttpPost("makeAppointment/{physicianId}/{timeIntervalStart}/{date}")]
        public IActionResult MakeAppointment(string physicianId, DateTime timeIntervalStart, string date)
        {
            throw new NotImplementedException();
        }

        [HttpGet("allAppointmentsByPatientIdPast")]
        public List<AppointmentDto> GellAllAppointmentsByPatientIdPast(String patientId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("allAppointmentsWithSurvey")]
        public List<AppointmentDto> GetAllAppointmentsWithDoneSurvey()
        {
            throw new NotImplementedException();

        }

        [HttpGet("allAppointmentsWithoutSurvey")]
        public List<AppointmentDto> GetAllAppointmentsWithoutSurvey()
        {
            throw new NotImplementedException();
        }

        [HttpGet("isSurveyDoneByPatientIdAppointmentDatePhysicianName")]
        public bool IsSurveyDoneByPatientIdAppointmentDatePhysicianName([FromQuery] String patientId,
            [FromQuery] String appointmentDate, [FromQuery] String physicianName)
        {
            throw new NotImplementedException();
        }

        [HttpPut("setSurveyDoneOnAppointment")]
        public void SetSurveyDoneOnAppointment(AppointmentDto appointmentDto)
        {
            throw new NotImplementedException();
        }

        [HttpGet("appointmentsWithReccomendation")]
        public List<AppointmentWithRecommendationDTO> GetAllAvailableAppointmentsWithRecommendation(string physicianId,
            string specializationName, string dates)
        {
            throw new NotImplementedException();

        }

        [HttpGet("appointmentsWithPhysicianPriority")]
        public List<AppointmentWithRecommendationDTO> GetAllAvailableAppointmentsWithPhysicianPriority(
            string physicianId, string specializationName, string dates)
        {
            throw new NotImplementedException();

        }

        [HttpPut("cancelAppointment")]
        public bool CancelAppointment(AppointmentDto appointment)
        {
            throw new NotImplementedException();
        }

        [HttpGet("IsUserMalicious")]
        public bool IsUserMalicious(string patientId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("SetUserToMalicious")]
        public bool SetUserToMalicious(AppointmentDto appointment)
        {
            throw new NotImplementedException();
        }
    }
}
