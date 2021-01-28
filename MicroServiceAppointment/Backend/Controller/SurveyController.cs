using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using MicroServiceAppointment.Backend.Util;
using MicroServiceAppointment.Backend.Service;
using MicroServiceAppointment.Backend.Model.Survey;
using System.Net.Http.Headers;

namespace MicroServiceAppointment.Backend.Controllers
{
    [Route("surveyMicroservice")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly SurveyService _surveyService;

        public SurveyController(SurveyService surveyService)
        {
            _surveyService = surveyService;
        }
        [Authorize]
        [HttpPost("add")]
        public IActionResult AddNewSurvey(Survey surveyText)
        {
            _surveyService.AddNewSurvey(surveyText);
            return Ok();
        }

        [Authorize]
        [HttpGet("getDoctorsForSurveyList/{patientId}")]
        public List<String> GetAllDoctorsFromReportsByPatientIdForSurveyList(String patientId)
        {
            HttpRequest.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Request.Headers["Authorization"].ToString().Split(" ")[0]
                                                                                                         , Request.Headers["Authorization"].ToString().Split(" ")[1]);
            return _surveyService.GetAllDoctorsFromReportsByPatientIdForSurveyList(patientId);
        }

        [Authorize]
        [HttpGet("getStatisticEachQuestion")]
        public List<StatisticAuxilaryClass> GetStatisticsEachQuestion()
        {
            return _surveyService.GetStatisticsEachQuestion();
        }

        [Authorize]
        [HttpGet("getStatisticEachTopic")]
        public List<StatisticAuxilaryClass> GetStatisticsEachTopic()
        {
            return _surveyService.GetStatisticsEachTopic();
        }

        [Authorize]
        [HttpGet("getStatisticForDoctor")]
        public List<StatisticAuxilaryClass> GetStatisticsForDoctor(string id)
        {
            return _surveyService.GetStatisticsForDoctor(id);
        }
    }
}