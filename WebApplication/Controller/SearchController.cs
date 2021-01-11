using MicroServiceSearch.Backend.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebApplication.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("search")]
    [ApiController]
    public class UserController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpGet("prescriptionsSearch")]
        public async Task<List<SearchEntityDTO>> GetAllPrescription(string prescriptionSearch, string dateFrom, string dateTo)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                           , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57060/searchMicroservices/prescriptionsSearch/"
                                                                + prescriptionSearch+"/"+dateFrom+"/"+dateTo);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<SearchEntityDTO>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("reportsSearch")]
        public async Task<List<SearchEntityDTO>> GetAllReports(string reportSearch, string dateFrom, string dateTo)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                            , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            HttpResponseMessage response = await client.GetAsync("http://localhost:57060/searchMicroservices/reportsSearch/"
                                                                + reportSearch + "/" + dateFrom + "/" + dateTo);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<SearchEntityDTO>>(await response.Content.ReadAsStringAsync());
        }
    }
}