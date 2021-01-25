using HealthClinicBackend.Backend.Events.EventLogging;
using System;

namespace HealthClinicBackend.Backend.Events.EventRoomSelection
{
    public class RoomSelectionEventService : ILogEventService<RoomSelectionEventParams>
    {
        private readonly IRoomSelectionEventRepository _roomSelectionEventRepository;

        public RoomSelectionEventService(IRoomSelectionEventRepository roomSelectionEventRepository)
        {
            _roomSelectionEventRepository = roomSelectionEventRepository;
        }

        public void LogEvent(RoomSelectionEventParams eventParams)
        {
            var roomSelectionEvent = new RoomSelectionEvent
            { TimeStamp = DateTime.Now };

            _roomSelectionEventRepository.LogEvent(roomSelectionEvent);
        }
    }
}