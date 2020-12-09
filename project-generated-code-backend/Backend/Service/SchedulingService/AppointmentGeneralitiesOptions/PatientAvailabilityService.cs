using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using Model.Accounts;
using Model.Schedule;
using Model.Util;

namespace HealthClinicBackend.Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    class PatientAvailabilityService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public PatientAvailabilityService()
        {
            _appointmentRepository = new AppointmentDatabaseSql();
        }

        public bool IsPatientAvailable(Patient patient, TimeInterval timeInterval)
        {
            return !IsPatientScheduled(patient, timeInterval);
        }
        private bool IsPatientScheduled(Patient patient, TimeInterval timeInterval)
        {
            List<Appointment> appointments = _appointmentRepository.GetAppointmentsByPatient(patient);
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
