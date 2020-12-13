﻿using Microsoft.AspNetCore.Mvc;
using Model.Accounts;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using WebApplication.Backend.Services;
using HealthClinicBackend.Backend.Dto;

namespace WebApplication.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService patientService;
        public PatientController()
        {
            this.patientService = new PatientService();
        }
        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///calls method for get all patients from patients table
        ///</summary>
        ///<returns>
        ///list of patients
        ///</returns>
        [HttpGet("all")]
        public List<Patient> GetAllFeedbacks()
        {
            return patientService.GetAllPatients();
        }

        ///Aleksa Repović RA52/2017
        /// <summary>
        ///Get patient from patients table by ID
        ///</summary>
        ///<returns>
        ///single instance of Patient object
        ///</returns
        [HttpGet("getPatientById")]
        public Patient GetPatientById(string patientId)
        {
            return patientService.GetPatientById(patientId);
        }

        [HttpGet("getMaliciousPatients")]
        public List<Patient> GetMaliciousPatients()
        {
            return patientService.GetMaliciousPatients();
        }

        [HttpPut("blockMaliciousPatient")]
        public bool BlockMaliciousPatient(PatientDto patient)
        {
            return patientService.BlockMaliciousPatient(patient.Id);
        }

    }
}
