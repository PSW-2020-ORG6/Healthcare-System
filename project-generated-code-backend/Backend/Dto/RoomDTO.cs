using Backend.Model.Util;

namespace health_clinic_class_diagram.Backend.Dto
{
    public class RoomDTO : Entity
    {
        public string Id { get; set; }
        public string FloorId { get; set; }
    }
}
