using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MicroServiceAccount.Backend.Dto;
using MicroServiceAccount.Backend.Model;
using MicroServiceAppointment.Backend.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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

        // public PatientController(IOptions<MicroServiceUris> options)
        // {
        //     _accountServiceUrl = options.Value.AccountServiceUrl;
        // }

        [HttpGet("all")]
        public async Task<List<Patient>> GetAllPatients()
        {
            var path = GetFullPath("/patientMicroservice/allPatients");
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<Patient>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getPatientById")]
        public async Task<PatientDto> GetPatientById(string patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/patientMicroservice/getPatientById/" + patientId);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<PatientDto>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getMaliciousPatients")]
        public async Task<List<Patient>> GetMaliciousPatients()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/patientMicroservice/getMaliciousPatients");
            HttpResponseMessage response = await client.GetAsync(path);
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

            var path = GetFullPath("/patientMicroservice/blockMaliciousPatient");
            HttpResponseMessage response = await client.PutAsync(path, content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getActionsAndBenefits")]
        public async Task<List<ActionAndBenefitMessage>> GetActionsAndBenefits()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/patientMicroservice/getActionsAndBenefits");
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<ActionAndBenefitMessage>>(
                await response.Content.ReadAsStringAsync());
        }


        [HttpPut("SetUserToMalicious")]
        public async Task<bool> SetUserToMalicious(PatientDto patient)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var content = new StringContent(JsonConvert.SerializeObject(patient, Formatting.Indented), Encoding.UTF8,
                "application/json");

            var path = GetFullPath("/patientMicroservice/SetUserToMalicious");
            HttpResponseMessage response = await client.PutAsync(path, content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }

        private string GetFullPath(string path)
        {
            return _accountServiceUrl + path;
        }
    }
}