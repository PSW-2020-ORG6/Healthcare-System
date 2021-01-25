using HealthClinicBackend.Backend.Events.EventLogging;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Events.EventBuildingSelection
{
    public class BuildingSelectionEventService : ILogEventService<BuildingSelectionEventParams>
    {
        private IBuildingSelectionEventRepository _buildingSelectionEventRepository;

        public BuildingSelectionEventService(IBuildingSelectionEventRepository buildingSelectionEventRepository)
        {
            _buildingSelectionEventRepository = buildingSelectionEventRepository;
        }

        public void LogEvent(BuildingSelectionEventParams eventParams)
        {
            var buildingSelectionEvent = new BuildingSelectionEvent()
            {
                TimeStamp = DateTime.Now,
                UsernameSerialNbr = eventParams.UsernameSerialNbr,
                BuildingSerialNbr = eventParams.BuildingSerialNbr
            };

            _buildingSelectionEventRepository.LogEvent(buildingSelectionEvent);
        }

        public List<BuildingSelectionEvent> GetAll()
        {
            return _buildingSelectionEventRepository.GetAll();
        }
    }
}