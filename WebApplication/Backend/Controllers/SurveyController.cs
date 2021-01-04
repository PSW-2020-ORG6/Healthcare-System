using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Survey;
using WebApplication.Backend.Services;
using WebApplication.Backend.Util;

namespace WebApplication.Backend.Controllers
{
    [Route("survey")]
    [ApiController]
    public class SurveyController : ControllerBase
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
        public List<String> GetAllDoctorsFromReporstByPatientId(String patientId)
        {
            return surveyService.GetAllDoctorsFromReportsByPatientId(patientId);
        }
        [HttpGet("getDoctorsFromSurvey")]
        public List<String> GetAllDoctorsFromReporstByPatientIdForSurvey(String patientId)
        {
            return surveyService.GetAllDoctorsFromReportsByPatientIdFromSurvey(patientId);
        }
        [HttpGet("getDoctorsForSurveyList")]
        public List<String> GetAllDoctorsFromReporstByPatientIdForSurveyList(String patientId)
        {
            return surveyService.GetAllDoctorsFromReportsByPatientIdForSurveyList(patientId);
        }

        [HttpGet("getStatistiEachQuestion")]
        public List<StatisticAuxilaryClass> getStatisticsEachQuestion()
        {
            return surveyService.GetStatisticsEachQuestion();
        }

        [HttpGet("getStatistiEachTopic")]
        public List<StatisticAuxilaryClass> getStatisticsEachTopic()
        {
            return surveyService.GetStatisticsEachTopic();

        }

        [HttpGet("getStatisticForDoctor")]
        public List<StatisticAuxilaryClass> getStatisticsForDoctor(string ID)
        {
            return surveyService.GetStatisticsForDoctor(ID);

        }
    }
}
