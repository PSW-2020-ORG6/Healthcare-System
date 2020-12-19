using System;
using HealthClinicBackend.Backend.Dto;
using Model.Accounts;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class RegistrationService : IRegistrationService, IDisposable
    {
        private IRegistrationRepository _registrationRepository;

        // private IPhysicianRepository _physicianRepository;
        // public RegistrationService()
        // {
        //     this.registrationRepository = new RegistrationRepository();
        // }

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

        public void Dispose()
        {
            _registrationRepository.Dispose();
        }
    }
}