using HealthClinicBackend.Backend.Dto;
using Model.Accounts;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;

namespace WebApplication.Backend.Repositorys
{
    /// <summary>
    /// This interface for class RegistrationRepository
    /// </summary>
    public interface IRegistrationRepository : IDisposable
    {
        public bool AddPatient(Patient patient);
        public String GetPatientId(string idd);
        public bool IsPatientIdValid(string patientId);
        public bool ConfirmEmailUpdate(string patientId);
        public List<FamilyDoctorDto> GetAllGeneralPracticePhysicians();
    }
}
