// File:    AppointmentSchedulingService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class AppointmentSchedulingService

using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Dto;
using HealthClinicBackend.Backend.Service.SchedulingService.AppointmentGeneralitiesOptions;
using HealthClinicBackend.Backend.Service.SchedulingService.PriorityStrategies;
using HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies;

namespace HealthClinicBackend.Backend.Service.SchedulingService
{
    public class AppointmentSchedulingService
    {
        private readonly SchedulingStrategy _schedulingStrategyContext;
        private readonly AppointmentGeneralitiesManager _appointmentGeneralitiesManager;

        public AppointmentSchedulingService(SchedulingStrategy schedulingStrategyContext)
        {
            _schedulingStrategyContext = schedulingStrategyContext;
            _appointmentGeneralitiesManager = new AppointmentGeneralitiesManager();
        }

        public List<AppointmentDTO> GetAvailableAppointments(AppointmentDTO appointmentPreferences)
        {
            AppointmentDTO preparedAppointmentPreferences =
                _schedulingStrategyContext.PrepareAppointment(appointmentPreferences);
            return _appointmentGeneralitiesManager.GetAllAvailableAppointments(preparedAppointmentPreferences);
        }

        public AppointmentDTO FindNearestAppointment(AppointmentDTO appointmentPreferences)
        {
            AppointmentDTO preparedAppointmentPreferences =
                _schedulingStrategyContext.PrepareAppointment(appointmentPreferences);
            throw new NotImplementedException();
        }

        public AppointmentDTO GetSuggestedAppointment(SuggestedAppointmentDTO suggestedAppointmentDto)
        {
            DateTime currentDate = suggestedAppointmentDto.DateStart;

            while (!currentDate.Equals(suggestedAppointmentDto.DateEnd))
            {
                AppointmentDTO appointment = new AppointmentDTO
                {
                    Date = currentDate,
                    Physician = suggestedAppointmentDto.Physician,
                    Patient = suggestedAppointmentDto.Patient
                };
                List<AppointmentDTO> suggestedAppointmentDtos = GetAvailableAppointments(appointment);
                if (suggestedAppointmentDtos.Count != 0)
                {
                    return suggestedAppointmentDtos[0];
                }

                currentDate = currentDate.AddDays(1);
            }

            if (suggestedAppointmentDto.Prior)
            {
                DatePriorityStrategy datePriorityStrategy = new DatePriorityStrategy();
                List<AppointmentDTO> suggestedAppointmentDtosDate =
                    datePriorityStrategy.FindSuggestedAppointments(suggestedAppointmentDto);
                return (from appointmentDto in suggestedAppointmentDtosDate select GetAvailableAppointments(appointmentDto) into suggestedAppointmentDtOs where suggestedAppointmentDtOs.Count != 0 select suggestedAppointmentDtOs[0]).FirstOrDefault();
            }
            else
            {
                PhysitianPriorityStrategy physicianPriorityStrategy = new PhysitianPriorityStrategy();
                List<AppointmentDTO> suggestedAppointmentDtosPhysician =
                    physicianPriorityStrategy.FindSuggestedAppointments(suggestedAppointmentDto);
                foreach (AppointmentDTO appointmentDto in suggestedAppointmentDtosPhysician)
                {
                    List<AppointmentDTO> suggestedAppointmentDtos = GetAvailableAppointments(appointmentDto);
                    if (suggestedAppointmentDtos.Count != 0)
                    {
                        return suggestedAppointmentDtos[0];
                    }
                }
            }

            return null;
        }
    }
}