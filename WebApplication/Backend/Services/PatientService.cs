﻿using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Dto;
using System;
using System.Linq;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using IntegrationAdapters.Repositories;
using IntegrationAdapters.Models;
using WebApplication.Backend.DTO;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class PatientService
    {
        private readonly IPatientRepository _patientRepository;
        private PatientDto patientDTO = new PatientDto();
        private readonly IActionsAndBenefitsRepository _actionsAndBenefitsRepository;

        public PatientService()
        {
            _patientRepository = new PatientDatabaseSql();
            // TODO: move this to backend
            _actionsAndBenefitsRepository = new ActionsAndBenefitsRepository();
        }

        public PatientService(IPatientRepository patientRepository,
            IActionsAndBenefitsRepository actionsAndBenefitsRepository)
        {
            _patientRepository = patientRepository;
            _actionsAndBenefitsRepository = actionsAndBenefitsRepository;
        }

        /// <summary>
        ///calls method for get all patients in patients table
        ///</summary>
        ///<returns>
        ///list of patients
        ///</returns>
        internal List<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll();
        }

        /// <summary>
        ///Get patient from patients table by ID
        ///</summary>
        ///<returns>
        ///single instance of Patient object
        ///</returns
        internal PatientDto GetPatientById(string patientId)
        {
            return patientDTO.ConvertToPatientDTO(_patientRepository.GetById(patientId) ??
                                                  _patientRepository.GetByJmbg(patientId));
        }

        internal List<Patient> GetMaliciousPatients()
        {
            return _patientRepository.GetAll().Where(p => p.IsMalicious).ToList();
        }

        internal bool BlockMaliciousPatient(string patientId)
        {
            var patient = _patientRepository.GetByJmbg(patientId) ?? _patientRepository.GetById(patientId);
            if (!patient.IsMalicious) return false;
            patient.IsBlocked = true;
            _patientRepository.Update(patient);
            return true;
        }

        public List<ActionAndBenefitMessage> GetAdvertisements()
        {
            TimeIntervalDTO t = new TimeIntervalDTO();
            List<ActionAndBenefitMessage> actionAndBenefitMessages = new List<ActionAndBenefitMessage>();
            foreach (ActionAndBenefitMessage a in
                _actionsAndBenefitsRepository.GetAllPublishedActionsAndBenefitsMessages())
            {
                if (t.IsDateIntervalValid(a.DateFrom, a.DateTo))
                    actionAndBenefitMessages.Add(a);
            }

            return actionAndBenefitMessages;
        }
    }
}