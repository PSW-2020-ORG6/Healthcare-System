// File:    PriorityStrategy.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface PriorityStrategy

using System.Collections.Generic;
using HealthClinicBackend.Backend.Dto;

namespace HealthClinicBackend.Backend.Service.SchedulingService.PriorityStrategies
{
    public interface PriorityStrategy
    {
        List<AppointmentDto> FindSuggestedAppointments(SuggestedAppointmentDto suggestedAppointmentDTO);

    }
}