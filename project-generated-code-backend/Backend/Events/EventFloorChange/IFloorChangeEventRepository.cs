using HealthClinicBackend.Backend.Events.EventLogging;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Events.EventFloorChange
{
    public interface IFloorChangeEventRepository : IEventRepository<FloorChangeEvent>
    {
        List<FloorChangeEvent> GetAll();
    }
}