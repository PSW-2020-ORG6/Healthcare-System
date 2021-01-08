using HealthClinicBackend.Backend.Events.EventLogging;

namespace HealthClinicBackend.Backend.Events.PatientRegisteredEventLogging
{
    public class PatientRegisteredEventParams : EventParams
    {
        public int PatientAge { get; set; }
    }
}