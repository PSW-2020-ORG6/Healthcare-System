using Model.Accounts;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class RegistrationService
    {
        private IRegistrationRepository iregistrationRepository = new RegistrationRepository();
        public RegistrationService()
        {
            this.iregistrationRepository = new RegistrationRepository();
        }

        public RegistrationService(IRegistrationRepository iregistrationRepository)
        {
            this.iregistrationRepository = iregistrationRepository;
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
            if (iregistrationRepository.IsPatientIdValid(patient.Id))
            {
                return iregistrationRepository.addPatient(patient);
            }
            else
            {
                return false;
            }
        }

        public bool ConfirmEmailUpdate(string id)
        {
            return iregistrationRepository.ConfirmEmailUpdate(id);
        }

    }
}
