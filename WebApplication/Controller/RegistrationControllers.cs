﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.util;

namespace WebApplication.Controller
{
    [Route("registration")]
    [ApiController]
    public class RegistrationControllers : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string _accountServiceUrl;

        public RegistrationControllers(MicroServiceUris uris)
        {
            _accountServiceUrl = uris.AccountServiceUrl;
        }

        [HttpPost("registerPatient")]
        public async Task<IActionResult> RegisterPatient(PatientDto patientDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(patientDTO, Formatting.Indented), Encoding.UTF8,
                "application/json");

            var uri = GetFullUriForPath("/registrationMicroservice/registerPatient");
            HttpResponseMessage response = await client.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IActionResult>(await response.Content.ReadAsStringAsync());
        }

        [HttpPut("confirmationEmail/{id}")]
        public async Task<IActionResult> Confirmation(string id)
        {
            var content = new StringContent(JsonConvert.SerializeObject(id, Formatting.Indented), Encoding.UTF8,
                "application/json");

            var uri = GetFullUriForPath("/registrationMicroservice/confirmationEmail");
            HttpResponseMessage response = await client.PutAsync(uri, content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IActionResult>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allPhysitians")]
        public async Task<List<FamilyDoctorDto>> GetAllPhysicians()
        {
            var uri = GetFullUriForPath("/registrationMicroservice/allPhysitians");
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<FamilyDoctorDto>>(await response.Content.ReadAsStringAsync());
        }

        private Uri GetFullUriForPath(string path)
        {
            return new Uri(_accountServiceUrl + path);
        }
    }
}