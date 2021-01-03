using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Floor : Entity
    {
        public string Name { get; set; }
        [ForeignKey("Building")] public string BuildingSerialNumber { get; set; }
        public List<Room> Rooms { get; set; }

        public Floor() : base()
        {
        }

        public Floor(string serialNumber, string name, string buildingSerialNumber) : base()
        {
            Name = name;
            BuildingSerialNumber = buildingSerialNumber;
        }

        public Floor(Building building, int nameNumber) : base()
        {
            Name = Constants.FloorNames[nameNumber];
            BuildingSerialNumber = building.SerialNumber;
            Rooms = new List<Room>();
        }
    }
}