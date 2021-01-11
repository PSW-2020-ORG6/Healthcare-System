// File:    SpecialistAppointmentSchedulingController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SpecialistAppointmentSchedulingController

using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Service.SchedulingService;
using HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class SpecialistAppointmentSchedulingController
    {
        private readonly AppointmentSchedulingService _appointmentSchedulingService;

        public SpecialistAppointmentSchedulingController(AppointmentSchedulingService appointmentSchedulingService)
        {
            _appointmentSchedulingService = appointmentSchedulingService;
            _appointmentSchedulingService.SchedulingStrategyContext = new PhysicianSpecialistSchedulingStrategy();
        }

        public List<AppointmentDTO> GetAllAvailableAppointments(AppointmentDTO appointmentDTO)
        {
            return _appointmentSchedulingService.GetAvailableAppointments(appointmentDTO);
        }
    }
}