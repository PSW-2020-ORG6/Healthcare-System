using HealthClinicBackend.Backend.Events.EventLogging;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Events.EventFloorChange
{
    public class FloorChangeEventService : ILogEventService<FloorChangeEventParams>
    {
        private readonly IFloorChangeEventRepository _floorChangeEventRepository;

        public FloorChangeEventService(IFloorChangeEventRepository floorChangeEventRepository)
        {
            _floorChangeEventRepository = floorChangeEventRepository;
        }

        public void LogEvent(FloorChangeEventParams eventParams)
        {
            var floorChnageEvent = new FloorChangeEvent
            {
                TimeStamp = DateTime.Now,
                UsernameSerialNbr = eventParams.UsernameSerialNbr,
                BuildingSerialNbr = eventParams.BuildingSerialNbr,
                FloorSerialNbr = eventParams.FloorSerialNbr
            };

            _floorChangeEventRepository.LogEvent(floorChnageEvent);
        }

        public List<FloorChangeEvent> GetAll()
        {
            return _floorChangeEventRepository.GetAll();
        }
    }
}