using Backend.Repository;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HCI_SIMS_PROJEKAT.Backend.Repository
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
