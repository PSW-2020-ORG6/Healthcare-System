using Newtonsoft.Json;
using System;

namespace Backend.Model.Util
{
    public abstract class Entity
    {
        private string serialNumber;

        public string SerialNumber { get => serialNumber; set => this.serialNumber = value; }

        [JsonConstructor]
        public Entity(string serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        public Entity()
        {
            this.serialNumber = Guid.NewGuid().ToString();
        }


    }
}
