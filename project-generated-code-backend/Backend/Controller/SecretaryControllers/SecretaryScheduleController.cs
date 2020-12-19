// File:    SecretaryScheduleContoller.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SecretaryScheduleController

using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Service.SchedulingService;
using HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies;

namespace HealthClinicBackend.Backend.Controller.SecretaryControllers
{
    public class SecretaryScheduleController
    {
        private readonly AppointmentService _appointmentService;
        private readonly AppointmentSchedulingService _appointmentSchedulingService;

        public SecretaryScheduleController(AppointmentSchedulingService appointmentSchedulingService,
            AppointmentService appointmentService)
        {
            _appointmentSchedulingService = appointmentSchedulingService;
            _appointmentSchedulingService.SchedulingStrategyContext = new SecretarySchedulingStrategy();
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

        public void NewAppointment(AppointmentDto appointmentDto)
        {
            _appointmentService.NewAppointment(appointmentDto);
        }

        public List<AppointmentDto> GetAllAvailableAppointments(AppointmentDto appointmentDto)
        {
            return _appointmentSchedulingService.GetAvailableAppointments(appointmentDto);
        }

        public AppointmentDto GetRecommendedAppointment(AppointmentDto appointmentDto)
        {
            throw new NotImplementedException();
        }
    }
}