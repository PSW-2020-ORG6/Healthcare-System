using HealthClinicBackend.Backend.Events.EventLogging;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Events.EventBuildingSelection
{
    public class BuildingSelectionEventService : ILogEventService<BuildingSelectionEventParams>
    {
        private readonly IBuildingSelectionEventRepository _buildingSelectionEventRepository;

        public BuildingSelectionEventService(IBuildingSelectionEventRepository buildingSelectionEventRepository)
        {
            _buildingSelectionEventRepository = buildingSelectionEventRepository;
        }

        public void LogEvent(BuildingSelectionEventParams eventParams)
        {
            var buildingSelectionEvent = new BuildingSelectionEvent
            { TimeStamp = DateTime.Now };

            _buildingSelectionEventRepository.LogEvent(buildingSelectionEvent);
        }

        public List<BuildingSelectionEvent> GetAll()
        {
            return _buildingSelectionEventRepository.GetAll();
        }
    }
}