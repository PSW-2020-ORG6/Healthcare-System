using System;
using System.Threading.Tasks;
using Backend.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Accounts;
using WebApplication.Backend.Services;

namespace WebApplication.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("api")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///calls method for sendinf mail
        ///</summary>
        ///<param name="patientDTO"> PatientDTO type object
        ///</param>>
        [HttpPost("send")]
        public async Task<IActionResult> SendMail(PatientDTO patientDTO)
        {
            try
            {
                await mailService.SendEmailAsync(new Patient(patientDTO));
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
