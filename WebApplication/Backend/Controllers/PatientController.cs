using System;
using Microsoft.AspNetCore.Mvc;
using Model.Accounts;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using WebApplication.Backend.Services;

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
        [HttpGet("getPatientById")]
        public Patient GetPatientById(string patientId)
        {
            Console.WriteLine($"Patient id: {patientId}");
            var result = _patientService.GetPatientById(patientId);
            Console.WriteLine(result);
            return result;
        }
    }
}