using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using MicroServiceAccount.Backend.Service;
using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Dto;

namespace MicroServiceAccount.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("patientMicroservice")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;
        private readonly PhysicianService _physicianService;

        public PatientController(PatientService patientService,PhysicianService physicianService)
        {
            _patientService = patientService;
            _physicianService = physicianService;
        }

        /// <summary>
        ///calls method for get all patients from patients table
        ///</summary>
        ///<returns>
        ///list of patients
        ///</returns>

        [Authorize]
        [HttpGet("allPatients")]
        public List<Patient> GetAllPatients()
        {
            return _patientService.GetAllPatients();
        }

        [Authorize]
        [HttpGet("getPatientById/{patientId}")]
        public PatientDto GetPatientById(string patientId)
        {
            return _patientService.GetPatientById(patientId);
        }

        [Authorize]
        [HttpGet("getMaliciousPatients")]
        public List<Patient> GetMaliciousPatients()
        {
            return _patientService.GetMaliciousPatients();
        }

        [Authorize]
        [HttpPut("blockMaliciousPatient")]
        public bool BlockMaliciousPatient(PatientDto patient)
        {
            return _patientService.BlockMaliciousPatient(patient.Id);
        }

        [Authorize]
        [HttpGet("getActionsAndBenefits")]
        public List<ActionAndBenefitMessage> GetActionsAndBenefits()
        {
            return _patientService.GetAdvertisements();
        }

        [Authorize]
        [HttpPut("SetUserToMalicious")]
        public bool SetUserToMalicious([FromBody]string patientId)
        {
            return _patientService.SetMalicousPatientById(patientId);
        }
    }
}