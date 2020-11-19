using Backend.Repository;
using health_clinic_class_diagram.Backend.Model.Hospital;
using Newtonsoft.Json;

namespace health_clinic_class_diagram.Backend.Repository
{
    public class BuildingFileSystem : GenericFileSystem<Building>, BuildingRepository
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
    }
}
