using HealthClinicBackend.Backend.Model.Accounts;
using Model.Accounts;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        List<Patient> GetPatientsByPhysitian(Physician physician);
        Patient GetByJmbg(string jbmg);
        bool IsPatientIdValid(string id);
        List<Patient> GetByName(string name);
    }
}