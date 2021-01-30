using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MicroServiceAccount.Backend.Dto;
using MicroServiceAppointment.Backend.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApplication.util;

namespace WebApplication.Controller
{
    [Route("appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string _appointmentServiceUrl;

        public AppointmentController(MicroServiceUris uris)
        {
            _appointmentServiceUrl = uris.AppointmentServiceUrl;
        }

        [HttpGet("allAppointmentsByPatientId")]
        public async Task<List<AppointmentDto>> GetAllAppointmentsByPatientId(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/appointmentMicroservice/allAppointmentsByPatientId/" + patientId);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allAppointments")]
        public async Task<List<AppointmentDto>> GetAllAppointments()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/appointmentMicroservice/allAppointments");
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allAppointmentsByPatientIdActive")]
        public async Task<List<AppointmentDto>> GetAllAppointmentsByPatientIdActive(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/appointmentMicroservice/allAppointmentsByPatientIdActive/" + patientId);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allAppointmentsByPatientIdCanceled")]
        public async Task<List<AppointmentDto>> GetAllAppointmentsByPatientIdCanceled(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/appointmentMicroservice/allAppointmentsByPatientIdCanceled/" + patientId);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("avaliableTimeIntervals")]
        public async Task<List<TimeIntervalDTO>> GetAllAvailableAppointments(string physicianId,
            string specializationName,
            string date)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/appointmentMicroservice/avaliableTimeIntervals/" + physicianId + "/" +
                                   specializationName + "/" + date);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<TimeIntervalDTO>>(await response.Content.ReadAsStringAsync());
        }

        [HttpPost("makeAppointment")]
        public async Task<IActionResult> MakeAppointment(AppointmentSchedulingDTO appointmentSchedulingDTO)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter1 =
                new StringContent(JsonConvert.SerializeObject(appointmentSchedulingDTO, Formatting.Indented),
                    Encoding.UTF8, "application/json");

            var path = GetFullPath("/appointmentMicroservice/makeAppointment/");
            HttpResponseMessage response =
                await client.PostAsync(path, parameter1);
            response.EnsureSuccessStatusCode();
            if (response.ReasonPhrase.Equals("OK")) return Ok();
            else return BadRequest();
        }

        [HttpGet("allAppointmentsByPatientIdPast")]
        public async Task<List<AppointmentDto>> GellAllAppointmentsByPatientIdPast(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/appointmentMicroservice/allAppointmentsByPatientIdPast/" + patientId);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allAppointmentsWithSurvey")]
        public async Task<List<AppointmentDto>> GetAllAppointmentsWithDoneSurvey(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/appointmentMicroservice/allAppointmentsWithSurvey/" + patientId);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allAppointmentsWithoutSurvey")]
        public async Task<List<AppointmentDto>> GetAllAppointmentsWithoutSurvey(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/appointmentMicroservice/allAppointmentsWithoutSurvey/" + patientId);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("isSurveyDoneByPatientIdAppointmentDatePhysicianName")]
        public async Task<bool> IsSurveyDoneByPatientIdAppointmentDatePhysicianName([FromQuery] String patientId,
            [FromQuery] String appointmentDate, [FromQuery] String physicianName)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath(
                "/appointmentMicroservice/isSurveyDoneByPatientIdAppointmentDatePhysicianName/" + patientId + "/" +
                appointmentDate + "/" + physicianName);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }

        [HttpPut("update")]
        public async void SetSurveyDoneOnAppointment(AppointmentDto appointmentDto)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var content = new StringContent(JsonConvert.SerializeObject(appointmentDto, Formatting.Indented),
                Encoding.UTF8, "application/json");

            var path = GetFullPath("/appointmentMicroservice/update");
            HttpResponseMessage response = await client.PutAsync(path, content);
            response.EnsureSuccessStatusCode();
        }

        [HttpGet("appointmentsWithReccomendation")]
        public async Task<List<AppointmentWithRecommendationDTO>> GetAllAvailableAppointmentsWithRecommendation(
            string physicianId,
            string specializationName, string dates)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/appointmentMicroservice/appointmentsWithReccomendation/" +
                                   physicianId + "/" + specializationName + "/" + dates);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentWithRecommendationDTO>>(
                await response.Content.ReadAsStringAsync());
        }

        [HttpGet("appointmentsWithPhysicianPriority")]
        public async Task<List<AppointmentWithRecommendationDTO>> GetAllAvailableAppointmentsWithPhysicianPriority(
            string physicianId, string specializationName, string dates)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/appointmentMicroservice/appointmentsWithPhysicianPriority/" + physicianId +
                                   "/" + specializationName + "/" + dates);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentWithRecommendationDTO>>(
                await response.Content.ReadAsStringAsync());
        }

        [HttpPut("cancelAppointment")]
        public async Task<bool> CancelAppointment(AppointmentDto appointment)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var content = new StringContent(JsonConvert.SerializeObject(appointment, Formatting.Indented),
                Encoding.UTF8, "application/json");

            var path = GetFullPath("/appointmentMicroservice/cancelAppointment");
            HttpResponseMessage response =
                await client.PutAsync(path, content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("IsUserMalicious")]
        public async Task<bool> IsUserMalicious(string patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/appointmentMicroservice/IsUserMalicious/" + patientId);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getAllAppointmentsByPatientIdDateAndDoctor")]
        public async Task<List<AppointmentDto>> GetAllAppointmentsByPatientIdDateAndDoctor(
            string patientId, string date, string doctorName)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/appointmentMicroservice/allAppointmentsByPatientIdDateAndDoctor/" +
                                   patientId + "/" + date + "/" + doctorName);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        private string GetFullPath(string path)
        {
            return _appointmentServiceUrl + path;
        }
    }
}