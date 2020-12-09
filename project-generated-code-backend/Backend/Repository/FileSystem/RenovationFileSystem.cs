using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class RenovationFileSystem : GenericFileSystem<Renovation>, IRenovationRepository
    {
        public RenovationFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/rooms.txt";
            path = @"./../../data/renovations.txt";

        }

        public List<Renovation> GetRenovationsByRoom(Room room)
        {
            List<Renovation> renovations = new List<Renovation>();
            foreach (Renovation renovation in GetAll())
            {
                if (room.Equals(renovation.Room))
                {
                    renovations.Add(renovation);
                }
            }
            return renovations;
        }

        public override Renovation Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Renovation>(objectStringFormat);
        }
    }
}
