using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyRegistration.Models;
using PharmacyRegistration.Services;
using Microsoft.AspNetCore.Mvc;

namespace PharmacyRegistration.Controllers
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
