using Model.Hospital;
using Newtonsoft.Json;
using System;

namespace HealthClinic.Backend.Model.Hospital
{
    public class RoomBedType : RoomType
    {
        public RoomBedType(string name) : base(name)
        {
        }

        [JsonConstructor]
        public RoomBedType(String serialNumber, string name) : base(serialNumber, name)
        {
        }

    }
}
