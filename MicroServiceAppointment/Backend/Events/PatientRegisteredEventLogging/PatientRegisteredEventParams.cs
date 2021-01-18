using MicroServiceAppointment.Backend.Events.EventLogging;

namespace MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging
{
    public class PatientRegisteredEventParams : EventParams
    {
        public int PatientAge { get; set; }
    }
}