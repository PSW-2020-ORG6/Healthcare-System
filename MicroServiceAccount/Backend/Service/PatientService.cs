using System.Collections.Generic;
using System;
using MicroServiceAccount.Backend.Dto;
using HealthClinicBackend.Backend.Model.PharmacySupport;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Dto;
using MicroServiceAppointment.Backend.Dto;

namespace MicroServiceAccount.Backend.Service
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class PatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IActionAndBenefitMessageRepository _actionsAndBenefitsRepository;
        private readonly IAddressRepository _addressRepository;


        private PatientDto patientDTO = new PatientDto();

        public PatientService(IPatientRepository patientRepository,
            IActionAndBenefitMessageRepository actionsAndBenefitsRepository, IAddressRepository addressRepository)
        {
            _patientRepository = patientRepository;
            _actionsAndBenefitsRepository = actionsAndBenefitsRepository;
            _addressRepository = addressRepository;
        }

        /// <summary>
        ///calls method for get all patients in patients table
        ///</summary>
        ///<returns>
        ///list of patients
        ///</returns>
        internal List<Patient> GetAllPatients()
        {
            List<Patient> patients = _patientRepository.GetAll();
            foreach (Patient patient in patients)
            {
                AddAddressToPatient(patient);
            }
            return patients;
        }

        /// <summary>
        ///Get patient from patients table by ID
        ///</summary>
        ///<returns>
        ///single instance of Patient object
        ///</returns
        internal PatientDto GetPatientById(string patientId)
        {
            Patient patient = _patientRepository.GetById(patientId);
            patient = AddAddressToPatient(patient);
            return patientDTO.ConvertToPatientDTO(patient);
            throw new NotImplementedException();
        }

        internal Patient AddAddressToPatient(Patient patient)
        {
            patient.Address = _addressRepository.GetById(patient.AddressSerialNumber);
            return patient;
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
                _actionsAndBenefitsRepository.GetAll())
            {
                if (t.IsDateIntervalValid(a.DateFrom, a.DateTo))
                    actionAndBenefitMessages.Add(a);
            }
            return actionAndBenefitMessages;
        }
    }
}