using HealthClinicBackend.Backend.Events.EventLogging;

namespace HealthClinicBackend.Backend.Events.EventBuildingSelection
{
    public class BuildingSelectionEventParams : EventParams
    {
        public string UsernameSerialNbr { get; set; }
        public string BuildingSerialNbr { get; set; }
    }
}