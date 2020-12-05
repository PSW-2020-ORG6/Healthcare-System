using HealthClinicBackend.Backend.Dto;
using Model.Accounts;
using System.Collections.Generic;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class RegistrationService
    {
        private IRegistrationRepository registrationRepository = new RegistrationRepository();
        private PhysitianRepository physitianRepository = new PhysitianRepository();
        public RegistrationService()
        {
            this.registrationRepository = new RegistrationRepository();
        }

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }

        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///calls method for adding new row in patient table
        ///</summary>
        ///<returns>
        ///true or false depending on sucess
        ///</returns>
        ///<param name="patient"> Patient type object
        ///</param>>
        public bool RegisterPatient(Patient patient)
        {
            if (registrationRepository.IsPatientIdValid(patient.Id))
            {
                return registrationRepository.AddPatient(patient);
            }
            else
            {
                return false;
            }
        }

        public bool ConfirmEmailUpdate(string id)
        {
            return registrationRepository.ConfirmEmailUpdate(id);
        }

        public List<FamilyDoctorDTO> GetAllPhysitians()
        {
            return registrationRepository.GetAllGeneralPracticePhysitions();
        }

    }
}
