using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using WebApplication.Backend.Services;
using HealthClinicBackend.Backend.Dto;
using WebApplication.Backend.DTO;

namespace WebApplication.Backend.Controllers
{
    [Route("appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService appointmentService;
        private readonly DateFromStringConverter dateFromStringConverter;
        private readonly AppointmentDto appointmentDTO;
        public AppointmentController()
        {
            this.appointmentService = new AppointmentService();
            this.dateFromStringConverter = new DateFromStringConverter();
            this.appointmentDTO = new AppointmentDto();
        }

        [HttpGet("allAppointmentsByPatientId")]
        public List<AppointmentDTO> GellAllAppointmentsByPatientId(String patientId)
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
        public List<AppointmentDTO> GellAllAppointments()
        {
            return appointmentService.GetAllAppointments();
        }

        [HttpGet("allAppointmentsByPatientIdActive")]
        public List<AppointmentDTO> GellAllAppointmentsByPatientIdActive(String patientId)
        {
            return appointmentService.GetAllAppointmentsByPatientIdActive(patientId);
        }

        [HttpGet("allAppointmentsByPatientIdCanceled")]
        public List<AppointmentDTO> GellAllAppointmentsByPatientIdCanceled(String patientId)
        {
            return appointmentService.GetAllAppointmentsByPatientIdCanceled(patientId);
        }

        [HttpGet("appointments")]
        public List<TimeIntervalDTO> GetAllAvailableAppointments(string physicianId, string specializationName, string date)
        {
            if (dateFromStringConverter.IsPreferredTimeValid(date))
                return appointmentService.GetAllAvailableAppointments(physicianId, specializationName, date);
            else
                return null;
        }

        [HttpPost("makeAppointment/{physicianId}/{timeIntervalStart}/{date}")]
        public IActionResult MakeAppointment(string physicianId, DateTime timeIntervalStart, string date)
        {
            if (physicianId != null && timeIntervalStart != null && appointmentDTO.IsDataValid(date))
            {
                if (appointmentService.AddAppointment(new Appointment(physicianId, date, timeIntervalStart)))
                    return Ok();
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [HttpGet("allAppointmentsByPatientIdPast")]
        public List<AppointmentDTO> GellAllAppointmentsByPatientIdPast(String patientId)
        {
            return appointmentService.GetAllAppointmentsByPatientIdPast(patientId);
        }


        [HttpGet("allAppointmentsWithSurvey")]
        public List<AppointmentDTO> GetAllAppointmentsWithDoneSurvey()
        {
            AppointmentDTO appointment = new AppointmentDTO();
            return appointment.ConvertListToAppointmentDTO(appointmentService.GetAllAppointmentsWithDoneSurvey());
        }

        [HttpGet("allAppointmentsWithoutSurvey")]
        public List<AppointmentDTO> allAppointmentsWithoutSurvey()
        {
            return appointmentService.GetAllAppointmentsWithoutDoneSurvey();
        }

        [HttpGet("isSurveyDoneByPatientIdAppointmentDatePhysicianName")]
        public bool isSurveyDoneByPatientIdAppointmentDatePhysicianName([FromQuery] String patientId, [FromQuery] String appointmentDate, [FromQuery] String physicianName)
        {
            return appointmentService.isSurveyDoneByPatientIdAppointmentDatePhysicianName(patientId, appointmentDate, physicianName);
        }

        [HttpPut("setSurveyDoneOnAppointment")]
        public void setSurveyDoneOnAppointment(AppointmentDTO appointmentDto)
        {
            appointmentService.setSurveyDoneOnAppointment(appointmentDto);
        }

        [HttpGet("appointmentsWithReccomendation")]
        public List<AppointmentWithRecommendationDTO> GetAllAvailableAppointmentsWithRecomendation(string physicianId, string specializationName, string dates)
        {
            if (dateFromStringConverter.IsPreferredTimeIntervalValid(dates))
                return appointmentService.AppointmentRecomendation(physicianId, specializationName, dateFromStringConverter.DateGeneration(dates));
            else
                return null;
        }

        [HttpGet("appointmentsWithPhysicianPriority")]
        public List<AppointmentWithRecommendationDTO> GetAllAvailableAppointmentsWithPhysicianPriority(string physicianId, string specializationName, string dates)
        {
            if (dateFromStringConverter.IsPreferredTimeIntervalValid(dates))
                return appointmentService.AppointmentRecomendationWithPhysicianPriority(physicianId, specializationName, dateFromStringConverter.DateGeneration(dates));
            else
                return null;
        }

        [HttpPut("cancelAppointment")]
        public bool CancelAppointment(AppointmentDTO appointment)
        {
            return appointmentService.CancelAppointment(appointment.SerialNumber);
        }

        [HttpGet("IsUserMalicious")]
        public bool IsUserMalicious(string patientId)
        {
            return appointmentService.IsUserMalicious(patientId);
        }

        [HttpPut("SetUserToMalicious")]
        public bool SetUserToMalicious(AppointmentDTO appointment)
        {
            return appointmentService.SetUserToMalicious(appointment.PatientDTO.Id);
        }
    }
}
