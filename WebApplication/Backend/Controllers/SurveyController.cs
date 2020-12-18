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

        private readonly SurveyService _surveyService;
        public SurveyController()
        {
            this._surveyService = new SurveyService();
        }

        [HttpPost("add")]
        public IActionResult AddNewSurvey(Survey surveyText)
        {
            _surveyService.AddNewSurvey(surveyText);
            return Ok();
        }
        [HttpGet("getDoctors")]
        public List<String> GetAllDoctorsFromReporstByPatientId(String patientId)
        {
            return _surveyService.GetAllDoctorsFromReporstByPatientId(patientId);
        }
        [HttpGet("getDoctorsFromSurvey")]
        public List<String> GetAllDoctorsFromReporstByPatientIdForSurvey(String patientId)
        {
            return _surveyService.GetAllDoctorsFromReporstByPatientIdFromSurvey(patientId);
        }
        [HttpGet("getDoctorsForSurveyList")]
        public List<String> GetAllDoctorsFromReporstByPatientIdForSurveyList(String patientId)
        {
            return _surveyService.GetAllDoctorsFromReporstByPatientIdForSurveyList(patientId);
        }

        [HttpGet("getStatistiEachQuestion")]
        public List<StatisticAuxilaryClass> GetStatisticsEachQuestion()
        {
            return _surveyService.getStatisticsEachQuestion();
        }

        [HttpGet("getStatistiEachTopic")]
        public List<StatisticAuxilaryClass> GetStatisticsEachTopic()
        {
            return _surveyService.getStatisticsEachTopic();

        }

        [HttpGet("getStatisticForDoctor")]
        public List<StatisticAuxilaryClass> GetStatisticsForDoctor(string ID)
        {
            return _surveyService.getStatisticsForDoctor(ID);

        }
    }
}
