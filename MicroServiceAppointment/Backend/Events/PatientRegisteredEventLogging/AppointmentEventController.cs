using MicroServiceAppointment.Backend.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging
{
    [Route("appointmentEvent")]
    [ApiController]
    public class AppointmentEventController: ControllerBase
    {
        private readonly PatientAppointmentEventParams _patientAppointmentEventParams;
        private readonly LogPatientAppointmentEventService _logPatientAppointmentEventService;

        public AppointmentEventController(LogPatientAppointmentEventService logPatientAppointmentEventService)
        {
            _patientAppointmentEventParams = new PatientAppointmentEventParams();
            _logPatientAppointmentEventService = logPatientAppointmentEventService;
        }

        [Authorize]
        [HttpPost("addEvent")]
        public IActionResult MakeAppointment(PatientAppointmentEventParams patientAppointmentEventParams)
        {
           _logPatientAppointmentEventService.LogEvent(patientAppointmentEventParams);
            return Ok();
        }

        [Authorize]
        [HttpGet("all")]
        public EventStatisticDTO GetStatisticResults()
        {
            return _logPatientAppointmentEventService.GetStatisticResults();
        }
        [Authorize]
        [HttpGet("stetisticsForAllSteps")]
        public List<double> GetStetisticsForAllSteps()
        {
            return _logPatientAppointmentEventService.GetStatisticsResultPerSteps();
        }
        [Authorize]
        [HttpGet("stetisticsForDate")]
        public List<double> GetStatisticsResultPerDate()
        {
            return _logPatientAppointmentEventService.GetStatisticsResultPerDate();
        }
      
        [Authorize]
        [HttpGet("stetisticsForSpecialization")]
        public List<double> GetStatisticsResultPerSpecialization()
        {
            return _logPatientAppointmentEventService.GetStatisticsResultPerSpecialization();
        }

        [Authorize]
        [HttpGet("stetisticsForDoctor")]
        public EventStatisticDTO GetStatisticsResultPerDoctor()
        {
            return _logPatientAppointmentEventService.GetStatisticResults();
        }
    }
}
