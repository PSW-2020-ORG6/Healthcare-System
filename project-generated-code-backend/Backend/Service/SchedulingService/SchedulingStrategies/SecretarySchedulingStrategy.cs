// File:    SecretarySchedulingStrategy.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SecretarySchedulingStrategy

using HealthClinicBackend.Backend.Dto;

namespace HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies
{
    public class SecretarySchedulingStrategy : SchedulingStrategy
    {
        private const int DISALLOW_SCHEDULING_HOURS = 0;
        public AppointmentDto PrepareAppointment(AppointmentDto appointment)
        {
            appointment.RestrictedHours = DISALLOW_SCHEDULING_HOURS;
            return appointment;
        }
    }
}