using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/loginMicroservice/login/" + email +"/"+ password );
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            if (responseBody != null)
                return Ok(new { token = responseBody });
            return Unauthorized();
        }
        
        [HttpGet("GetUserType")]
        public async Task<string> GetUserType(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/loginMicroservice/GetUserType");
            response.EnsureSuccessStatusCode();
            var result= await response.Content.ReadAsStringAsync();
            return result;
        }

        [HttpGet("GetUserId")]
        public async Task<string> GetUserId(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57053/loginMicroservice/GetUserId");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}

