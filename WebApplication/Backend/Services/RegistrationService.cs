using Model.Accounts;
using System;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class RegistrationService
    {
        private RegistrationRepository registrationRepository;
        private IRegistrationRepository iregistrationRepository = new RegistrationRepository();
        public RegistrationService()
        {
            this.registrationRepository = new RegistrationRepository();
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
            if (IsJMBGValid(patient.Id))
            {
                return iregistrationRepository.addPatient(patient);
            }
            else
            {
                return false;
            }
        }

        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///calls a method to check for the existence of an id number
        ///</summary>
        ///<returns>
        ///true or false depending on sucess
        ///</returns>
        ///<param name="idNumber"> String type object
        ///</param>>
        public bool IsJMBGValid(String idNumber)
        {
            String id = iregistrationRepository.FindPatientId(idNumber);

            if (id ==  "" || id == null)
            {
                return true;
            }
            return false;
        }

        public bool ConfirmEmailUpdate(string id)
        {
            return iregistrationRepository.ConfirmEmailUpdate(id);
        }

    }
}
