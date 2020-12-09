﻿using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    class AppointmentGeneralitiesManager
    {
        private AppointmentDto _appointmentPreferences;
        private readonly IPhysitianRepository _physicianRepository;
        private readonly IRoomRepository _roomRepository;

        public AppointmentGeneralitiesManager()
        {
            _physicianRepository = new PhysicianDatabaseSql();
            _roomRepository = new RoomDatabaseSql();
        }

        public List<AppointmentDto> GetAllAvailableAppointments(AppointmentDto appointmentPreferences)
        {
            _appointmentPreferences = appointmentPreferences;
            List<AppointmentDto> appointments = new List<AppointmentDto>();

            List<TimeInterval> allTimeIntervals = GetAllTimeIntervals();
            List<Physician> allPhysicians = GetAllPhysicians();
            List<Room> allRooms = GetAllRooms();

            PhysicianAvailabilityService physicianAvailabilityService = new PhysicianAvailabilityService();
            RoomAvailabilityService roomAvailabilityService = new RoomAvailabilityService();

            foreach (TimeInterval timeInterval in allTimeIntervals)
            {
                foreach (Physician physician in allPhysicians)
                {
                    if (physicianAvailabilityService.IsPhysicianAvailable(physician, timeInterval))
                    {
                        foreach (Room room in allRooms)
                        {
                            if (roomAvailabilityService.IsRoomAvailable(room, timeInterval))
                            {
                                AppointmentDto appointmentDto = CreateAppointment(physician, room, timeInterval);
                                appointments.Add(appointmentDto);
                            }
                        }
                    }
                }
            }

            return appointments;
        }

        private AppointmentDto CreateAppointment(Physician physician, Room room, TimeInterval timeInterval)
        {
            AppointmentDto appointment = new AppointmentDto();
            appointment.ProcedureType = _appointmentPreferences.ProcedureType;
            appointment.Patient = _appointmentPreferences.Patient;
            appointment.Time = timeInterval;
            appointment.Physician = physician;
            appointment.Room = room;
            return appointment;
        }

        private List<Physician> GetAllPhysicians()
        {
            List<Physician> physicians = new List<Physician>();
            if (_appointmentPreferences.IsPreferedPhysicianSelected())
            {
                physicians.Add(_appointmentPreferences.Physician);
            }
            else
            {
                physicians = _physicianRepository.GetPhysitiansByProcedureType(_appointmentPreferences.ProcedureType);
            }

            return physicians;
        }

        private List<Room> GetAllRooms()
        {
            return _roomRepository.GetRoomsByProcedureType(_appointmentPreferences.ProcedureType);
        }

        private List<TimeInterval> GetAllTimeIntervals()
        {
            TimeIntervalGenerator generator = new TimeIntervalGenerator(_appointmentPreferences.ProcedureType,
                _appointmentPreferences.RestrictedHours);
            List<TimeInterval> timeIntervals;
            if (_appointmentPreferences.IsPreferredDateSelected())
            {
                timeIntervals = generator.GenerateTimeIntervalsForDay(_appointmentPreferences.Date);
            }
            else
            {
                timeIntervals = generator.GenerateAllTimeIntervals();
                ;
            }

            return timeIntervals;
        }
    }
}