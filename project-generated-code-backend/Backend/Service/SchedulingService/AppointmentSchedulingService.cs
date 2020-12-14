// File:    AppointmentSchedulingService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class AppointmentSchedulingService

using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.SchedulingService.AppointmentGeneralitiesOptions;
using HealthClinicBackend.Backend.Service.SchedulingService.PriorityStrategies;
using HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Service.SchedulingService
{
    public class AppointmentSchedulingService
    {
        public SchedulingStrategy SchedulingStrategyContext;
        private readonly AppointmentGeneralitiesManager _appointmentGeneralitiesManager;

        private IPhysicianRepository _physicianRepository;

        public AppointmentSchedulingService(IPhysicianRepository physicianRepository,
            IRoomRepository roomRepository,
            IAppointmentRepository appointmentRepository,
            IRenovationRepository renovationRepository,
            IBedReservationRepository bedReservationRepository)
        {
            SchedulingStrategyContext = new PatientSchedulingStrategy();
            _appointmentGeneralitiesManager = new AppointmentGeneralitiesManager(physicianRepository, roomRepository,
                appointmentRepository, renovationRepository, bedReservationRepository);

            _physicianRepository = physicianRepository;
        }

        public List<AppointmentDto> GetAvailableAppointments(AppointmentDto appointmentPreferences)
        {
            AppointmentDto preparedAppointmentPreferences =
                SchedulingStrategyContext.PrepareAppointment(appointmentPreferences);
            return _appointmentGeneralitiesManager.GetAllAvailableAppointments(preparedAppointmentPreferences);
        }

        public AppointmentDto FindNearestAppointment(AppointmentDto appointmentPreferences)
        {
            AppointmentDto preparedAppointmentPreferences =
                SchedulingStrategyContext.PrepareAppointment(appointmentPreferences);
            throw new NotImplementedException();
        }

        public AppointmentDto GetSuggestedAppointment(SuggestedAppointmentDto suggestedAppointmentDto)
        {
            DateTime currentDate = suggestedAppointmentDto.DateStart;

            while (!currentDate.Equals(suggestedAppointmentDto.DateEnd))
            {
                AppointmentDto appointment = new AppointmentDto
                {
                    Date = currentDate,
                    Physician = suggestedAppointmentDto.Physician,
                    Patient = suggestedAppointmentDto.Patient
                };
                List<AppointmentDto> suggestedAppointmentDtos = GetAvailableAppointments(appointment);
                if (suggestedAppointmentDtos.Count != 0)
                {
                    return suggestedAppointmentDtos[0];
                }

                currentDate = currentDate.AddDays(1);
            }

            if (suggestedAppointmentDto.Prior)
            {
                DatePriorityStrategy datePriorityStrategy = new DatePriorityStrategy();
                List<AppointmentDto> suggestedAppointmentDtosDate =
                    datePriorityStrategy.FindSuggestedAppointments(suggestedAppointmentDto);
                return (from appointmentDto in suggestedAppointmentDtosDate
                    select GetAvailableAppointments(appointmentDto)
                    into suggestedAppointmentDtOs
                    where suggestedAppointmentDtOs.Count != 0
                    select suggestedAppointmentDtOs[0]).FirstOrDefault();
            }
            else
            {
                PhysitianPriorityStrategy physicianPriorityStrategy = new PhysitianPriorityStrategy();
                List<AppointmentDto> suggestedAppointmentDtosPhysician =
                    physicianPriorityStrategy.FindSuggestedAppointments(suggestedAppointmentDto);
                foreach (AppointmentDto appointmentDto in suggestedAppointmentDtosPhysician)
                {
                    List<AppointmentDto> suggestedAppointmentDtos = GetAvailableAppointments(appointmentDto);
                    if (suggestedAppointmentDtos.Count != 0)
                    {
                        return suggestedAppointmentDtos[0];
                    }
                }
            }

            return null;
        }

        public List<AppointmentDto> MakeAppointment(AppointmentDto appointmentDto, int priority)
        {
            List<AppointmentDto> appointments = GetAvailableAppointments(appointmentDto);
            if (appointments == null || appointments.Count != 0)
            {
                return appointments;
            }
            if (priority == 0) //prioritet je doktor
            {
                appointmentDto.Date.AddDays(1);
                MakeAppointment(appointmentDto, priority);
            }
            else
            {
                foreach(Physician physician in _physicianRepository.GetAll()){
                    appointmentDto.Physician = physician;
                    appointments = GetAvailableAppointments(appointmentDto);
                    if (appointments != null || appointments.Count != 0)
                    {
                        return appointments;
                    }
                }
            }

            return null;
        }
    }
}