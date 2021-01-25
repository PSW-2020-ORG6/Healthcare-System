using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Events.EventBuildingSelection
{
    public class BuildingSelectionEventController
    {
        private BuildingSelectionEventService buildingSelectionEventService;

        public BuildingSelectionEventController()
        {
            buildingSelectionEventService = new BuildingSelectionEventService();
        }

        public void LogEvent(BuildingSelectionEventParams eventParams)
        {
            buildingSelectionEventService.LogEvent(eventParams);
        }

        public List<BuildingSelectionEvent> GetAll()
        {
            return buildingSelectionEventService.GetAll();
        }
    }
}