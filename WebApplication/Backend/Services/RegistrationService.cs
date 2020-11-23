using Backend.Dto;
using Model.Accounts;
using System;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
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

        public bool IsJMBGValid(String jmbg)
        {
            String id = iregistrationRepository.GetPatientIdById(jmbg);

            if (id ==  "" || id == null)
            {
                return true;
            }
            return false;
        }

    }
}
