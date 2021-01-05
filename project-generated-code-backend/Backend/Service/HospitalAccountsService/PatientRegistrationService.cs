// File:    PatientRegistrationService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientRegistrationService

using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalAccountsService
{
    public class PatientRegistrationService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientRegistrationService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        private bool IsJmbgValid(string jmbg)
        {
            List<Patient> patients = _patientRepository.GetAll();
            return patients.All(p => p.Id != jmbg);
        }

        private bool IsGuest(string jmbg)
        {
            List<Patient> patients = _patientRepository.GetAll();
            return patients.Where(p => p.Id.Equals(jmbg)).Any(p => p.Guest);
        }

        public void RegisterPatient(PatientDto patientDto)
        {
            if (!IsJmbgValid(patientDto.Id) && IsGuest(patientDto.Id))
            {
                var p = GetExistingPatient(patientDto.Id);
                if (p == null)
                {
                    return;
                }

                var newPatient = new Patient(patientDto) {SerialNumber = p.SerialNumber};
                _patientRepository.Update(newPatient);
            }
            else if (IsJmbgValid(patientDto.Id))
            {
                _patientRepository.Save(new Patient(patientDto));
            }
        }

        private Patient GetExistingPatient(string jmbg)
        {
            List<Patient> patients = _patientRepository.GetAll();
            return patients.FirstOrDefault(p => p.Id.Equals(jmbg));
        }

        public void DeletePatientAccount(Patient patient)
        {
            _patientRepository.Delete(patient.SerialNumber);
        }
    }
}