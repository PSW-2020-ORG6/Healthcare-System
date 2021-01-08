using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;
using Model.Accounts;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.PatientControllers
{
    public class PatientController
    {
        public PatientAccountsService patientAccountsService;
        public PatientRegistrationService patientRegistrationService;

        public PatientController()
        {
            patientAccountsService = new PatientAccountsService();
            patientRegistrationService = new PatientRegistrationService();
        }

        public Patient GetById(string id)
        {
            return patientAccountsService.GetById(id);
        }

        public List<Patient> GetByName(string name)
        {
            return patientAccountsService.GetByName(name);
        }

        public List<Patient> GetAll()
        {
            return patientAccountsService.getAllPatients();
        }

        public List<Patient> GetPatientsForPhysitian(Physician physician)
        {
            return patientAccountsService.getPatientsForPhysitian(physician);
        }

        public void RegisterPatient(PatientDto patientDto)
        {
            patientRegistrationService.RegisterPatient(patientDto);
        }

        public void DeletePatientAccount(Patient patient)
        {
            patientRegistrationService.DeletePatientAccount(patient);
        }
    }
}
