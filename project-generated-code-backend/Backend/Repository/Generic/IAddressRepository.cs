using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        List<Address> GetAddressesByStreet(string street);
    }
}