// File:    PatientRegistrationController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientRegistrationController

using Backend.Dto;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Controller
{
    public class PatientRegistrationController
    {
        private readonly PatientRegistrationService _patientRegistrationService;

        public PatientRegistrationController()
        {
            _patientRegistrationService = new PatientRegistrationService();
        }

        public void RegisterPatient(PatientDTO patientDto)
        {
            _patientRegistrationService.RegisterPatient(patientDto);
        }

        public void DeletePatientAccount(Patient patient)
        {
            _patientRegistrationService.DeletePatientAccount(patient);
        }
    }
}