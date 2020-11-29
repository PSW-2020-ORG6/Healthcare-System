using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Accounts;
using WebApplication.Backend.Model;
using WebApplication.Backend.Services;

namespace WebApplication.Backend.Controllers
{
    [Route("api")]///[controller]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        private readonly UserManager<IdentityUser> userManager;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail(/*[FromForm] MailRequest request*/PatientDTO patientDTO)
        {

            //MailRequest request = new MailRequest();
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

        /*[HttpPost("welcome")]
        public async Task<IActionResult> SendWelcomeMail([FromForm] WelcomeRequest request)
        {
            try
            {
                await mailService.SendWelcomeEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }*/
    }
}
