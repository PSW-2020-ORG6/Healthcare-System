// File:    PatientSchedulingStrategy.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientSchedulingStrategy

using Backend.Dto;
using HealthClinicBackend.Backend.Util;
using Model.Accounts;
using Model.Schedule;

namespace HealthClinicBackend.Backend.Service.SchedulingService.SchedulingStrategies
{
    public class PatientSchedulingStrategy : SchedulingStrategy
    {
        private const int DISALLOW_SCHEDULING_HOURS = 24;
        public AppointmentDTO PrepareAppointment(AppointmentDTO appointment)
        {
            appointment.RestrictedHours = DISALLOW_SCHEDULING_HOURS;
            appointment.ProcedureType = Constants.GeneralPracticeExam;
            appointment.Urgency = false;
            return appointment;
        }
    }
}