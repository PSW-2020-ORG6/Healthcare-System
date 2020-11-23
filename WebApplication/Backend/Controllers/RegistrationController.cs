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
        public IActionResult RegisterPatient(PatientDTO patientDTO)
        {
            if (patientDTO.IsCorrectName() && patientDTO.IsCorrectSurname() && patientDTO.IsCorrectParentName() && patientDTO.IsCorrectId() &&
                patientDTO.IsCorrectDateOfBirth() && patientDTO.IsCorrectPlaceOfBirth() && patientDTO.IsCorrectMunicipalityOfBirth() &&
                patientDTO.IsCorrectStateOfBirth() && patientDTO.IsCorrectNationality() && patientDTO.IsCorrectCitizenship() && patientDTO.IsCorrectAddress() &&
                patientDTO.IsCorrectPlaceOfResidence() && patientDTO.IsCorrectMunicipalityOfResidence() && patientDTO.IsCorrectStateOfResidence() &&
                patientDTO.IsCorrectProfession() && patientDTO.IsCorrectEmploymentStatus() && patientDTO.IsCorrectMaritalStatus() && patientDTO.IsCorrectContact() &&
                patientDTO.IsCorrectEmail() && patientDTO.IsCorrectPassword() && patientDTO.IsCorrectGender() && patientDTO.IsCorrectHealthInsuranceNumber()) {
                if (registrationService.RegisterPatient(new Patient(patientDTO)))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
