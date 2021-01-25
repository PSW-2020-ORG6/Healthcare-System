using HealthClinicBackend.Backend.Events.EventLogging;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Events.EventFloorChange
{
    public class FloorChangeEventDatabase : EventDatabase<FloorChangeEvent>, IFloorChangeEventRepository
    {
        public FloorChangeEventDatabase(EventDbContext dbContext) : base(dbContext)
        {
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