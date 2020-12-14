﻿using System;
using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Service.SchedulingService
{
    class PatientScheduleService
    {
        private Patient _loggedPatient;
        private IAppointmentRepository _appointmentRepository;

        public PatientScheduleService(Patient loggedPatient)
        {
            _loggedPatient = loggedPatient;
          //  _appointmentRepository = new AppointmentDatabaseSql();
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Appointment NextAppointment()
        {
            throw new NotImplementedException();
        }

        public void NewAppointment(AppointmentDto appointmentDto)
        {
            throw new NotImplementedException();
        }
    }
}