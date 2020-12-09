// File:    FollowUpAppointmentSchedulingController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class FollowUpAppointmentSchedulingController

using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Service.SchedulingService;
using HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class FollowUpAppointmentSchedulingController
    {
        private readonly AppointmentSchedulingService _appointmentSchedulingService;

        public FollowUpAppointmentSchedulingController()
        {
            _appointmentSchedulingService =
                new AppointmentSchedulingService(new PhysicianFollowUpSchedulingStrategy());
        }

        public AppointmentDto GetRecommendedAppointment(AppointmentDto appointmentDto)
        {
            return _appointmentSchedulingService.FindNearestAppointment(appointmentDto);
        }
    }
}