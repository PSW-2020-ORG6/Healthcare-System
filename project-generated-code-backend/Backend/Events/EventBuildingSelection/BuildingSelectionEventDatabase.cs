using HealthClinicBackend.Backend.Events.EventLogging;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Events.EventBuildingSelection
{
    public class BuildingSelectionEventDatabase : EventDatabase<BuildingSelectionEvent>, IBuildingSelectionEventRepository
    {
        public BuildingSelectionEventDatabase(EventDbContext dbContext) : base(dbContext)
        {
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