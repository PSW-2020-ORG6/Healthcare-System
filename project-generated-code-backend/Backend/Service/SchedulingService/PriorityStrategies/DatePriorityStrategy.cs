// File:    DatePriorityStrategy.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class DatePriorityStrategy

using Backend.Dto;
using Backend.Repository;
using Model.Accounts;
using System;
using System.Collections.Generic;

namespace Backend.Service.SchedulingService.PriorityStrategies
{
    public class DatePriorityStrategy : PriorityStrategy
    {

        public List<AppointmentDTO> FindSuggestedAppointments(SuggestedAppointmentDTO suggestedAppointmentDTO)
        {
            PhysicianFileSystem pfs = new PhysicianFileSystem();
            List<Physician> physitians = pfs.GetAll();
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            foreach (Physician physitian in physitians)
            {
                DateTime currentDate = suggestedAppointmentDTO.DateStart;

                while (!currentDate.Equals(suggestedAppointmentDTO.DateEnd))
                {
                    AppointmentDTO appointment = new AppointmentDTO();
                    appointment.Date = currentDate;
                    appointment.Physician = physitian;
                    appointment.Patient = suggestedAppointmentDTO.Patient;
                    appointmentDTOs.Add(appointment);
                    currentDate = currentDate.AddDays(1);
                }
            }
            return appointmentDTOs;
        }

    }
}