using Backend.Model.Util;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class Floor : Entity
    {
        public string Id { get; }
        public string Name { get; set; }
        public string BuildingId { get; set; }
    }
}
