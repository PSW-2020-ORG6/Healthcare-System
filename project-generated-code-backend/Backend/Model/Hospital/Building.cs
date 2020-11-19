using Backend.Model.Util;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class Building : Entity
    {
        public string Id { get; }
        public string Name { get; set; }
        public List<Floor> Floors { get; set; }
        public string Color { get; set; }
        public string Shape { get; set; }
    }
}
