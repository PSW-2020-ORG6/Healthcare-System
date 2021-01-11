using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using MicroServiceAppointment.Backend.Dto;
using MicroServiceAccount.Backend.Dto;

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

        [HttpGet("avaliableTimeIntervals")]
        public async Task<List<TimeIntervalDTO>> GetAllAvailableAppointments(string physicianId, string specializationName,
            string date)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/avaliableTimeIntervals/" + physicianId + "/" + specializationName + "/" + date);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<TimeIntervalDTO>>(await response.Content.ReadAsStringAsync());
        }

        [HttpPost("makeAppointment")]
        public async Task<IActionResult> MakeAppointment(AppointmentDto appointmentSchedulingDTO)
        {   /*
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter1 = new StringContent(JsonConvert.SerializeObject(appointmentSchedulingDTO, Formatting.Indented), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("http://localhost:57057/feedbackMicroservice/add/",parameter1);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IActionResult>(await response.Content.ReadAsStringAsync());
            */
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
        public async Task<List<AppointmentDto>> GetAllAppointmentsWithDoneSurvey(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                   , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/allAppointmentsWithSurvey/" + patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allAppointmentsWithoutSurvey")]
        public async Task<List<AppointmentDto>> GetAllAppointmentsWithoutSurvey(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                   , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/allAppointmentsWithoutSurvey/" + patientId);
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
        [HttpPut("update")]
        public async void SetSurveyDoneOnAppointment(AppointmentDto appointmentDto)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                  , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var content = new StringContent(JsonConvert.SerializeObject(appointmentDto, Formatting.Indented), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("http://localhost:57056/appointmentMicroservice/update", content);
            response.EnsureSuccessStatusCode();
        }
        //radi
        [HttpGet("appointmentsWithReccomendation")]
        public async Task<List<AppointmentWithRecommendationDTO>>  GetAllAvailableAppointmentsWithRecommendation(string physicianId,
            string specializationName, string dates)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                              , Request.Headers["Authorization"].ToString().Split(" ")[1]); 
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/appointmentsWithReccomendation/" + physicianId +"/" + specializationName + "/" + dates);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentWithRecommendationDTO>>(await response.Content.ReadAsStringAsync());
        }
        //radi
        [HttpGet("appointmentsWithPhysicianPriority")]
        public async Task<List<AppointmentWithRecommendationDTO>> GetAllAvailableAppointmentsWithPhysicianPriority(
            string physicianId, string specializationName, string dates)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                               , Request.Headers["Authorization"].ToString().Split(" ")[1]); 
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentMicroservice/appointmentsWithPhysicianPriority/" + physicianId + "/" + specializationName + "/" + dates);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<AppointmentWithRecommendationDTO>>(await response.Content.ReadAsStringAsync());

        }

        [HttpPut("cancelAppointment")]
        public async Task<bool> CancelAppointment(AppointmentDto appointment)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                              , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var content = new StringContent(JsonConvert.SerializeObject(appointment, Formatting.Indented), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("http://localhost:57056/appointmentMicroservice/cancelAppointment", content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());

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
