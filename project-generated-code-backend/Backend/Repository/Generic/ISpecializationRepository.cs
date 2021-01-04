using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface ISpecializationRepository : IGenericRepository<Specialization>
    {
        List<Specialization> GetByName(string name);
    }
}