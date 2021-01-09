using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using HealthClinicBackend.Backend.Model.PharmacySupport;
using HealthClinicBackend.Backend.Model.Accounts;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Dto;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace MicroServiceAccount.Backend.Controllers
{
    [Route("patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpGet("all")]
        public async Task<List<Patient>> GetAllPatients(String token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/patientMicroservice/allPatients");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Patient>>(result);
        }

        [HttpGet("getPatientById")]
        public async Task<PatientDto> GetPatientById(string patientId,string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/patientMicroservice/getPatientById/" + patientId);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PatientDto>(result);
        }

        [HttpGet("getMaliciousPatients")]
        public async Task<List<Patient>> GetMaliciousPatients(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/patientMicroservice/getMaliciousPatients");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Patient>>(result);
        }

        [HttpPut("blockMaliciousPatient")]
        public async Task<bool> BlockMaliciousPatient(PatientDto patient,String token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(JsonConvert.SerializeObject(patient, Formatting.Indented),Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PutAsync("http://localhost:57053/patientMicroservice/blockMaliciousPatient" ,content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<bool>(result);
        }

        [HttpGet("getActionsAndBenefits")]
        public async Task<List<ActionAndBenefitMessage>> GetActionsAndBenefits(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/patientMicroservice/getActionsAndBenefits");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ActionAndBenefitMessage>>(result);
        }
    }
}