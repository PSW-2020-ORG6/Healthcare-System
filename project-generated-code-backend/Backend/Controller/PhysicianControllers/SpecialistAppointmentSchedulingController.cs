// File:    SpecialistAppointmentSchedulingController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SpecialistAppointmentSchedulingController

using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Service.SchedulingService;
using HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class SpecialistAppointmentSchedulingController
    {
        private AppointmentSchedulingService appointmentSchedulingService;

        public SpecialistAppointmentSchedulingController()
        {
            this.appointmentSchedulingService = new AppointmentSchedulingService(new PhysicianSpecialistSchedulingStrategy());
        }

        public List<AppointmentDto> GetAllAvailableAppointments(AppointmentDto appointmentDTO)
        {
            return appointmentSchedulingService.GetAvailableAppointments(appointmentDTO);
        }

    }
}