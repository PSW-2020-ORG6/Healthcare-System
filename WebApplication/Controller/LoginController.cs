using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplication.util;

namespace WebApplication.Controller
{
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string _accountServiceUrl;

        public LoginController(MicroServiceUris uris)
        {
            _accountServiceUrl = uris.AccountServiceUrl;
        }

        // public LoginController(IOptions<MicroServiceUris> options)
        // {
        //     _accountServiceUrl = options.Value.AccountServiceUrl;
        // }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var path = GetFullPath("/loginMicroservice/login/" + email + "/" + password);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            if (responseBody != null)
                return Ok(new {token = responseBody});
            return Unauthorized();
        }

        [HttpGet("GetUserType")]
        public async Task<string> GetUserType()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/loginMicroservice/GetUserType");
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        [HttpGet("GetUserId")]
        public async Task<string> GetUserId()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/loginMicroservice/GetUserId");
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private string GetFullPath(string path)
        {
            return _accountServiceUrl + path;
        }
    }
}