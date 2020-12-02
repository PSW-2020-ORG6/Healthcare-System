using Model.Accounts;
using System;

namespace WebApplication.Backend.Repositorys
{
    /// <summary>
    /// This interface for class RegistrationRepository
    /// </summary>
    public interface IRegistrationRepository
    {
        public bool AddPatient(Patient patient);
        public String GetPatientId(string idd);
        public bool IsPatientIdValid(string patientId);
        public bool ConfirmEmailUpdate(string patientId);
    }
}
