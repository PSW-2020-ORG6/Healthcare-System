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
        public List<PatientAppointmentEventDto> GetAllAppointments()
        {
            return _logPatientAppointmentEventService.GetAllAppointments();
        }
    }
}
