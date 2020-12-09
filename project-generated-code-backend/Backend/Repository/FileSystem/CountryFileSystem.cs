using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    class CountryFileSystem : GenericFileSystem<Country>, ICountryRepository
    {
        public CountryFileSystem()
        {
            path = @"./../../data/countries.txt";
        }
        public override Country Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Country>(objectStringFormat);
        }
    }
}
