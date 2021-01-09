using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using HealthClinicBackend.Backend.Model.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace MicroServiceAccount.Backend.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/login/login/" +email+"/"+ password );
             response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            IActionResult iarr = Ok(new { token = responseBody });

            return iarr;
        }
        
        [Authorize]
        [HttpGet("GetUserType")]
        public async Task<string> GetUserType()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/login/GetUserType");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        [Authorize]
        [HttpGet("GetUserId")]
        public async Task<string> GetUserId()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/login/GetUserId");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}

