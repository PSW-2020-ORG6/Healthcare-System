using Newtonsoft.Json;
using System;

namespace Backend.Model.Util
{
    public abstract class Entity
    {
        public string SerialNumber { get; set; }

        public Entity()
        {
            SerialNumber = Guid.NewGuid().ToString();
        }

        [JsonConstructor]
        public Entity(string serialNumber)
        {
            SerialNumber = serialNumber;
        }
    }
}