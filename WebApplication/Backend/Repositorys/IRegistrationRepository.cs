using Model.Accounts;
using System;

namespace WebApplication.Backend.Repositorys
{
    /// <summary>
    /// This interface for class RegistrationRepository
    /// </summary>
    public interface IRegistrationRepository
    {
        public bool addPatient(Patient patient);
        public String GetPatientId(string idd);
        public String GetPatientIdById(string patientId);
        public bool ConfirmgEmailUpdate(string patientId);
    }
}
