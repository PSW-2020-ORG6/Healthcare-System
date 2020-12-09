using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.FileSystem;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Service.HospitalAccountsService
{
    public class PatientAccountsService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public PatientAccountsService()
        {
            _patientRepository = new PatientDatabaseSql();
            // TODO: 
            _appointmentRepository = new AppointmentFileSystem();
        }

        public List<Patient> getAllPatients()
        {
            return _patientRepository.GetAll();
        }
        public List<Patient> getPatientsForPhysitian(Physician physician)
        {
            List<Patient> allPatients = _patientRepository.GetAll();
            List<Patient> patients = new List<Patient>();
            foreach (Patient patient in allPatients)
            {
                if (IsPatientScheduledForPhysitian(patient, physician))
                {
                    patients.Add(patient);
                }
            }
            return patients;
        }

        private bool IsPatientScheduledForPhysitian(Patient patient, Physician physician)
        {
            List<Appointment> patientAppointments = _appointmentRepository.GetAppointmentsByPatient(patient);
            foreach (Appointment appointment in patientAppointments)
            {
                if (appointment.Physician.Equals(physician))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
