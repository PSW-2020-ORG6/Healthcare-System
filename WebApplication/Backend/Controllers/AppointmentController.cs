﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using WebApplication.Backend.Services;
using HealthClinicBackend.Backend.Dto;

namespace WebApplication.Backend.Controllers
{
    [Route("appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentsService appointmentsService;

        public AppointmentController()
        {
            this.appointmentsService = new AppointmentsService();
        }

        [HttpGet("allAppointmentsByPatientId")]
        public List<Appointment> GellAllAppointmentsByPatientId(String patientId)
        {
            return appointmentsService.GetAllAppointmentsByPatientId(patientId);
        }

        [HttpGet("allAppointments")]
        public List<Appointment> GellAllAppointments()
        {
            return appointmentsService.GetAllAppointments();
        }


        [HttpGet("allAppointmentsByPatientIdActive")]
        public List<Appointment> GellAllAppointmentsByPatientIdActive(String patientId)
        {
            List<Appointment> apointments = appointmentsService.GetAllAppointmentsByPatientIdActive(patientId);
            return apointments;
        }


        [HttpGet("allAppointmentsByPatientIdCanceled")]
        public List<Appointment> GellAllAppointmentsByPatientIdCanceled(String patientId)
        {
            return appointmentsService.GetAllAppointmentsByPatientIdCanceled(patientId);
        }

        [HttpPut("cancelAppointment")]
        public bool CancelAppointment(AppointmentDto appointment)
        {
            return appointmentsService.CancelAppointment(appointment.SerialNumber);
        }

        [HttpGet("checkIfMalicious")]
        public bool CheckIfUserIsMaliciousment(string patientId)
        {
            return appointmentsService.CheckIfUserIsMalicious(patientId);
        }

        [HttpPut("setToMalicious")]
        public bool CheckIfUserIsMaliciousment(AppointmentDto appointment)
        {
            return appointmentsService.CheckIfUserIsMalicious(appointment.Patient.Id);
        }
    }
}
