using HealthClinicBackend.Backend.Model.Util;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        List<Address> GetAddressesByStreet(string street);
    }
}