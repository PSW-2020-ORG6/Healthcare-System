using Backend.Repository;
using Model.Accounts;
using Model.Schedule;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Service.HospitalAccountsService
{
    public class PatientAccountsService
    {
        private IPatientRepository patientRepository;
        private IAppointmentRepository appointmentRepository;
        private IReportRepository reportRepository;

        public PatientAccountsService()
        {
            this.patientRepository = new PatientFileSystem();
            this.appointmentRepository = new AppointmentFileSystem();
            this.reportRepository = new ReportFileSystem();
        }

        public List<Patient> getAllPatients()
        {
            return patientRepository.GetAll();
        }
        public List<Patient> getPatientsForPhysitian(Physician physician)
        {
            List<Patient> allPatients = patientRepository.GetAll();
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
            List<Appointment> patientAppointments = appointmentRepository.GetAppointmentsByPatient(patient);
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
