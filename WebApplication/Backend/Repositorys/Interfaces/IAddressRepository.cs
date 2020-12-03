using Model.Util;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> GetAllAddresses();
        Address GetAddressBySerialNumber(string serialNumber);
        List<Address> GetAddressesByStreet(string street);
    }
}
