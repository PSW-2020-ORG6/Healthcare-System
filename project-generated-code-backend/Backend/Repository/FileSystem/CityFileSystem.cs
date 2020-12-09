using Backend.Repository;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HCI_SIMS_PROJEKAT.Backend.Repository
{
    class CityFileSystem : GenericFileSystem<City>, ICityRepository
    {
        public CityFileSystem()
        {
            path = @"./../../../../project-generated-code-backend/data/cities.txt";
        }
        public override City Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<City>(objectStringFormat);
        }
    }
}
