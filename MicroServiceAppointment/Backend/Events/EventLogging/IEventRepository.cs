namespace MicroServiceAppointment.Backend.Events.EventLogging
{
    public interface IEventRepository<in T> where T : EventLogging.Event
    {
        void LogEvent(T @event);
    }
}