using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using WebApplication.Backend.Services;
using WebApplication.Backend.DTO;
using HealthClinicBackend.Backend.Model.Util;

namespace WebApplication.Backend.Controllers
{
    [Route("appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService appointmentService;
        private readonly DateTimeDTO dateTimeDTO;
        public AppointmentController()
        {
            this.appointmentService = new AppointmentService();
            this.dateTimeDTO = new DateTimeDTO();
        }

        [HttpGet("allAppointmentsByPatientId")]
        public List<Appointment> GellAllAppointmentsByPatientId(String patientId)
        {
            return appointmentService.GetAllAppointmentsByPatientId(patientId);
        }

        [HttpGet("physicians")]
        public List<PhysicianDTO> GetAllPhysitians()
        {
            return appointmentService.GetAllPhysicians();
        }
        [HttpGet("specializations")]
        public List<SpecializationDTO> GetAllSpecializations()
        {
            return appointmentService.GetAllSpecializations();
        }
        [HttpGet("allAppointments")]
        public List<Appointment> GellAllAppointments()
        {
            return appointmentService.GetAllAppointments();
        }

        //[HttpGet("allAppointmentsByPatientIdActive")]
        public List<Appointment> GellAllAppointmentsByPatientIdActive(String patientId)
        {
            List<Appointment> apointments = appointmentService.GetAllAppointmentsByPatientIdActive(patientId);
            return apointments;
        }

        [HttpGet("allAppointmentsByPatientIdCanceled")]
        public List<Appointment> GellAllAppointmentsByPatientIdCanceled(String patientId)
        {
            return appointmentService.GetAllAppointmentsByPatientIdCanceled(patientId);
        }

        [HttpGet("appointments")]
        public List<TimeIntervalDTO> GetAllAvailableAppointments(string physicianId, string specializationName, string date)
        {
            if (dateTimeDTO.IsPreferredTimeValid(date))
                return appointmentService.GetAllAvailableAppointments(physicianId, specializationName, date);
            else
                return null;
        }

        //[HttpPost("makeAppointment/{physicianId}/{timeIntervalId}/{date}")]
        //public IActionResult MakeAppointment(string physicianId, string timeIntervalId, string date)
        //{
        //    if (physicianId != null && timeIntervalId != null && date != null)
        //    {
        //        if (appointmentService.AddAppointment(new Appointment(new AppointmentDTO(physicianId, date, timeIntervalId))))
        //            return Ok();
        //        else
        //            return BadRequest();
        //    }
        //    else
        //        return BadRequest();
        //}
    }
}
