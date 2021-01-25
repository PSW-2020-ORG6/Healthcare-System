using HealthClinicBackend.Backend.Events.EventLogging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Events.EventFloorChange
{
    public class FloorChangeEventDatabase : EventDatabase<FloorChangeEvent>, IFloorChangeEventRepository
    {
        private static EventDbContext dbContext = new EventDbContext(new DbContextOptionsBuilder<EventDbContext>()
                .UseNpgsql("userid=postgres;server=localhost;port=5432;database=healthcare-system-events;password=root;Integrated Security = true;pooling=true;")
                .Options);

        public FloorChangeEventDatabase() : base(dbContext)
        {
        }

        public FloorChangeEventDatabase(EventDbContext dbContext) : base(dbContext)
        {
            DbContext.Set<FloorChangeEvent>().AsNoTracking();
        }

        public override void LogEvent(FloorChangeEvent @event)
        {
            DbContext.FloorChangeEvents.Add(@event);
            DbContext.SaveChanges();
        }

        public List<FloorChangeEvent> GetAll()
        {
            foreach (FloorChangeEvent floor in DbContext.FloorChangeEvents.ToList())
                DbContext.Entry(floor).Reload();
            return DbContext.FloorChangeEvents.ToList();
        }
    }
}