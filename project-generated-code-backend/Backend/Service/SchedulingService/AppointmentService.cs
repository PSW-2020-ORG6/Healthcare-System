// File:    AppointmentService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class AppointmentService

using System;
using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql;

namespace HealthClinicBackend.Backend.Service.SchedulingService
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService()
        {
          //  _appointmentRepository = new AppointmentDatabaseSql();
        }

        public void EditAppointment(Appointment appointment)
        {
            _appointmentRepository.Update(appointment);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            _appointmentRepository.Delete(appointment.SerialNumber);
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return _appointmentRepository.GetAppointmentsByDate(date);
        }

        public void NewAppointment(AppointmentDto appointmentDto)
        {
            _appointmentRepository.Save(new Appointment(appointmentDto));
        }
    }
}