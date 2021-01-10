using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using HealthClinicBackend.Backend.Dto;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        static readonly HttpClient client = new HttpClient();

        [HttpGet("approved")]
        public async Task<List<FeedbackDto>> GetApprovedFeedbacks(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        ,Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57057/feedbackMicroservice/approved/");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<FeedbackDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("disapproved")]
        public async Task<List<FeedbackDto>> GetDissaporvedFeedbacks()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        ,Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57057/feedbackMicroservice/disapproved/");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<FeedbackDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpPut("approve")]
        public async Task<List<FeedbackDto>> ApproveFeedback(FeedbackDto feedbackDTO)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        ,Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter = new StringContent(JsonConvert.SerializeObject(feedbackDTO,Formatting.Indented),Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PutAsync("http://localhost:57057/feedbackMicroservice/approve/", parameter);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<FeedbackDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpPost("add")]
        public async Task<List<FeedbackDto>> AddNewFeedbacк(FeedbackDto feedbackDTO)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        ,Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter = new StringContent(JsonConvert.SerializeObject(feedbackDTO, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:57057/feedbackMicroservice/add/", parameter) ;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<FeedbackDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("all")]
        public async Task<List<FeedbackDto>> GetAllFeedbacks()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                        ,Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57057/feedbackMicroservice/all/");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<FeedbackDto>>(await response.Content.ReadAsStringAsync());
        }

    }
}