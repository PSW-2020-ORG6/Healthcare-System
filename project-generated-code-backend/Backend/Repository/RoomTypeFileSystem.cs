using Backend.Repository;
using Model.Hospital;
using Newtonsoft.Json;

namespace HCI_SIMS_PROJEKAT.Backend.Repository
{
    class RoomTypeFileSystem : GenericFileSystem<RoomType>, RoomTypeRepository
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
