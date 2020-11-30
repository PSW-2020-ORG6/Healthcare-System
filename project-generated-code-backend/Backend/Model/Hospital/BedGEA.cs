using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Model.Util;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class BedGEA : Entity
    {
        public string BuildingSerialNumber { get; set; }
        public string FloorSerialNumber { get; set; }
        public string RoomSerialNumber { get; set; }
        public string PatientID { get; set; }
        public string Name { get; set; }
    }
}
