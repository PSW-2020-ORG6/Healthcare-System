using Model.Accounts;
using System;

namespace WebApplication.Backend.Repositorys
{
    public interface IRegistrationRepository
    {
        public bool addPatient(Patient patient);
        public String GetPatientId(string idd);
        public String GetPatientIdById(string patientId);
        public bool ConfirmgEmailUpdate(string patientId);
    }
}
