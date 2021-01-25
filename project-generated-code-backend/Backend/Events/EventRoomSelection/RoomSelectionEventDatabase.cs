using HealthClinicBackend.Backend.Events.EventLogging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Events.EventRoomSelection
{
    public class RoomSelectionEventDatabase : EventDatabase<RoomSelectionEvent>, IRoomSelectionEventRepository
    {
        private static EventDbContext dbContext = new EventDbContext(new DbContextOptionsBuilder<EventDbContext>()
                .UseNpgsql("userid=postgres;server=localhost;port=5432;database=healthcare-system-events;password=root;Integrated Security = true;pooling=true;")
                .Options);

        public RoomSelectionEventDatabase() : base(dbContext)
        {
        }

        public RoomSelectionEventDatabase(EventDbContext dbContext) : base(dbContext)
        {
            DbContext.Set<RoomSelectionEvent>().AsNoTracking();
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