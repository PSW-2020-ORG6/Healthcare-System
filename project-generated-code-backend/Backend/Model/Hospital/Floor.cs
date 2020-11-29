using Backend.Model.Util;
using Model.Hospital;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class Floor : Entity
    {   
        public string Id { get; }
        public string Name { get; set; }
        public string BuildingName { get; set; }

        public Floor(string _id, string _name)
        {
            Id = _id;
            Name = _name;
        }

        public Floor()
        {

        }
    }
}
