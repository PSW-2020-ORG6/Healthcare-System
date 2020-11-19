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
        public IActionResult AddNewSurvey(String survey)
        {
            surveyService.AddNewSurvey(survey);
            return Ok();
        }
    }
}
