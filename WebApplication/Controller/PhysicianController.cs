using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MicroServiceAccount.Backend.Dto;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebApplication.Backend.Controller
{
    [Route("account")]
    [ApiController]
    public class PhysicianController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpGet("allPhysicians")]
        public async Task<List<PhysicianDTO>> GetAllPhysicians()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/physicianMicroservice/allPhysicians");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<PhysicianDTO>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getPhysicianById")]
        public async Task<PhysicianDTO> GetPhysicianById(string physicianId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/physicianMicroservice/getPhysicianById/" + physicianId);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<PhysicianDTO>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("allSpecializations")]
        public async Task<List<SpecializationDTO>> GetAllSpecializations()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/physicianMicroservice/allSpecializations");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<SpecializationDTO>>(await response.Content.ReadAsStringAsync());
        }
    }
}
