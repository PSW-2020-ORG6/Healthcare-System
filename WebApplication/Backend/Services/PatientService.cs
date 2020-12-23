using Model.Accounts;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using WebApplication.Backend.Repositorys;
using HealthClinicBackend.Backend.Dto;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class PatientService
    {
        private PatientRepository patientRepository;
        private PatientDto patientDTO = new PatientDto();
        public PatientService()
        {
            this.patientRepository = new PatientRepository();
        }
        /// <summary>
        ///calls method for get all patients in patients table
        ///</summary>
        ///<returns>
        ///list of patients
        ///</returns>
        internal List<Patient> GetAllPatients()
        {
            return patientRepository.GetAllPatients();
        }

        /// <summary>
        ///Get patient from patients table by ID
        ///</summary>
        ///<returns>
        ///single instance of Patient object
        ///</returns
        internal PatientDto GetPatientById(string patientId)
        {
            return patientDTO.ConvertToPatientDTO(patientRepository.GetPatientById(patientId));
        }

        internal List<Patient> GetMaliciousPatients()
        {
            return patientRepository.GetMaliciousPatients();
        }

        internal bool BlockMaliciousPatient(string patientId)
        {
            return patientRepository.BlockMaliciousPatient(patientId);
        }
    }
}
