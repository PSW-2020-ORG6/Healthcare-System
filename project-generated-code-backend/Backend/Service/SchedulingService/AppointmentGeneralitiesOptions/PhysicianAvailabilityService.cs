﻿using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using Model.Accounts;
using Model.Schedule;
using Model.Util;

namespace HealthClinicBackend.Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    public class PhysicianAvailabilityService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public PhysicianAvailabilityService()
        {
            _appointmentRepository = new AppointmentDatabaseSql();
        }

        public bool IsPhysicianAvailableAtAnyTime(Physician physician, List<TimeInterval> timeIntervals)
        {
            foreach (TimeInterval timeInterval in timeIntervals)
            {
                if (IsPhysicianAvailable(physician, timeInterval))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsAnyPhysicianAvailable(List<Physician> physicians, TimeInterval timeInterval)
        {
            foreach (Physician physician in physicians)
            {
                if (IsPhysicianAvailable(physician, timeInterval))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsPhysicianAvailable(Physician physician, TimeInterval timeInterval)
        {
            bool isTheirShift = physician.IsTheirShift(timeInterval);
            bool isNotOnVacation = !physician.IsOnVacation(timeInterval);
            bool isNotScheduled = !IsPhysicianScheduled(physician, timeInterval);
            return isTheirShift && isNotOnVacation && isNotScheduled;
        }
        public bool canGoOnVacation(Physician physician, TimeInterval timeInterval)
        {
            bool isNotOnVacation = !physician.IsOnVacation(timeInterval);
            bool isNotScheduled = !IsPhysicianScheduled(physician, timeInterval);
            return isNotOnVacation && isNotScheduled;
        }

        private bool IsPhysicianScheduled(Physician physician, TimeInterval timeInterval)
        {
            List<Appointment> appointments = _appointmentRepository.GetAppointmentsByPhysician(physician);
            foreach (Appointment appointment in appointments)
            {
                if (timeInterval.IsOverLapping(appointment.TimeInterval))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
