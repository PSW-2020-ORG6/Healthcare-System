//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Authorization;
//using MicroServiceAppointment.Backend.Util;
//using MicroServiceAppointment.Backend.Service;
//using MicroServiceAppointment.Backend.Model.Survey;

//namespace MicroServiceAppointment.Backend.Controllers
//{
//    [Route("survey")]
//    [ApiController]
//    public class SurveyController : ControllerBase
//    {
//        private readonly SurveyService _surveyService;

//        public SurveyController(SurveyService surveyService)
//        {
//            _surveyService = surveyService;
//        }
//        [Authorize]
//        [HttpPost("add")]
//        public IActionResult AddNewSurvey(Survey surveyText)
//        {
//            _surveyService.AddNewSurvey(surveyText);
//            return Ok();
//        }

//        [Authorize]
//        [HttpGet("getDoctors")]
//        public List<String> GetAllDoctorsFromReportsByPatientId(String patientId)
//        {
//            return _surveyService.GetAllDoctorsFromReportsByPatientId(patientId);
//        }
//        [Authorize]
//        [HttpGet("getDoctorsFromSurvey")]
//        public List<String> GetAllDoctorsFromReportsByPatientIdForSurvey(String patientId)
//        {
//            return _surveyService.GetAllDoctorsFromReportsByPatientIdFromSurvey(patientId);
//        }

//        [Authorize]
//        [HttpGet("getDoctorsForSurveyList")]
//        public List<String> GetAllDoctorsFromReportsByPatientIdForSurveyList(String patientId)
//        {
//            return _surveyService.GetAllDoctorsFromReportsByPatientIdForSurveyList(patientId);
//        }
//        [Authorize]
//        [HttpGet("getStatistiEachQuestion")]
//        public List<StatisticAuxilaryClass> GetStatisticsEachQuestion()
//        {
//            return _surveyService.GetStatisticsEachQuestion();
//        }
//        [Authorize]
//        [HttpGet("getStatistiEachTopic")]
//        public List<StatisticAuxilaryClass> GetStatisticsEachTopic()
//        {
//            return _surveyService.GetStatisticsEachTopic();
//        }
//        [Authorize]
//        [HttpGet("getStatisticForDoctor")]
//        public List<StatisticAuxilaryClass> GetStatisticsForDoctor(string id)
//        {
//            return _surveyService.GetStatisticsForDoctor(id);
//        }
//    }
//}