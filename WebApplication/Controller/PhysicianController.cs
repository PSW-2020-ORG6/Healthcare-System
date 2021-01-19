using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MicroServiceAccount.Backend.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApplication.util;

namespace WebApplication.Controller
{
    [Route("account")]
    [ApiController]
    public class PhysicianController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string _accountServiceUrl;

        public PhysicianController(MicroServiceUris uris)
        {
            _accountServiceUrl = uris.AccountServiceUrl;
        }

        // public PhysicianController(IOptions<MicroServiceUris> options)
        // {
        //     _accountServiceUrl = options.Value.AccountServiceUrl;
        // }

        [HttpGet("allPhysicians")]
        public async Task<List<PhysicianDTO>> GetAllPhysicians()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/physicianMicroservice/allPhysicians");
            HttpResponseMessage response =
                await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<PhysicianDTO>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getPhysicianById")]
        public async Task<PhysicianDTO> GetPhysicianById(string physicianId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/physicianMicroservice/getPhysicianById/" + physicianId);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<PhysicianDTO>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allSpecializations")]
        public async Task<List<SpecializationDTO>> GetAllSpecializations()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0],
                Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/physicianMicroservice/allSpecializations");
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<SpecializationDTO>>(await response.Content.ReadAsStringAsync());
        }

        private string GetFullPath(string path)
        {
            return _accountServiceUrl + path;
        }
    }
}