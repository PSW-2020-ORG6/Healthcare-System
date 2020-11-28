using Backend.Repository;
using Model.Util;
using Newtonsoft.Json;

namespace HCI_SIMS_PROJEKAT.Backend.Repository
{
    class CountryFileSystem : GenericFileSystem<Country>, CountryRepository
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
