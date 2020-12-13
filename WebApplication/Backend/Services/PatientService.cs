﻿using Model.Accounts;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class PatientService
    {
        private PatientRepository patientRepository;
        public PatientService()
        {
            this.patientRepository = new PatientRepository();
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
            return patientRepository.GetAllPatients();
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
            Patient returnValue = patientRepository.GetPatientById(patientId);
            returnValue.Address = patientRepository.GetAddress(returnValue.Address.SerialNumber);
            return returnValue;
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
