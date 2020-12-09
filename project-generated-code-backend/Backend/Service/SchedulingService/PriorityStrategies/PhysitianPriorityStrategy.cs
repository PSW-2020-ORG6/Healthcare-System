// File:    PhysitianPriorityStrategy.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianPriorityStrategy

using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Dto;

namespace HealthClinicBackend.Backend.Service.SchedulingService.PriorityStrategies
{
    public class PhysitianPriorityStrategy : PriorityStrategy
    {
        public List<AppointmentDto> FindSuggestedAppointments(SuggestedAppointmentDto suggestedAppointmentDTO)
        {
            DateTime currentDate = suggestedAppointmentDTO.DateStart.AddDays(-3);
            List<AppointmentDto> appointmentDTOs = new List<AppointmentDto>();
            while (!currentDate.Equals(suggestedAppointmentDTO.DateEnd.AddDays(3)))
            {
                AppointmentDto appointment = new AppointmentDto();
                if (currentDate.CompareTo(DateTime.Today) < 0)
                {
                    continue;
                }
                appointment.Date = currentDate;
                appointment.Physician = suggestedAppointmentDTO.Physician;
                appointment.Patient = suggestedAppointmentDTO.Patient;
                appointmentDTOs.Add(appointment);
                currentDate = currentDate.AddDays(1);
                if (currentDate == suggestedAppointmentDTO.DateStart)
                {
                    currentDate = suggestedAppointmentDTO.DateEnd;
                }
            }
            return appointmentDTOs;
        }

    }
}