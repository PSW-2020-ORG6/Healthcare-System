using Backend.Model.Util;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class Building : Entity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Floor> Floors { get; set; }
        public string Color { get; set; }
        public string Shape { get; set; }

        public Building(string _id, string _name, List<Floor> _floors, string _color, string _shape)
        {
            Id = _id;
            Name = _name;
            Floors = _floors;
            Color = _color;
            Shape = _shape;
        } 

        public Building()
        {

        }
    }
}
