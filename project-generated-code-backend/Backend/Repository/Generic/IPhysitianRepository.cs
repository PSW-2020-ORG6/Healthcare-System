using HealthClinicBackend.Backend.Model.Schedule;
using Model.Accounts;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IPhysitianRepository : IGenericRepository<Physician>
    {
        List<Physician> GetByName(string name);
        Physician GetByJmbg(string jmbg);
        List<Physician> GetByProcedureType(ProcedureType procedureType);
        List<Physician> GetGeneralPractitioners();
    }
}