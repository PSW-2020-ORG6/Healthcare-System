using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAdapters.Models;
using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ApiService apiService;

        public ApiController()
        {
            this.apiService = new ApiService();
        }

        [HttpPost("registration")]
        public IActionResult RegisterHospitalOnPharmacy(Api api)
        {
            if (apiService.RegisterHospitalOnPharmacy(api)) return Ok(); else return BadRequest();
        }

    }
}
