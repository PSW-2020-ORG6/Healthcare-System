using HealthClinicBackend.Backend.Events.EventLogging;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Events.EventRoomSelection
{
    public class RoomSelectionEventDatabase : EventDatabase<RoomSelectionEvent>, IRoomSelectionEventRepository
    {
        public RoomSelectionEventDatabase(EventDbContext dbContext) : base(dbContext)
        {
        }

        public override void LogEvent(RoomSelectionEvent @event)
        {
            DbContext.RoomSelectionEvents.Add(@event);
            DbContext.SaveChanges();
        }

        public List<RoomSelectionEvent> GetAll()
        {
            foreach (RoomSelectionEvent room in DbContext.RoomSelectionEvents.ToList())
                DbContext.Entry(room).Reload();
            return DbContext.RoomSelectionEvents.ToList();
        }
    }
}