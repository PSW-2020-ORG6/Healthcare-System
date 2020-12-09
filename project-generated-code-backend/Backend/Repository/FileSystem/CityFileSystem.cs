using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
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
