// File:    PatientScheduleController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientScheduleController

using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Service.SchedulingService;
using HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.PatientControllers
{
    public class PatientScheduleController
    {
        private readonly AppointmentService _appointmentService;
        private readonly AppointmentSchedulingService _appointmentSchedulingService;

        public PatientScheduleController(AppointmentSchedulingService appointmentSchedulingService,
            AppointmentService appointmentService)
        {
            _appointmentSchedulingService = appointmentSchedulingService;
            _appointmentSchedulingService.SchedulingStrategyContext = new PatientSchedulingStrategy();
            _appointmentService = appointmentService;
        }

        public void EditAppointment(Appointment appointment)
        {
            _appointmentService.EditAppointment(appointment);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            _appointmentService.DeleteAppointment(appointment);
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return _appointmentService.GetAppointmentsByDate(date);
        }

        public void NewAppointment(AppointmentDTO appointmentDto)
        {
            _appointmentService.NewAppointment(appointmentDto);
        }

        public AppointmentDTO GetSuggestedAppointment(String physitiansId,
            List<DateTime> dates, int prior)
        {
            throw new NotImplementedException();
        }

        public List<AppointmentDTO> GetAllAvailableAppointments(AppointmentDTO appointmentDto)
        {
            return _appointmentSchedulingService.GetAvailableAppointments(appointmentDto);
        }
    }
}