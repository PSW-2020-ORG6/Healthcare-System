namespace HealthClinicBackend.Backend.Events.EventLogging
{
    interface ILogEventService<in T> where T : EventParams
    {
        public void LogEvent(T eventParams);
    }
}