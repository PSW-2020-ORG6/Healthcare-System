// File:    PhysitianScheduleController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianScheduleController

using System;
using System.Collections.Generic;
using Backend.Dto;
using HealthClinicBackend.Backend.Service.SchedulingService;
using Model.Accounts;
using Model.Schedule;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class PhysicianScheduleController
    {
        private Physician _loggedPhysician;
        private PhysicianScheduleService _physicianScheduleService;

        public PhysicianScheduleController(Physician loggedPhysician)
        {
            _loggedPhysician = loggedPhysician;
            _physicianScheduleService = new PhysicianScheduleService(loggedPhysician);
        }
        
        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return _physicianScheduleService.GetAppointmentsByDate(date);
        }
        
        public void NewAppointment(AppointmentDTO appointment)
        {
            _physicianScheduleService.NewAppointment(appointment);
        }
    }
}