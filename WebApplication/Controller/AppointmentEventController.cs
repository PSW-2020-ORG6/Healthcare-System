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
using WebApplication.util;

namespace WebApplication.Controller
{
    [Route("event")]
    [ApiController]
    public class AppointmentEventController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string _appointmentServiceUrl;

        public AppointmentEventController(MicroServiceUris uris)
        {
            _appointmentServiceUrl = uris.AppointmentServiceUrl;
        }

        [HttpPost("addEvent")]
        public async Task<IActionResult> GetAllAppointmentsByPatientId(PatientAppointmentEventParams patientAppointmentEventParams)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                    , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter = new StringContent(JsonConvert.SerializeObject(patientAppointmentEventParams, Formatting.Indented), Encoding.UTF8, "application/json");
            var path = GetFullPath("/appointmentEvent/addEvent/");
            HttpResponseMessage response = await client.PostAsync(path, parameter);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IActionResult>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("eventStatistic")]
        public async Task<EventStatisticDTO> GetAllEvents()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                     , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var path = GetFullPath("/appointmentEvent/all/");
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<EventStatisticDTO > (await response.Content.ReadAsStringAsync());
        }
        private string GetFullPath(string path)
        {
            return _appointmentServiceUrl + path;
        }
    }
}
