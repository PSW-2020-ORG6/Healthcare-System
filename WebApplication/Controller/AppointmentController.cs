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
using System.Text;

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
        public async Task<List<AppointmentDto>> GetAllAppointments()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                     , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/allAppointments");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allAppointmentsByPatientIdActive")]
        public async Task<List<AppointmentDto>> GetAllAppointmentsByPatientIdActive(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                 , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/allAppointmentsByPatientIdActive/"+patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allAppointmentsByPatientIdCanceled")]
        public async Task<List<AppointmentDto>> GetAllAppointmentsByPatientIdCanceled(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                 , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/allAppointmentsByPatientIdCanceled/" + patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
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
        public async Task<List<AppointmentDto>> GellAllAppointmentsByPatientIdPast(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                  , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/allAppointmentsByPatientIdPast/" + patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allAppointmentsWithSurvey")]
        public async Task<List<AppointmentDto>> GetAllAppointmentsWithDoneSurvey()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                   , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/allAppointmentsWithSurvey");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allAppointmentsWithoutSurvey")]
        public async Task<List<AppointmentDto>> GetAllAppointmentsWithoutSurvey()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                   , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/allAppointmentsWithoutSurvey");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("isSurveyDoneByPatientIdAppointmentDatePhysicianName")]
        public async Task<bool> IsSurveyDoneByPatientIdAppointmentDatePhysicianName([FromQuery] String patientId,
            [FromQuery] String appointmentDate, [FromQuery] String physicianName)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                   , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/isSurveyDoneByPatientIdAppointmentDatePhysicianName/" + patientId+"/"+appointmentDate+"/"+physicianName);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }
        //nije teestirano
        [HttpPut("setSurveyDoneOnAppointment")]
        public async void SetSurveyDoneOnAppointment(AppointmentDto appointmentDto)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                  , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var content = new StringContent(JsonConvert.SerializeObject(appointmentDto, Formatting.Indented), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("http://localhost:57056/appointmentMicroservice/setSurveyDoneOnAppointment", content);
            response.EnsureSuccessStatusCode();
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
        public async Task<bool> IsUserMalicious(string patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                      , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/IsUserMalicious/"+patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }
    }
}
