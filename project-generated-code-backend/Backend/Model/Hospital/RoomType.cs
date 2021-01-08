using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;
using System;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class RoomType : Entity
    {
        public string Name { get; set; }

        public RoomType() : base()
        {
        }

        public RoomType(string name) : base()
        {
            Name = name;
        }

        [JsonConstructor]
        public RoomType(String serialNumber, string name) : base(serialNumber)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is RoomType other && this.Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "name: " + Name;
        }
    }
}