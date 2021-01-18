// File:    PhysitianPriorityStrategy.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianPriorityStrategy

using HealthClinicBackend.Backend.Dto;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Service.SchedulingService.PriorityStrategies
{
    public class PhysitianPriorityStrategy : PriorityStrategy
    {
        public List<ADTO> FindSuggestedAppointments(SuggestedAppointmentDto suggestedAppointmentDTO)
        {
            DateTime currentDate = suggestedAppointmentDTO.DateStart.AddDays(-3);
            List<ADTO> appointmentDTOs = new List<ADTO>();
            while (!currentDate.Equals(suggestedAppointmentDTO.DateEnd.AddDays(3)))
            {
                ADTO appointment = new ADTO();
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