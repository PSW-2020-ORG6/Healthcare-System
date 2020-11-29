using Backend.Dto;
using Microsoft.AspNetCore.Mvc;
using Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Backend.Model;
using WebApplication.Backend.Services;

namespace WebApplication.Backend.Controllers
{
    [Route("registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public RegistrationService registrationService;
        private IMailService mailService;

        public RegistrationController(IMailService mailService)
        {
            registrationService = new RegistrationService();
            this.mailService = mailService;
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
                    mailService.SendEmailAsync(new Patient(patientDTO));
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
            string siatientId = ParseId(id);
            
            if (registrationService.ConfirmgEmailUpdate(siatientId))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///id decryption 
        ///</summary>
        ///<returns>
        ///patient id
        ///</returns>
        ///<param name="patientId"> String type object
        ///</param>>
        private string ParseId(string patientId)
        {
            int id = (int.Parse(patientId) - 23 * 33) + 6789;
            return id.ToString();
        }
    }
}
