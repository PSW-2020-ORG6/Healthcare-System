using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.util;

namespace WebApplication.Controller
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string _feedBackServiceUrl;

        public FeedbackController(MicroServiceUris uris)
        {
            _feedBackServiceUrl = uris.FeedbackServiceUrl;
        }

        [HttpGet("approved")]
        public async Task<List<FeedbackDto>> GetApprovedFeedbacks(string token)
        {
            var uri = GetFullUriForPath("/feedbackMicroservice/approved/");
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<FeedbackDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("disapproved")]
        public async Task<List<FeedbackDto>> GetDissaporvedFeedbacks()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var uri = GetFullUriForPath("/feedbackMicroservice/disapproved/");
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<FeedbackDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpPut("approve")]
        public async Task<List<FeedbackDto>> ChangeStatusFeedback(FeedbackDto feedbackDTO)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter = new StringContent(JsonConvert.SerializeObject(feedbackDTO, Formatting.Indented),
                Encoding.UTF8, "application/json");

            var uri = GetFullUriForPath("/feedbackMicroservice/approve/");
            HttpResponseMessage response = await client.PutAsync(uri, parameter);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<FeedbackDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpPost("add")]
        public async Task<List<FeedbackDto>> AddNewFeedbacк(FeedbackDto feedbackDTO)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            var parameter = new StringContent(JsonConvert.SerializeObject(feedbackDTO, Formatting.Indented),
                Encoding.UTF8, "application/json");

            var uri = GetFullUriForPath("/feedbackMicroservice/add/");
            HttpResponseMessage response = await client.PostAsync(uri, parameter);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<FeedbackDto>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("all")]
        public async Task<List<FeedbackDto>> GetAllFeedbacks()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var uri = GetFullUriForPath("/feedbackMicroservice/all/");
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<FeedbackDto>>(await response.Content.ReadAsStringAsync());
        }

        private Uri GetFullUriForPath(string path)
        {
            return new Uri(_feedBackServiceUrl + path);
        }
    }
}