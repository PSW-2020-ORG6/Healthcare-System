using Model.Util;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> GetAllAddresses();
        Address GetAddressBySerialNumber(string serialNumber);
        List<Address> GetAddressesByStreet(string street);
    }
}
