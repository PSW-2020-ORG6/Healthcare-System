// File:    AppointmentRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface AppointmentRepository

using Model.Accounts;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;

namespace Backend.Repository
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        List<Appointment> GetAppointmentsByDate(DateTime date);

        List<Appointment> GetAppointmentsByPatient(Patient patient);

        List<Appointment> GetAppointmentsByPhysician(Physician physician);

        List<Appointment> GetAppointmentsByRoom(Room room);
    }
}