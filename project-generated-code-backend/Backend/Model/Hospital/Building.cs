using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Building : Entity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Style { get; set; }
        public List<Floor> Floors { get; set; }

        public Building() : base()
        {
        }

        public Building(string _name, string _color) : base()
        {
            Name = _name;
            Color = _color;
        }
    }
}