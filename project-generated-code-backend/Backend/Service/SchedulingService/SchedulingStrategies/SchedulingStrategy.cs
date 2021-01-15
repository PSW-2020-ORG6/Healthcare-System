// File:    SchedulingStrategy.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface SchedulingStrategy

using HealthClinicBackend.Backend.Dto;

namespace HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies
{
    public interface SchedulingStrategy
    {
        AppointmentDto PrepareAppointment(AppointmentDto appointment);

    }
}