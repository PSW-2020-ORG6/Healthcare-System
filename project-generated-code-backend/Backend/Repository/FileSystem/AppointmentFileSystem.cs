// File:    AppointmentFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class AppointmentFileSystem

using Model.Accounts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;

namespace Backend.Repository
{
    public class AppointmentFileSystem : GenericFileSystem<Appointment>, IAppointmentRepository
    {
        public AppointmentFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/appointments.txt";
            path = @"./../../data/appointments.txt";
        }
        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            List<Appointment> appointmentsByDate = new List<Appointment>();
            List<Appointment> allAppointments = GetAll();
            foreach (Appointment a in allAppointments)
            {
                if (date.Equals(a.TimeInterval.Start.Date))
                {
                    appointmentsByDate.Add(a);
                }
            }
            return appointmentsByDate;
        }

        public List<Appointment> GetAppointmentsByPatient(Patient patient)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in GetAll())
            {
                if (patient.Equals(appointment.Patient))
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public List<Appointment> GetAppointmentsByPhysician(Physician physician)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in GetAll())
            {
                if (physician.Equals(appointment.Physician))
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public List<Appointment> GetAppointmentsByRoom(Room room)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in GetAll())
            {
                if (room.Equals(appointment.Room))
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public override Appointment Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Appointment>(objectStringFormat);
        }
    }
}