using Backend.Dto;
using Microsoft.AspNetCore.Mvc;
using Model.Accounts;
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
            if (patientDTO.AreRegistrationFieldsValid())
            {
                if (registrationService.RegisterPatient(new Patient(patientDTO)))
                {
                    SendMail(new Patient(patientDTO));
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

        public void SendMail(Patient patient)
        {
            mailService.SendEmail(patient);
        }

        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///calls method for updating field emailConfirmed in patient table
        ///</summary>
        ///<returns>
        ///information about sucess in IActionResult format
        ///</returns>
        [HttpPut("confirmationEmail/{id}")]
        public IActionResult Confirmation(string id)
        {
            string patientId = IdDecryption(id);

            if (registrationService.ConfirmEmailUpdate(patientId))
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
        private string IdDecryption(string patientId)
        {
            long id = (long.Parse(patientId) - 23 * 33) + 6789;
            return id.ToString();
        }
    }
}
