using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using MicroServiceAppointment.Backend.Util;
using MicroServiceAppointment.Backend.Model.Survey;
using MicroServiceAppointment.Backend.Dto;

namespace WebApplication.Backend.Controllers
{
    [Route("survey")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpPost("add")]
        public async Task<IActionResult> AddNewSurvey(SurveyDto surveyText)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                           , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter = new StringContent(JsonConvert.SerializeObject(surveyText, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:57056/surveyMicroservice/add/", parameter);
            response.EnsureSuccessStatusCode();
            return Ok();
        }

        [HttpGet("getDoctors")]
        public async Task<List<String>> GetAllDoctorsFromReportsByPatientId(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                   , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/surveyMicroservice/getDoctors/" + patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<String>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getDoctorsFromSurvey")]
        public async Task<List<String>> GetAllDoctorsFromReportsByPatientIdForSurvey(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                    , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/surveyMicroservice/getDoctorsFromSurvey/" + patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<String>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getDoctorsForSurveyList")]
        public async Task<List<String>> GetAllDoctorsFromReportsByPatientIdForSurveyList(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                     , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/surveyMicroservice/getDoctorsForSurveyList/" + patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<String>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getStatistiEachQuestion")]
        public async Task<List<StatisticAuxilaryClass>> GetStatisticsEachQuestion()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/surveyMicroservice/getStatistiEachQuestion");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<StatisticAuxilaryClass>>(await response.Content.ReadAsStringAsync());
        }
        [HttpGet("getStatistiEachTopic")]
        public async Task<List<StatisticAuxilaryClass>> GetStatisticsEachTopic()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/surveyMicroservice/getStatistiEachTopic");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<StatisticAuxilaryClass>>(await response.Content.ReadAsStringAsync());
        }
        [HttpGet("getStatisticForDoctor")]
        public async Task<List<StatisticAuxilaryClass>> GetStatisticsForDoctor(string id)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/surveyMicroservice/getStatisticForDoctor/" + id);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<StatisticAuxilaryClass>>(await response.Content.ReadAsStringAsync());

        }
    }
}
