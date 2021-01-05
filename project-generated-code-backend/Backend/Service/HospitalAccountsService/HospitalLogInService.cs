using System.Linq;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalAccountsService
{
    public class HospitalLogInService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly ISecretaryRepository _secretaryRepository;

        public HospitalLogInService()
        {
            _patientRepository = new PatientDatabaseSql();
            _physicianRepository = new PhysicianDatabaseSql();
            _secretaryRepository = new SecretaryDatabaseSql();
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