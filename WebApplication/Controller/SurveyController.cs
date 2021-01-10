using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using HealthClinicBackend.Backend.Model.Survey;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using MicroServiceAppointment.Backend.Util;

namespace MicroServiceAppointment.Backend.Controllers
{
    [Route("survey")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpPost("add")]
        public async Task<IActionResult> AddNewSurvey(Survey surveyText)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                           , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter = new StringContent(JsonConvert.SerializeObject(surveyText, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:57057/survey/add/", parameter);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IActionResult>(await response.Content.ReadAsStringAsync());
        }

        [Authorize]
        [HttpGet("getDoctors")]
        public List<String> GetAllDoctorsFromReportsByPatientId(String patientId)
        {
            throw new NotImplementedException();
        }
        //[Authorize]
        //[HttpGet("getDoctorsFromSurvey")]
        //public List<String> GetAllDoctorsFromReportsByPatientIdForSurvey(String patientId)
        //{
        //    throw new NotImplementedException();
        //}

        //[Authorize]
        //[HttpGet("getDoctorsForSurveyList")]
        //public List<String> GetAllDoctorsFromReportsByPatientIdForSurveyList(String patientId)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpGet("getStatistiEachQuestion")]
        public async Task<List<StatisticAuxilaryClass>> GetStatisticsEachQuestion()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/survey/getStatistiEachQuestion");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<StatisticAuxilaryClass>>(await response.Content.ReadAsStringAsync());
        }
        [HttpGet("getStatistiEachTopic")]
        public async Task<List<StatisticAuxilaryClass>> GetStatisticsEachTopic()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/survey/getStatistiEachTopic");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<StatisticAuxilaryClass>>(await response.Content.ReadAsStringAsync());
        }
        [HttpGet("getStatisticForDoctor")]
        public async Task<List<StatisticAuxilaryClass>> GetStatisticsForDoctor(string id)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57056/survey/getStatisticForDoctor/" + id);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<StatisticAuxilaryClass>>(await response.Content.ReadAsStringAsync());

        }
    }
}
