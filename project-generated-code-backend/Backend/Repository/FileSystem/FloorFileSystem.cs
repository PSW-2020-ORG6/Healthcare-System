﻿using Backend.Repository;
using HealthClinicBackend.Backend.Model.Hospital;
using Newtonsoft.Json;

namespace health_clinic_class_diagram.Backend.Repository
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
    }
}
