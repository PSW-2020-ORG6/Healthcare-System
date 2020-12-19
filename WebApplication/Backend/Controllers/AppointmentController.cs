using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using WebApplication.Backend.Services;

namespace WebApplication.Backend.Controllers
{
    [Route("appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentsService _appointmentsService;

        public AppointmentController(AppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        [HttpGet("allAppointmentsByPatientId")]
        public List<Appointment> GellAllAppointmentsByPatientId(String patientId)
        {
            return _appointmentsService.GetAllAppointmentsByPatientId(patientId);
        }

        [HttpGet("allAppointments")]
        public List<Appointment> GellAllAppointments()
        {
            return _appointmentsService.GetAllAppointments();
        }


        [HttpGet("allAppointmentsByPatientIdActive")]
        public List<Appointment> GellAllAppointmentsByPatientIdActive(String patientId)
        {
            List<Appointment> apointments = _appointmentsService.GetAllAppointmentsByPatientIdActive(patientId);
            return apointments;
        }


        [HttpGet("allAppointmentsByPatientIdCanceled")]
        public List<Appointment> GellAllAppointmentsByPatientIdCanceled(String patientId)
        {
            return _appointmentsService.GetAllAppointmentsByPatientIdCanceled(patientId);
        }
    }
}