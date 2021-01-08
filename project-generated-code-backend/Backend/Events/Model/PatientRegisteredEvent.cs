namespace HealthClinicBackend.Backend.Events.Model
{
    public class PatientRegisteredEvent: Event
    {
        public int PatientAge { get; set; }
    }
}