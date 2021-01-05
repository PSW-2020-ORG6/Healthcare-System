// File:    PhysitianScheduleController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianScheduleController

using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Service.SchedulingService;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class PhysicianScheduleController
    {
        private readonly PhysicianScheduleService _physicianScheduleService;

        public PhysicianScheduleController(PhysicianScheduleService physicianScheduleService)
        {
            _physicianScheduleService = physicianScheduleService;
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return _physicianScheduleService.GetAppointmentsByDate(date);
        }

        public void NewAppointment(AppointmentDto appointment)
        {
            _physicianScheduleService.NewAppointment(appointment);
        }
    }
}