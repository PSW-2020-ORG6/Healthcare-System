using MicroServiceAccount.Backend.Model;
using System.Collections.Generic;

namespace MicroServiceAccount.Backend.Repository.Generic
{
    public interface ISpecializationRepository : IGenericMsAccountRepository<Specialization>
    {
        List<Specialization> GetByName(string name);
    }
}