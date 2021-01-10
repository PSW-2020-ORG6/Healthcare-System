using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MicroServiceAccount.Backend.Service;
using Microsoft.AspNetCore.Authorization;
using MicroServiceAccount.Backend.Services.Interfaces;
using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Dto;

namespace MicroServiceAccount.Backend.Controllers
{
    [Route("registrationMicroservice")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationService _registrationService;
        private readonly IMailService _mailService;

        public RegistrationController(RegistrationService registrationService, IMailService mailService)
        {
            _registrationService = registrationService;
            _mailService = mailService;
        }

        /// <summary>
        ///calls method for adding new patient in patient table
        ///</summary>
        ///<returns>
        ///information about sucess in string format
        ///</returns>
        [HttpPost("registerPatient")]
        public IActionResult RegisterPatient(PatientDto patientDTO)
        {
            if (patientDTO.AreRegistrationFieldsValid())
            {
                if (_registrationService.RegisterPatient(new Patient(patientDTO)))
                {
                    SendMail(new Patient(patientDTO));
                    return Ok();
                }
            }           
            return BadRequest();
        }

        public void SendMail(Patient patient)
        {
            _mailService.SendEmail(patient);
        }
        /// <summary>
        ///calls method for updating field emailConfirmed in patient table
        ///</summary>
        ///<returns>
        ///information about sucess in IActionResult format
        ///</returns>
        [Authorize]
        [HttpPut("confirmationEmail/{id}")]
        public IActionResult Confirmation(string id)
        {
            string patientId = IdDecryption(id);
            if (_registrationService.ConfirmEmailUpdate(patientId))
                return Ok();
            else
                return BadRequest();
        }
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
            return ((long.Parse(patientId) - 23 * 33) + 6789).ToString();
        }

        [HttpGet("allPhysitians")]
        public List<FamilyDoctorDto> GetAllPhysicians()
        {
            return _registrationService.GetAllPhysicians();
        }
    }
}