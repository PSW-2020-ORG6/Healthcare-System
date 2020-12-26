// File:    AppointmentSchedulingService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class AppointmentSchedulingService

using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
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
        private SchedulingStrategy _appointmentStrategy;

        private IPhysicianRepository _physicianRepository;

        public AppointmentSchedulingService()
        {
            var physicianRepository = new PhysicianDatabaseSql();
            SchedulingStrategyContext = new PatientSchedulingStrategy();
            _appointmentGeneralitiesManager = new AppointmentGeneralitiesManager(physicianRepository, new RoomDatabaseSql(),
                new AppointmentDatabaseSql(), new RenovationDatabaseSql(), new BedReservationDatabaseSql());

            _physicianRepository = physicianRepository;
        }

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
        public List<AppointmentDto> GetAvailableAppointmentsGEA(AppointmentDto appointmentPreferences, int priority)
        {
            List<AppointmentDto> appointments = new List<AppointmentDto>();
            List<Physician> physicians = _physicianRepository.GetAll();
            int physicianIndex = 0;
            bool firstTime = true;
            bool noDoctors = false;
            do
            {
                appointments = _appointmentGeneralitiesManager.GetAllAvailableAppointmentsGEA(appointmentPreferences, ref noDoctors );
                if( noDoctors )
                {
                    break;
                }
                if (appointments == null || appointments.Count == 0)
                {
                    if (priority == 0) //doctor is priority
                    {
                        if(!firstTime)
                        {
                            appointmentPreferences.Date.AddDays(1);
                            appointmentPreferences.Time.Start.Date.AddDays(1);
                            appointmentPreferences.Time.End.Date.AddDays(1);
                        }
                        else
                        {
                            firstTime = false;
                        }
                        appointmentPreferences.Time.Start = new DateTime(appointmentPreferences.Time.Start.Year,
                                                                        appointmentPreferences.Time.Start.Month,
                                                                        appointmentPreferences.Time.Start.Day,
                                                                        0, 0, 0);
                        appointmentPreferences.Time.End = new DateTime(appointmentPreferences.Time.Start.Year,
                                                                        appointmentPreferences.Time.Start.Month,
                                                                        appointmentPreferences.Time.Start.Day,
                                                                        23, 59, 59);
                    }
                    else
                    {
                        if( physicianIndex < physicians.Count )
                        {
                            appointmentPreferences.Physician = physicians[physicianIndex];
                            physicianIndex++;
                        }
                        else
                        {
                            priority = 0;
                        }
                    }
                }
            } while (appointments.Count == 0 );
            
            return appointments;
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