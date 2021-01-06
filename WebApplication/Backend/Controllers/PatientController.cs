﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using WebApplication.Backend.Services;
using HealthClinicBackend.Backend.Dto;
using System;
using HealthClinicBackend.Backend.Model.PharmacySupport;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///calls method for get all patients from patients table
        ///</summary>
        ///<returns>
        ///list of patients
        ///</returns>
      
        [Authorize]
        [HttpGet("all")]
        public List<Patient> GetAllFeedbacks()
        {
            return _patientService.GetAllPatients();
        }

        ///Aleksa Repović RA52/2017
        /// <summary>
        ///Get patient from patients table by ID
        ///</summary>
        ///<returns>
        ///single instance of Patient object
        ///</returns
        [Authorize]
        [HttpGet("getPatientById")]
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
        public IEnumerable<ActionAndBenefitMessage> GetActionsAndBenefits()
        {
            return _patientService.GetAdvertisements();
        }
    }
}