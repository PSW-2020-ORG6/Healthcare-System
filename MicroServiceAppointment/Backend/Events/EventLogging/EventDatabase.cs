namespace MicroServiceAppointment.Backend.Events.EventLogging
{
    public abstract class EventDatabase<T> : IEventRepository<T> where T : EventLogging.Event
    {
        protected readonly EventDbContext DbContext;

        protected EventDatabase(EventDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract void LogEvent(T @event);
    }
}