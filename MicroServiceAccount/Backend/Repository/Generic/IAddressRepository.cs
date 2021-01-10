using MicroServiceAccount.Backend.Model.Util;
using System.Collections.Generic;

namespace MicroServiceAccount.Backend.Repository.Generic
{
    public interface IAddressRepository : IGenericMsAccountRepository<Address>
    {
        List<Address> GetAddressesByStreet(string street);
        Address GetById(string id);
        List<Address> GetAll();
    }
}