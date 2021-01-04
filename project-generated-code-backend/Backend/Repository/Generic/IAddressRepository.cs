using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        List<Address> GetAddressesByStreet(string street);
    }
}