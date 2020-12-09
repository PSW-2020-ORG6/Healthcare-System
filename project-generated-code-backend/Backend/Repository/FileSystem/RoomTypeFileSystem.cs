using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    class RoomTypeFileSystem : GenericFileSystem<RoomType>, IRoomTypeRepository
    {
        public RoomTypeFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/room_types.txt";
            path = @"./../../data/room_types.txt";
        }
        public override RoomType Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<RoomType>(objectStringFormat);
        }
    }
}
