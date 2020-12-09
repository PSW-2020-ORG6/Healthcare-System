// File:    PatientScheduleController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientScheduleController

using System;
using System.Collections.Generic;
using Backend.Dto;
using HealthClinicBackend.Backend.Service.SchedulingService;
using HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies;
using Model.Schedule;

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

        public void NewAppointment(global::Backend.Dto.AppointmentDTO appointmentDto)
        {
            appointmentService.NewAppointment(appointmentDto);
        }

        public global::Backend.Dto.AppointmentDTO GetSuggestedAppointment(String physitiansId, List<DateTime> dates, int prior)
        {
            throw new NotImplementedException();
        }

        public List<AppointmentDTO> GetAllAvailableAppointments(AppointmentDTO appointmentDto)
        {
            return appointmentSchedulingService.GetAvailableAppointments(appointmentDto);
        }

        public AppointmentService appointmentService;
        public AppointmentSchedulingService appointmentSchedulingService;
    }
}