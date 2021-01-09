using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MicroServiceAccount.Backend.Model;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using HealthClinicBackend.Backend.Dto;

namespace MicroServiceAccount.Backend.Controllers
{
    [Route("registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpPost("registerPatient")]
        public async Task<IActionResult> RegisterPatient(PatientDto patientDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(patientDTO, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:57053/registrationMicroservice/registerPatient",content);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IActionResult>(responseBody);
        }

        [HttpPut("confirmationEmail/{id}")]
        public async Task<IActionResult> Confirmation(string id)
        {
            var content = new StringContent(JsonConvert.SerializeObject(id, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("http://localhost:57053/registrationMicroservice/confirmationEmail", content);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IActionResult>(responseBody);
        }

        [HttpGet("allPhysitians")]
        public async Task<List<FamilyDoctorDto>> GetAllPhysicians()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/registrationMicroservice/allPhysitians");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<FamilyDoctorDto>>(result);
        }
    }
}