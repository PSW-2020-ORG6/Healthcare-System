using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Util;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> GetAllAddresses();
        Address GetAddressBySerialNumber(string serialNumber);
        List<Address> GetAddressesByStreet(string street);
    }
}
