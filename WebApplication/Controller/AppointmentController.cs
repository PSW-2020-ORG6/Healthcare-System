using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using HealthClinicBackend.Backend.Dto;
using MicroServiceAppointment.Backend.Dto;
using MicroServiceAccount.Backend.Dto;

namespace MicroServiceAppointment.Backend.Controllers
{
    [Route("appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {


        [Authorize]
        [HttpGet("allAppointmentsByPatientId")]
        public List<AppointmentDto> GetAllAppointmentsByPatientId(String patientId)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("physicians")]
        public List<PhysicianDTO> GetAllPhysicians()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("specializations")]
        public List<SpecializationDTO> GetAllSpecializations()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("allAppointments")]
        public List<AppointmentDto> GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("allAppointmentsByPatientIdActive")]
        public List<AppointmentDto> GetAllAppointmentsByPatientIdActive(String patientId)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("allAppointmentsByPatientIdCanceled")]
        public List<AppointmentDto> GetAllAppointmentsByPatientIdCanceled(String patientId)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("appointments")]
        public List<TimeIntervalDTO> GetAllAvailableAppointments(string physicianId, string specializationName,
            string date)
        {
            throw new NotImplementedException();

        }

        [Authorize]
        [HttpPost("makeAppointment/{physicianId}/{timeIntervalStart}/{date}")]
        public IActionResult MakeAppointment(string physicianId, DateTime timeIntervalStart, string date)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("allAppointmentsByPatientIdPast")]
        public List<AppointmentDto> GellAllAppointmentsByPatientIdPast(String patientId)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("allAppointmentsWithSurvey")]
        public List<AppointmentDto> GetAllAppointmentsWithDoneSurvey()
        {
            throw new NotImplementedException();

        }

        [Authorize]
        [HttpGet("allAppointmentsWithoutSurvey")]
        public List<AppointmentDto> GetAllAppointmentsWithoutSurvey()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("isSurveyDoneByPatientIdAppointmentDatePhysicianName")]
        public bool IsSurveyDoneByPatientIdAppointmentDatePhysicianName([FromQuery] String patientId,
            [FromQuery] String appointmentDate, [FromQuery] String physicianName)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpPut("setSurveyDoneOnAppointment")]
        public void SetSurveyDoneOnAppointment(AppointmentDto appointmentDto)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("appointmentsWithReccomendation")]
        public List<AppointmentWithRecommendationDTO> GetAllAvailableAppointmentsWithRecommendation(string physicianId,
            string specializationName, string dates)
        {
            throw new NotImplementedException();

        }

        [Authorize]
        [HttpGet("appointmentsWithPhysicianPriority")]
        public List<AppointmentWithRecommendationDTO> GetAllAvailableAppointmentsWithPhysicianPriority(
            string physicianId, string specializationName, string dates)
        {
            throw new NotImplementedException();

        }

        [Authorize]
        [HttpPut("cancelAppointment")]
        public bool CancelAppointment(AppointmentDto appointment)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("IsUserMalicious")]
        public bool IsUserMalicious(string patientId)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpPut("SetUserToMalicious")]
        public bool SetUserToMalicious(AppointmentDto appointment)
        {
            throw new NotImplementedException();
        }
    }
}
