using HealthClinicBackend.Backend.Events.EventLogging;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Events.EventBuildingSelection
{
    public interface IBuildingSelectionEventRepository : IEventRepository<BuildingSelectionEvent>
    {
        List<BuildingSelectionEvent> GetAll();
    }
}
