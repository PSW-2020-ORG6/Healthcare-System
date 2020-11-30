using Backend.Model.Util;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class Building : Entity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Shape { get; set; }

        public Building( string _name, string _color, string _shape)
        {
            Name = _name;
            Color = _color;
            Shape = _shape;
        } 

        public Building()
        {

        }
    }
}
