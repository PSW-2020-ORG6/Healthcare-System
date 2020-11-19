using Backend.Model.Util;
using Model.Hospital;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class Floor : Entity
    {
        public string Id { get; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
