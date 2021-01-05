// File:    PhysitianScheduleService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianScheduleService

using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.SchedulingService
{
    public class PhysicianScheduleService
    {
        private readonly Physician _loggedPhysician;
        private readonly IAppointmentRepository _appointmentRepository;

        public PhysicianScheduleService(Physician loggedPhysician, IAppointmentRepository appointmentRepository)
        {
            _loggedPhysician = loggedPhysician;
            _appointmentRepository = appointmentRepository;
        }

        public void NewAppointment(AppointmentDto appointmentDto)
        {
            var appointment = new Appointment(appointmentDto);
            _appointmentRepository.Save(appointment);
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return _appointmentRepository.GetAppointmentsByPhysician(_loggedPhysician)
                .Where(appointment => date.Equals(appointment.Date)).ToList();
        }

        public Appointment GetTodaysAppointmentForPatient(Patient patient)
        {
            List<Appointment> appointments = _appointmentRepository.GetAppointmentsByPhysician(_loggedPhysician);
            return appointments.FirstOrDefault(appointment =>
                appointment.Date.Equals(DateTime.Today) && appointment.Patient.Equals(patient));
            return null;
        }

        public Appointment GetPreviousAppointmentForPatient(Patient patient)
        {
            List<Appointment> appointments = _appointmentRepository.GetAppointmentsByPatient(patient);
            return SortAppointmentsDescending(appointments).FirstOrDefault(appointment => IsInPast(appointment));
        }

        public Appointment GetNextAppointmentForPatient(Patient patient)
        {
            List<Appointment> appointments = _appointmentRepository.GetAppointmentsByPatient(patient);
            return SortAppointmentsAscending(appointments).FirstOrDefault(IsInFuture);
        }

        private bool IsInPast(Appointment appointment)
        {
            return appointment.Date.CompareTo(DateTime.Today) < 0;
        }

        private bool IsInFuture(Appointment appointment)
        {
            return appointment.Date.CompareTo(DateTime.Today) > 0;
        }

        private List<Appointment> SortAppointmentsDescending(List<Appointment> appointments)
        {
            appointments.Sort((a, b) => b.CompareTo(a));
            return appointments;
        }

        private List<Appointment> SortAppointmentsAscending(List<Appointment> appointments)
        {
            appointments.Sort((a, b) => a.CompareTo(b));
            return appointments;
        }
    }
}