using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Repositorys
{
    public class AddressRepository : IAddressRepository
    {
        private readonly HealthClinicBackend.Backend.Repository.Generic.IAddressRepository _addressRepository;

        public AddressRepository(HealthClinicBackend.Backend.Repository.Generic.IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public List<Address> GetAllAddresses()
        {
            return _addressRepository.GetAll();
        }

        public Address GetAddressBySerialNumber(string serialNumber)
        {
            return _addressRepository.GetById(serialNumber);
        }

        public List<Address> GetAddressesByStreet(string street)
        {
            return _addressRepository.GetAddressesByStreet(street);
        }
    }
}