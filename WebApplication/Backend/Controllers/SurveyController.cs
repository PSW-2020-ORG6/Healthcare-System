﻿using health_clinic_class_diagram.Backend.Model.Survey;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return surveyService.GetAllDoctorsFromReporstByPatientId(patientId);
        }

        [HttpGet("getStatistiEachQuestion")]
        public List<StatisticAuxilaryClass> getStatisticsEachQuestion()
        {
            return surveyService.getStatisticsEachQuestion();
        }

        [HttpGet("getStatistiEachTopic")]
        public List<StatisticAuxilaryClass> getStatisticsEachTopic()
        {
            return surveyService.getStatisticsEachTopic();

        }

        [HttpGet("getStatisticForDoctor")]
        public List<StatisticAuxilaryClass> getStatisticsForDoctor(string ID)
        {
            return surveyService.getStatisticsForDoctor(ID);

        }
    }
}
