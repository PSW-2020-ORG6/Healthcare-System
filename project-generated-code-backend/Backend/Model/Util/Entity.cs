using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Model.Util
{
    public abstract class Entity
    {
        [Key]
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