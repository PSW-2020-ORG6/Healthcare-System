using HealthClinicBackend.Backend.Events.EventLogging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Events.EventBuildingSelection
{
    public class BuildingSelectionEventDatabase : EventDatabase<BuildingSelectionEvent>, IBuildingSelectionEventRepository
    {
        private static EventDbContext dbContext = new EventDbContext(new DbContextOptionsBuilder<EventDbContext>()
            .UseNpgsql("userid=postgres;server=localhost;port=5432;database=healthcare-system-events;password=root;Integrated Security = true;pooling=true;")
            .Options);

        public BuildingSelectionEventDatabase() : base(dbContext)
        {
        }

        public BuildingSelectionEventDatabase(EventDbContext dbContext) : base(dbContext)
        {
            DbContext.Set<BuildingSelectionEvent>().AsNoTracking();
        }

        public override void LogEvent(BuildingSelectionEvent @event)
        {
            DbContext.BuildingSelectionEvents.Add(@event);
            DbContext.SaveChanges();
        }

        public List<BuildingSelectionEvent> GetAll()
        {
            foreach (BuildingSelectionEvent building in DbContext.BuildingSelectionEvents.ToList())
                DbContext.Entry(building).Reload();
            return DbContext.BuildingSelectionEvents.ToList();
        }
    }
}