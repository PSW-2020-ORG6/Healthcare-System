using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalAccountsService
{
    public class PatientAccountsService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public PatientAccountsService()
        {
            _patientRepository = new PatientDatabaseSql();
            _appointmentRepository = new AppointmentDatabaseSql();
        }

        public PatientAccountsService(IPatientRepository patientRepository,
            IAppointmentRepository appointmentRepository)
        {
            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;
        }

        public List<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll();
        }

        public List<Patient> GetPatientsForPhysician(Physician physician)
        {
            List<Patient> allPatients = _patientRepository.GetAll();
            List<Patient> patients = new List<Patient>();
            foreach (Patient patient in allPatients)
            {
                if (IsPatientScheduledForPhysician(patient, physician))
                {
                    patients.Add(patient);
                }
            }

            return patients;
        }

        internal List<Patient> GetPatientsForPhysitian(Physician physician)
        {
            throw new NotImplementedException();
        }

        private bool IsPatientScheduledForPhysician(Patient patient, Physician physician)
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

        public Patient GetById(string id)
        {
            return _patientRepository.GetById(id);
        }

        public List<Patient> GetByName(string name)
        {
            return _patientRepository.GetByName(name);
        }
    }
}