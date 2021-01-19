using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MicroServiceSearch.Backend.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApplication.util;

namespace WebApplication.Controller
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string _searchServiceUrl;

        public SearchController(MicroServiceUris uris)
        {
            _searchServiceUrl = uris.SearchServiceUrl;
        }

        // public SearchController(IOptions<MicroServiceUris> options)
        // {
        //     _searchServiceUrl = options.Value.SearchServiceUrl;
        // }

        [HttpGet("prescriptionsSearch")]
        public async Task<List<SearchEntityDTO>> GetAllPrescription(string prescriptionSearch, string dateFrom,
            string dateTo)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/searchMicroservices/prescriptionsSearch/" + prescriptionSearch + "/" +
                                   dateFrom + "/" + dateTo);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<SearchEntityDTO>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("reportsSearch")]
        public async Task<List<SearchEntityDTO>> GetAllReports(string reportSearch, string dateFrom, string dateTo)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/searchMicroservices/reportsSearch/" + reportSearch + "/" + dateFrom + "/" +
                                   dateTo);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<SearchEntityDTO>>(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("getReportByAppointment")]
        public async Task<List<string>> GetReportByAppointment(string date, string patientSerialNumber,
            string physicianSerialNumber)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                Request.Headers["Authorization"].ToString().Split(" ")[0]
                , Request.Headers["Authorization"].ToString().Split(" ")[1]);

            var path = GetFullPath("/searchMicroservices/getReportByAppointment/" + date + "/" +
                                   patientSerialNumber + "/" + physicianSerialNumber);
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
        }

        private string GetFullPath(string path)
        {
            return _searchServiceUrl + path;
        }
    }
}