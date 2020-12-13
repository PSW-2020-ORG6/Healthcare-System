using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;

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
