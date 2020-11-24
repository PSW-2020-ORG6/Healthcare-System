using Backend.Model.Util;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class Building : Entity
    {
        public string Id { get; set;  }
        public string Name { get; set; }
        public string FloorIds { get; set; }
        public string Color { get; set; }
        public string Shape { get; set; }
    }
}
