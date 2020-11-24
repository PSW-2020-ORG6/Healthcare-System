using health_clinic_class_diagram.Backend.Model.Survey;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Backend.Services;

namespace WebApplication.Backend.Controllers
{
    [Route("survey")]
    [ApiController]
    public class SurveyController: ControllerBase
    {
       
        private readonly SurveyService surveyService;
        public SurveyController()
        {
            this.surveyService = new SurveyService();
        }

        [HttpPost("add")]
        public IActionResult AddNewSurvey(Survey surveyText)
        {
            surveyService.AddNewSurvey(surveyText);
            return Ok();
        }
        [HttpGet("getDoctors")]
        public List<String>GetAllDoctorsFromReporstByPatientId(String patientId)
        {
           return surveyService.GetAllDoctorsFromReporstByPatientId(patientId);
 
        }

        [HttpGet("getStatisticsForDoctor")]
        public List<double> getStatistics(string doctorId)
        {
            return surveyService.getStatistics(doctorId);

        }
    }
}
