using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients();
        Patient GetPatientById(string id);
        Patient GetPatientBySerialNumber(string serialNumber);
    }
}
