using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class FloorFileSystem : GenericFileSystem<Floor>, IFloorRepository
    {
        public FloorFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/floors.txt";
            path = @"./../../data/floors.txt";

        }

        public override Floor Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Floor>(objectStringFormat);
        }

        public List<Floor> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<Floor> GetByBuildingSerialNumber(string buildingSerialNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
