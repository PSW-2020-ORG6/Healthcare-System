using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MicroServiceAccount.Backend.Dto;
using MicroServiceAccount.Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.util;

namespace WebApplication.Controller
{
    [Route("patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string _accountServiceUrl;

        public PatientController(MicroServiceUris uris)
        {
            _accountServiceUrl = uris.AccountServiceUrl;
        }

        [HttpGet("all")]
        public async Task<List<Patient>> GetAllPatients()
        {
            var uri = GetFullUriForPath("/patientMicroservice/allPatients");
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<Patient>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getPatientById")]
        public async Task<PatientDto> GetPatientById(string patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var uri = GetFullUriForPath("/patientMicroservice/getPatientById/" + patientId);
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<PatientDto>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getMaliciousPatients")]
        public async Task<List<Patient>> GetMaliciousPatients()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var uri = GetFullUriForPath("/patientMicroservice/getMaliciousPatients");
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<Patient>>(await response.Content.ReadAsStringAsync());
        }

        [HttpPut("blockMaliciousPatient")]
        public async Task<bool> BlockMaliciousPatient(PatientDto patient)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var content = new StringContent(JsonConvert.SerializeObject(patient, Formatting.Indented), Encoding.UTF8,
                "application/json");

            var uri = GetFullUriForPath("/patientMicroservice/blockMaliciousPatient");
            HttpResponseMessage response = await client.PutAsync(uri, content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getActionsAndBenefits")]
        public async Task<List<ActionAndBenefitMessage>> GetActionsAndBenefits()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var uri = GetFullUriForPath("/patientMicroservice/getActionsAndBenefits");
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<ActionAndBenefitMessage>>(
                await response.Content.ReadAsStringAsync());
        }


        [HttpPut("SetUserToMalicious")]
        public async Task<bool> SetUserToMalicious(string patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var content = new StringContent(JsonConvert.SerializeObject(patientId, Formatting.Indented), Encoding.UTF8,
                "application/json");

            var uri = GetFullUriForPath("/patientMicroservice/SetUserToMalicious");
            HttpResponseMessage response = await client.PutAsync(uri, content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }

        private Uri GetFullUriForPath(string path)
        {
            return new Uri(_accountServiceUrl + path);
        }
    }
}