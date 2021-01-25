using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System;
using System.Linq;

namespace HealthClinicBackend.Backend.Service.HospitalAccountsService
{
    public class HospitalLogInService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly ISecretaryRepository _secretaryRepository;
        private readonly ISuperintendentRepository _superintendentRepository;

        public HospitalLogInService()
        {
            _patientRepository = new PatientDatabaseSql();
            _physicianRepository = new PhysicianDatabaseSql();
            _secretaryRepository = new SecretaryDatabaseSql();
            _superintendentRepository = new SuperintendentDatabaseSql();
        }

        public HospitalLogInService(IPatientRepository patientRepository, IPhysicianRepository physicianRepository,
            ISecretaryRepository secretaryRepository)
        {
            _patientRepository = patientRepository;
            _physicianRepository = physicianRepository;
            _secretaryRepository = secretaryRepository;
        }

        /// <summary>
        /// Return TypeOfUser based on jmbg-userName and password
        /// </summary>
        /// <param name="jmbg"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public TypeOfUser GetUserType(string jmbg, string password)
        {
            var typeOfUser = TypeOfUser.NoUser;
            if (CheckIfUserIsPatient(jmbg, password))
            {
                typeOfUser = TypeOfUser.Patient;
            }

            if (CheckIfUserIsPhysician(jmbg, password))
            {
                typeOfUser = TypeOfUser.Physician;
            }

            if (CheckIfUserIsSecretary(jmbg, password))
            {
                typeOfUser = TypeOfUser.Secretary;
            }

            if (CheckIfUserIsSuperintendent(jmbg, password))
            {
                typeOfUser = TypeOfUser.Superintendent;
            }

            return typeOfUser;
        }

        public Account GetUserProfile(string jmbg, string password)
        {
            if (CheckIfUserIsPatient(jmbg, password))
            {
                var patients = _patientRepository.GetAll();
                return patients.Find(patient => patient.AreCredentialsValid2(jmbg, password));
            }

            if (CheckIfUserIsPhysician(jmbg, password))
            {
                var physicians = _physicianRepository.GetAll();
                return physicians.Find(physician => physician.AreCredentialsValid2(jmbg, password));
            }

            if (CheckIfUserIsSecretary(jmbg, password))
            {
                var secretaries = _secretaryRepository.GetAll();
                return secretaries.Find(secretary => secretary.AreCredentialsValid2(jmbg, password));
            }

            if (CheckIfUserIsSuperintendent(jmbg, password))
            {
                var superintendents = _superintendentRepository.GetAll();
                return superintendents.Find(superintendent => superintendent.AreCredentialsValid2(jmbg, password));
            }

            return null;
        }

        private bool CheckIfUserIsPatient(string jmbg, string password)
        {
            var patients = _patientRepository.GetAll();
            return patients.Any(patient => patient.AreCredentialsValid2(jmbg, password));
        }

        private bool CheckIfUserIsPhysician(string jmbg, string password)
        {
            var physicians = _physicianRepository.GetAll();
            return physicians.Any(physician => physician.AreCredentialsValid2(jmbg, password));
        }

        private bool CheckIfUserIsSecretary(string jmbg, string password)
        {
            var secretaries = _secretaryRepository.GetAll();
            return secretaries.Any(secretary => secretary.AreCredentialsValid2(jmbg, password));
        }

        private bool CheckIfUserIsSuperintendent(string jmbg, string password)
        {
            var superintendents = _superintendentRepository.GetAll();
            return superintendents.Any(superintendent => superintendent.AreCredentialsValid2(jmbg, password));
        }
    }
}