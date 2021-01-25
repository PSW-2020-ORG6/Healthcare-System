using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Events.EventRoomSelection
{
    public class RoomSelectionEventController
    {
        private RoomSelectionEventService roomSelectionEventService;

        public RoomSelectionEventController()
        {
            roomSelectionEventService = new RoomSelectionEventService();
        }

        public void LogEvent(RoomSelectionEventParams eventParams)
        {
            roomSelectionEventService.LogEvent(eventParams);
        }

        public List<RoomSelectionEvent> GetAll()
        {
            return roomSelectionEventService.GetAll();
        }
    }
}
