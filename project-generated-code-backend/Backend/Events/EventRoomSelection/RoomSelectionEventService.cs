using HealthClinicBackend.Backend.Events.EventLogging;
using System;
using System.Collections.Generic;

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
            {
                TimeStamp = DateTime.Now,
                UsernameSerialNbr = eventParams.UsernameSerialNbr,
                FloorSerialNbr = eventParams.FloorSerialNbr,
                RoomSerialNbr = eventParams.RoomSerialNbr
            };

            _roomSelectionEventRepository.LogEvent(roomSelectionEvent);
        }

        public List<RoomSelectionEvent> GetAll()
        {
            return _roomSelectionEventRepository.GetAll();
        }
    }
}