﻿using System.Linq;
using Backend.Repository;
using health_clinic_class_diagram.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;

namespace HealthClinicBackend.Backend.Service.HospitalAccountsService
{
    public class HospitalLogInService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPhysitianRepository _physicianRepository;
        private readonly ISecretaryRepository _secretaryRepository;

        public HospitalLogInService()
        {
            _patientRepository = new PatientDatabaseSql();
            _physicianRepository = new PhysicianDatabaseSql();
            _secretaryRepository = new SecretaryDatabaseSql();
        }

        /// <summary>
        /// Return TypeOfUser based on jmbg-userName and password
        /// </summary>
        /// <param name="jmbg"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public TypeOfUser GetUserType(string jmbg, string password)
        {
            var typeOfUser = TypeOfUser.NO_USER;
            if (CheckIfUserIsPatient(jmbg, password))
            {
                typeOfUser = TypeOfUser.PATIENT;
            }

            if (CheckIfUserIsPhysician(jmbg, password))
            {
                typeOfUser = TypeOfUser.PHYSICIAN;
            }

            if (CheckIfUserIsSecretary(jmbg, password))
            {
                typeOfUser = TypeOfUser.SECRETARY;
            }

            return typeOfUser;
        }

        private bool CheckIfUserIsPatient(string jmbg, string password)
        {
            var patients = _patientRepository.GetAll();
            return patients.Any(patient => patient.AreCredentialsValid(jmbg, password));
        }

        private bool CheckIfUserIsPhysician(string jmbg, string password)
        {
            var physicians = _physicianRepository.GetAll();
            return physicians.Any(physician => physician.AreCredentialsValid(jmbg, password));
        }

        private bool CheckIfUserIsSecretary(string jmbg, string password)
        {
            var secretaries = _secretaryRepository.GetAll();
            return secretaries.Any(secretary => secretary.AreCredentialsValid(jmbg, password));
        }
    }
}