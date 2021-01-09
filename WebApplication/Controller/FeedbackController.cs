using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using HealthClinicBackend.Backend.Dto;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using System.Linq;
using Org.BouncyCastle.Asn1.Ocsp;

namespace WebApplication.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("feedbackMicroservice")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        static readonly HttpClient client = new HttpClient();


        [HttpGet("approved")]
        public async Task<List<FeedbackDto>> GetApprovedFeedbacks(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0], Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57057/feedback/approved/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<FeedbackDto> returnValue = JsonConvert.DeserializeObject<List<FeedbackDto>>(responseBody);

            return returnValue;
        }

        [HttpGet("disapproved")]
        public async Task<List<FeedbackDto>> GetDissaporvedFeedbacks()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0], Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57057/feedback/disapproved/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<FeedbackDto> returnValue = JsonConvert.DeserializeObject<List<FeedbackDto>>(responseBody);

            return returnValue;
        }

        [HttpPut("approve")]
        public async Task<List<FeedbackDto>> ApproveFeedback(FeedbackDto feedbackDTO)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0], Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter = new StringContent(JsonConvert.SerializeObject(feedbackDTO,Formatting.Indented),Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PutAsync("http://localhost:57057/feedback/approve/",parameter);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<FeedbackDto> returnValue = JsonConvert.DeserializeObject<List<FeedbackDto>>(responseBody);

            return returnValue;
        }

        [HttpPost("add")]
        public async Task<List<FeedbackDto>> AddNewFeedbacк(FeedbackDto feedbackDTO)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0], Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter = new StringContent(JsonConvert.SerializeObject(feedbackDTO, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:57057/feedback/add/",parameter) ;
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<FeedbackDto> returnValue = JsonConvert.DeserializeObject<List<FeedbackDto>>(responseBody);

            return returnValue;
        }

        [HttpGet("all")]
        public async Task<List<FeedbackDto>> GetAllFeedbacks()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0], Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57057/feedback/all/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<FeedbackDto> returnValue = JsonConvert.DeserializeObject<List<FeedbackDto>>(responseBody);

            return returnValue;
        }

    }
}