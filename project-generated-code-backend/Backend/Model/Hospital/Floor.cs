using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Floor : Entity
    {
        public string Name { get; set; }
        [ForeignKey("Building")] public string BuildingSerialNumber { get; set; }
        public Building Building { get; set; }
        public List<Room> Rooms { get; set; }

        public Floor() : base()
        {
        }
    }
}