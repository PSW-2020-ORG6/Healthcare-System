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

        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///calls method for adding new patient in patient table
        ///</summary>
        ///<returns>
        ///information about sucess in string format
        ///</returns>
        [HttpPost("registerPatient")]
        public IActionResult RegisterPatient(PatientDTO patientDTO)
        {
            if (patientDTO.IsCorectRegistrationFields())
            {
                if (registrationService.RegisterPatient(new Patient(patientDTO)))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("confirmationEmail/{id}")]
        public IActionResult Confirmation(string id)
        {
            if (registrationService.ConfirmgEmailUpdate(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
