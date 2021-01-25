using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Events.EventFloorChange
{
    public class FloorChangeEventController
    {
        private FloorChangeEventService floorChangeEventService;

        public FloorChangeEventController()
        {
            floorChangeEventService = new FloorChangeEventService();
        }

        public void LogEvent(FloorChangeEventParams eventParams)
        {
            floorChangeEventService.LogEvent(eventParams);
        }

        public List<FloorChangeEvent> GetAll()
        {
            return floorChangeEventService.GetAll();
        }
    }
}