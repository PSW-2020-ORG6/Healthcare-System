using Backend.Model.Util;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class Building : Entity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Style { get; set; }
        public List<Floor> Floors { get; set; }


        public Building(string _name, string _color)
        {
            Name = _name;
            Color = _color;
        }

        public Building()
        {

        }
    }
}
