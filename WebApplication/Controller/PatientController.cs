using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
//using HealthClinicBackend.Backend.Model.PharmacySupport;
//using HealthClinicBackend.Backend.Model.Accounts;
using System.Threading.Tasks;
//using HealthClinicBackend.Backend.Dto;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using MicroServiceAccount.Backend.Dto;
using MicroServiceAccount.Backend.Model;

namespace MicroServiceAccount.Backend.Controllers
{
    [Route("patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpGet("all")]
        public async Task<List<Patient>> GetAllPatients()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/patientMicroservice/allPatients");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<Patient>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getPatientById")]
        public async Task<PatientDto> GetPatientById(string patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/patientMicroservice/getPatientById/" + patientId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<PatientDto>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getMaliciousPatients")]
        public async Task<List<Patient>> GetMaliciousPatients()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/patientMicroservice/getMaliciousPatients");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<Patient>>(await response.Content.ReadAsStringAsync());
        }

        [HttpPut("blockMaliciousPatient")]
        public async Task<bool> BlockMaliciousPatient(PatientDto patient)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var content = new StringContent(JsonConvert.SerializeObject(patient, Formatting.Indented),Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PutAsync("http://localhost:57053/patientMicroservice/blockMaliciousPatient" ,content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getActionsAndBenefits")]
        public async Task<List<ActionAndBenefitMessage>> GetActionsAndBenefits()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/patientMicroservice/getActionsAndBenefits");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<ActionAndBenefitMessage>>(await response.Content.ReadAsStringAsync());
        }


        [HttpPut("SetUserToMalicious")]
        public async Task<bool> SetUserToMalicious(string patientId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                                  , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var content = new StringContent(JsonConvert.SerializeObject(patientId, Formatting.Indented), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("http://localhost:57053/patientMicroservice/SetUserToMalicious", content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }
    }
}