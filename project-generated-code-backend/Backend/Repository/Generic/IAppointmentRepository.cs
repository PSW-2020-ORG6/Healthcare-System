// File:    AppointmentRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface AppointmentRepository

using Model.Accounts;
using Model.Hospital;
using Model.Schedule;
using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        List<Appointment> GetAppointmentsByDate(DateTime date);

        List<Appointment> GetAppointmentsByPatient(Patient patient);

        List<Appointment> GetAppointmentsByPhysitian(Physician physician);

        List<Appointment> GetAppointmentsByRoom(Room room);

    }
}