using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class AddressFileSystem : GenericFileSystem<Address>, IAddressRepository
    {
        public AddressFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/addresses.txt";
            path = @"./../../data/addresses.txt";
        }
        public override Address Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Address>(objectStringFormat);
        }

        public List<Address> GetAddressesByStreet(string street)
        {
            throw new System.NotImplementedException();
        }
    }
}
