using Backend.Repository;
using health_clinic_class_diagram.Backend.Model.Util;
using Model.Accounts;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Service.HospitalAccountsService
{
    public class HospitalLogInService
    {
        private PatientRepository patientRepository;

        private PhysitianRepository physitianRepository;

        private SecretaryRepository secretaryRepository;
        public HospitalLogInService()
        {
            patientRepository = new PatientFileSystem();
            physitianRepository = new PhysitianFileSystem();
            secretaryRepository = new SecretaryFileSystem();
        }

        public TypeOfUser CheckIfUserIsPatient(string jmbg, string password)
        {
            List<Patient> patients = patientRepository.GetAll();
            foreach (Patient patient in patients)
            {
                if (CheckJmbg(jmbg, patient) && IsValidPassword(password, patient))
                {
                    return TypeOfUser.PATIENT;
                }
            }
            return TypeOfUser.NO_USER;
        }

        public TypeOfUser CheckIfUserIsPhysitians(string jmbg, string password)
        {
            List<Physitian> physitians = physitianRepository.GetAll();
            foreach (Physitian physitian in physitians)
            {
                if (CheckJmbg(jmbg, physitian) && IsValidPassword(password, physitian))
                {
                    return TypeOfUser.PHYSICIAN;
                }
            }
            return TypeOfUser.NO_USER;
        }

        public TypeOfUser CheckIfUserIsSecretaries(string jmbg, string password)
        {
            List<Secretary> secretaries = secretaryRepository.GetAll();
            foreach (Secretary secretary in secretaries)
            {
                if (CheckJmbg(jmbg, secretary) && IsValidPassword(password, secretary))
                {
                    return TypeOfUser.PHYSICIAN;
                }
            }
            return TypeOfUser.NO_USER;
        }

        /// <summary>
        /// Return TypeOfUser based on jmbg-userName and password
        /// </summary>
        /// <param name="jmbg"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public TypeOfUser GetUserType(string jmbg, string password)
        {
            TypeOfUser typeOfUser = CheckIfUserIsPatient(jmbg, password);
            if (typeOfUser != TypeOfUser.NO_USER)
            {
                return typeOfUser;
            }

            typeOfUser = CheckIfUserIsPhysitians(jmbg, password);
            if (typeOfUser != TypeOfUser.NO_USER)
            {
                return typeOfUser;
            }

            typeOfUser = CheckIfUserIsSecretaries(jmbg, password);
            if (typeOfUser != TypeOfUser.NO_USER)
            {
                return typeOfUser;
            }

            return TypeOfUser.NO_USER;
        }

        private static bool CheckJmbg(string jmbg, Account account)
        {
            return account.Id.Equals(jmbg);
        }

        private static bool IsValidPassword(string password, Account account)
        {
            return account.Password.Equals(password);
        }
    }
}
