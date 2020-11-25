using Microsoft.AspNetCore.Mvc;
using Model.Accounts;
using System.Collections.Generic;
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
    }
}
