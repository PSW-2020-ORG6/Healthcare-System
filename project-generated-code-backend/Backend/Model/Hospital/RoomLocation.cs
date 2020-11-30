using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class RoomLocation
    {
        public string Id { get; set; }
        public string Row { get; set; }
        public string Column { get; set; }
        public string RowSpan { get; set; }
        public string ColumnSpan { get; set; }

    }
}
