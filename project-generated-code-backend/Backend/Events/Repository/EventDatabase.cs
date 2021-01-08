using HealthClinicBackend.Backend.Events.Model;

namespace HealthClinicBackend.Backend.Events.Repository
{
    public abstract class EventDatabase<T> : IEventRepository<T> where T : Event
    {
        protected readonly EventDbContext DbContext;

        protected EventDatabase(EventDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract void LogEvent(T @event);
    }
}