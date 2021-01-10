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
        public async Task<string> GetUserType()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                    , Request.Headers["Authorization"].ToString().Split(" ")[1]); HttpResponseMessage response = await client.GetAsync("http://localhost:57053/loginMicroservice/GetUserType");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();

        }

        [HttpGet("GetUserId")]
        public async Task<string> GetUserId()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                    , Request.Headers["Authorization"].ToString().Split(" ")[1]); HttpResponseMessage response = await client.GetAsync("http://localhost:57053/loginMicroservice/GetUserId");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

