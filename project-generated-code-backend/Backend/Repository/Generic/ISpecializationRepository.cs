using HealthClinicBackend.Backend.Model.Accounts;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface ISpecializationRepository : IGenericRepository<Specialization>
    {
        List<Specialization> GetByName(string name);
    }
}