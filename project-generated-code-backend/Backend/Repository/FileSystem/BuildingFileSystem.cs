using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class BuildingFileSystem : GenericFileSystem<Building>, IBuildingRepository
    {
        public BuildingFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/buildings.txt";
            path = @"./../../data/buildings.txt";

        }
        public override Building Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Building>(objectStringFormat);
        }

        public List<Building> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Building GetBySerialNumber(string serialNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
