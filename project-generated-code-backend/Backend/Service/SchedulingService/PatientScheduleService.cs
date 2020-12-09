using System;
using System.Collections.Generic;
using Backend.Dto;
using Backend.Repository;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using Model.Accounts;
using Model.Schedule;

namespace HealthClinicBackend.Backend.Service.SchedulingService
{
    class PatientScheduleService
    {
        private Patient _loggedPatient;
        private IAppointmentRepository _appointmentRepository;

        public PatientScheduleService(Patient loggedPatient)
        {
            _loggedPatient = loggedPatient;
            _appointmentRepository = new AppointmentDatabaseSql();
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Appointment NextAppointment()
        {
            throw new NotImplementedException();
        }

        public void NewAppointment(AppointmentDTO appointmentDto)
        {
            throw new NotImplementedException();
        }
    }
}