using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class BuildingLocation
    {
        public string row { get; set; }
        public string column { get; set; }
        public string rowSpan { get; set; }
        public string columnSpan { get; set; }

    }
}
