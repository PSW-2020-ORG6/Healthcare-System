using HealthClinicBackend.Backend.Events.EventLogging;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Events.EventRoomSelection
{
    public interface IRoomSelectionEventRepository : IEventRepository<RoomSelectionEvent>
    {
        List<RoomSelectionEvent> GetAll();
    }
}
