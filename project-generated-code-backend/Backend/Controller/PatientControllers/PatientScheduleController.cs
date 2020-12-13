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
        public PatientScheduleController()
        {
            appointmentSchedulingService = new AppointmentSchedulingService(new PatientSchedulingStrategy());
            appointmentService = new AppointmentService();
        }

        public void EditAppointment(Appointment appointment)
        {
            appointmentService.EditAppointment(appointment);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            appointmentService.DeleteAppointment(appointment);
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return appointmentService.GetAppointmentsByDate(date);
        }

        public void NewAppointment(global::HealthClinicBackend.Backend.Dto.AppointmentDto appointmentDto)
        {
            appointmentService.NewAppointment(appointmentDto);
        }

        public global::HealthClinicBackend.Backend.Dto.AppointmentDto GetSuggestedAppointment(String physitiansId, List<DateTime> dates, int prior)
        {
            throw new NotImplementedException();
        }
        
        public AppointmentDto MakeAppointment(AppointmentDto appointmentDto, int priority)
        {
            List<AppointmentDto> appointments = GetAllAvailableAppointments(appointmentDto);
            if(appointments != null)
            {
                return appointments[0];
            }
            return null;
        }

        public List<AppointmentDto> GetAllAvailableAppointments(AppointmentDto appointmentDto)
        {
            return appointmentSchedulingService.GetAvailableAppointments(appointmentDto);
        }

        public AppointmentService appointmentService;
        public AppointmentSchedulingService appointmentSchedulingService;
    }
}