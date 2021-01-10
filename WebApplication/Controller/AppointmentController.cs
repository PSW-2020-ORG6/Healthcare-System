using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using HealthClinicBackend.Backend.Dto;
using MicroServiceAppointment.Backend.Dto;
using MicroServiceAccount.Backend.Dto;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebApplication.Backend.Controllers
    {
    [Route("appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpGet("allAppointmentsByPatientId")]
        public async Task<List<AppointmentDto>>  GetAllAppointmentsByPatientId(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                    , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/allAppointmentsByPatientId/" + patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
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
