using MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using MicroServiceAppointment.Backend.Dto;

namespace WebApplication.Controller
{
    [Route("event")]
    [ApiController]
    public class AppointmentEventController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpPost("addEvent")]
        public async Task<IActionResult> GetAllAppointmentsByPatientId(PatientAppointmentEventParams patientAppointmentEventParams)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                    , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter = new StringContent(JsonConvert.SerializeObject(patientAppointmentEventParams, Formatting.Indented), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("http://localhost:57056/appointmentEvent/addEvent/", parameter);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IActionResult>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allEvents")]
        public async Task<EventStatisticDTO> GetAllEvents()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                     , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentEvent/all");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<EventStatisticDTO > (await response.Content.ReadAsStringAsync());
        }
        //[HttpGet("stetisticsForAllSteps")]
        //public async Task<List<double>> GetStetisticsForAllSteps()
        //{
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
        //                                                                                             , Request.Headers["Authorization"].ToString().Split(" ")[1]);
        //    HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentEvent/stetisticsForAllSteps");
        //    response.EnsureSuccessStatusCode();
        //    return JsonConvert.DeserializeObject<List<double>>(await response.Content.ReadAsStringAsync());
        //}
        //[HttpGet("stetisticsForDate")]
        //public async Task<List<double>> GetStetisticsForDate()
        //{
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
        //                                                                                             , Request.Headers["Authorization"].ToString().Split(" ")[1]);
        //    HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentEvent/stetisticsForDate");
        //    response.EnsureSuccessStatusCode();
        //    return JsonConvert.DeserializeObject<List<double>>(await response.Content.ReadAsStringAsync());
        //}
        //[HttpGet("stetisticsForSpecialization")]
        //public async Task<List<double>> GetStetisticsForSpecialization()
        //{
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
        //                                                                                             , Request.Headers["Authorization"].ToString().Split(" ")[1]);
        //    HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentEvent/stetisticsForSpecialization");
        //    response.EnsureSuccessStatusCode();
        //    return JsonConvert.DeserializeObject<List<double>>(await response.Content.ReadAsStringAsync());
        //}
        //[HttpGet("stetisticsForDoctor")]
        //public async Task<List<double>> GetStetisticsForDoctor()
        //{
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
        //                                                                                             , Request.Headers["Authorization"].ToString().Split(" ")[1]);
        //    HttpResponseMessage response = await client.GetAsync("http://localhost:57056/appointmentEvent/stetisticsForDoctor");
        //    response.EnsureSuccessStatusCode();
        //    return JsonConvert.DeserializeObject<List<double>>(await response.Content.ReadAsStringAsync());
        //}
    }
}
