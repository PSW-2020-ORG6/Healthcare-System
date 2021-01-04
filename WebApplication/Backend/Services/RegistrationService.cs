using HealthClinicBackend.Backend.Dto;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class RegistrationService
    {
        private IRegistrationRepository registrationRepository = new RegistrationRepository();
        private PhysicianRepository physitianRepository = new PhysicianRepository();
        public RegistrationService()
        {
            this.registrationRepository = new RegistrationRepository();
        }

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }

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

        public List<FamilyDoctorDto> GetAllPhysicians()
        {
            return registrationRepository.GetAllGeneralPracticePhysicians();
        }

    }
}
