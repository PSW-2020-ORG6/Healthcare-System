using System;
using HealthClinicBackend.Backend.Dto;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
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
            if (_registrationRepository.IsPatientIdValid(patient.Id))
            {
                return _registrationRepository.AddPatient(patient);
            }
            else
            {
                return false;
            }
        }

        public bool ConfirmEmailUpdate(string id)
        {
            return _registrationRepository.ConfirmEmailUpdate(id);
        }

        public List<FamilyDoctorDto> GetAllPhysicians()
        {
            return _registrationRepository.GetAllGeneralPracticePhysicians();
        }
    }
}