using Backend.Model.Util;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class RoomGEA : Entity
    {
        public string Name { get; set; }
        public string FloorName { get; set; }
        public string BuildingName { get; set; }
    }
}
