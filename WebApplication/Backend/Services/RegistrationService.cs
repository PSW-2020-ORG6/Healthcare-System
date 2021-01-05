using HealthClinicBackend.Backend.Dto;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Util;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class RegistrationService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPhysicianRepository _physicianRepository;

        public RegistrationService(IPatientRepository patientRepository, IPhysicianRepository physicianRepository)
        {
            _patientRepository = patientRepository;
            _physicianRepository = physicianRepository;
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
            if (!_patientRepository.IsPatientIdValid(patient.Id)) return false;
            _patientRepository.Save(patient);
            return true;
        }

        public bool ConfirmEmailUpdate(string id)
        {
            var patient = _patientRepository.GetByJmbg(id) ?? _patientRepository.GetById(id);
            if (patient.EmailConfirmed) return false;
            patient.EmailConfirmed = true;
            _patientRepository.Update(patient);
            return true;
        }

        public List<FamilyDoctorDto> GetAllPhysicians()
        {
            return _physicianRepository.GetGeneralPractitioners().Select(p => new FamilyDoctorDto()
            {
                SerialNumber = p.SerialNumber,
                Name = p.Name,
                Surname = p.Surname,
                Specialization = Constants.GeneralPractice.Name
            }).ToList();
        }
    }
}