﻿using Backend.Repository;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HCI_SIMS_PROJEKAT.Backend.Repository
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
    }
}
