namespace MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging
{
    public class PatientRegisteredEvent: EventLogging.Event
    {
        public int PatientAge { get; set; }
    }
}