// File:    PatientRegistrationController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientRegistrationController

using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;

namespace HealthClinicBackend.Backend.Controller
{
    public class PatientRegistrationController
    {
        private readonly PatientRegistrationService _patientRegistrationService;

        public PatientRegistrationController(PatientRegistrationService patientRegistrationService)
        {
            _patientRegistrationService = patientRegistrationService;
        }

        public void RegisterPatient(PatientDto patientDto)
        {
            _patientRegistrationService.RegisterPatient(patientDto);
        }

        public void DeletePatientAccount(Patient patient)
        {
            _patientRegistrationService.DeletePatientAccount(patient);
        }
    }
}