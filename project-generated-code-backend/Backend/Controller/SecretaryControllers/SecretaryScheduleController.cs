// File:    SecretaryScheduleContoller.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SecretaryScheduleController

using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Service.SchedulingService;
using HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies;
using System;
using System.Collections.Generic;

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

        public void NewAppointment(AppointmentDto appointmentDto)
        {
            _appointmentService.NewAppointment(appointmentDto);
        }

        public List<AppointmentDto> GetAllAvailableAppointments(AppointmentDto appointmentDto)
        {
            return _appointmentSchedulingService.GetAvailableAppointments(appointmentDto);
        }

        public List<AppointmentDto> GetAllAvailableAppointmentsGEA(AppointmentDto appointmentDto, int priority)
        {
            return _appointmentSchedulingService.GetAvailableAppointmentsGEA(appointmentDto, priority);
        }

        public AppointmentDto GetEmergencyAppointmentGEA(AppointmentDto appointmentDto)
        {
            return _appointmentSchedulingService.GetEmergencyAppointmentGEA(appointmentDto);
        }

        public Dictionary<Appointment, AppointmentDto> AppointmentAnasysisGEA(AppointmentDto appointmentDto)
        {
            return _appointmentSchedulingService.ApointmentAnalysisGEA(appointmentDto);
        }

        public AppointmentDto GetRecommendedAppointment(AppointmentDto appointmentDto)
        {
            throw new NotImplementedException();
        }
    }
}