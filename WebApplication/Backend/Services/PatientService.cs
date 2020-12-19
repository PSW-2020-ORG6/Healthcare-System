using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class PatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        ///Tanja Drcelic RA124/2017
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


        ///Aleksa Repović
        /// <summary>
        ///Get patient from patients table by ID
        ///</summary>
        ///<returns>
        ///single instance of Patient object
        ///</returns
        internal Patient GetPatientById(string patientId)
        {
            return _patientRepository.GetById(patientId);
        }
    }
}