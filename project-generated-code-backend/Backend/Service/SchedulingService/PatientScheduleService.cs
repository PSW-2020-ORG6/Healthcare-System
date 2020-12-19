using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Service.SchedulingService
{
    class PatientScheduleService
    {
        public Patient LoggedPatient;
        private IAppointmentRepository _appointmentRepository;

        public PatientScheduleService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
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