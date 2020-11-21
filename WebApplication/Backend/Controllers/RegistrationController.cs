using Backend.Dto;
using Microsoft.AspNetCore.Mvc;
using Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Backend.Services;

namespace WebApplication.Backend.Controllers
{
    [Route("registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public RegistrationService registrationService;

        public RegistrationController()
        {
            registrationService = new RegistrationService();
        }

        [HttpPost("registerPatient")]
        public void RegisterPatient(Patient patientDTO)
        {
            registrationService.RegisterPatient(patientDTO);
        }
    }
}
