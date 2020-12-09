// File:    SecretaryScheduleContoller.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SecretaryScheduleController

using System;
using System.Collections.Generic;
using Backend.Dto;
using HealthClinicBackend.Backend.Service.SchedulingService;
using HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies;
using Model.Schedule;

namespace HealthClinicBackend.Backend.Controller.SecretaryControllers
{
    public class SecretaryScheduleController
    {

        private readonly AppointmentService _appointmentService;
        private readonly AppointmentSchedulingService _appointmentSchedulingService;

        public SecretaryScheduleController()
        {
            _appointmentSchedulingService = new AppointmentSchedulingService(new SecretarySchedulingStrategy());
            _appointmentService = new AppointmentService();
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

        public List<AppointmentDTO> GetAllAvailableAppointments(AppointmentDTO appointmentDto)
        {
            return _appointmentSchedulingService.GetAvailableAppointments(appointmentDto);
        }

        public AppointmentDTO GetRecommendedAppointment(AppointmentDTO appointmentDto)
        {
            throw new NotImplementedException();
        }
    }
}