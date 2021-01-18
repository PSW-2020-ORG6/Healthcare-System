using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MicroServiceAppointment.Backend.Dto;
using MicroServiceAppointment.Backend.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.util;

namespace WebApplication.Controller
{
    [Route("survey")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string _appointmentServiceUrl;

        public SurveyController(MicroServiceUris uris)
        {
            _appointmentServiceUrl = uris.AppointmentServiceUrl;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewSurvey(SurveyDto surveyText)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter = new StringContent(JsonConvert.SerializeObject(surveyText, Formatting.Indented),
                Encoding.UTF8, "application/json");

            var uri = GetFullUriForPath("/surveyMicroservice/add/");
            HttpResponseMessage response = await client.PostAsync(uri, parameter);
            response.EnsureSuccessStatusCode();
            return Ok();
        }

        [HttpGet("getDoctors")]
        public async Task<List<String>> GetAllDoctorsFromReportsByPatientId(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var uri = GetFullUriForPath("/surveyMicroservice/getDoctors/" + patientId);
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<String>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getDoctorsFromSurvey")]
        public async Task<List<String>> GetAllDoctorsFromReportsByPatientIdForSurvey(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var uri = GetFullUriForPath("/surveyMicroservice/getDoctorsFromSurvey/" + patientId);
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<String>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getDoctorsForSurveyList")]
        public async Task<List<String>> GetAllDoctorsFromReportsByPatientIdForSurveyList(String patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var uri = GetFullUriForPath("/surveyMicroservice/getDoctorsForSurveyList/" + patientId);
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<String>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getStatistiEachQuestion")]
        public async Task<List<StatisticAuxilaryClass>> GetStatisticsEachQuestion()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var uri = GetFullUriForPath("/surveyMicroservice/getStatistiEachQuestion");
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<StatisticAuxilaryClass>>(
                await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getStatistiEachTopic")]
        public async Task<List<StatisticAuxilaryClass>> GetStatisticsEachTopic()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var uri = GetFullUriForPath("/surveyMicroservice/getStatistiEachTopi");
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<StatisticAuxilaryClass>>(
                await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getStatisticForDoctor")]
        public async Task<List<StatisticAuxilaryClass>> GetStatisticsForDoctor(string id)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var uri = GetFullUriForPath("/surveyMicroservice/getStatisticForDoctor/" + id);
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<StatisticAuxilaryClass>>(
                await response.Content.ReadAsStringAsync());
        }

        private Uri GetFullUriForPath(string path)
        {
            return new Uri(_appointmentServiceUrl + path);
        }
    }
}