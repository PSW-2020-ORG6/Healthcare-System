using HealthClinicBackend.Backend.Events.EventLogging;

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
    }
}