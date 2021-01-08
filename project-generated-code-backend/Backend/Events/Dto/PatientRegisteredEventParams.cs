namespace HealthClinicBackend.Backend.Events.Dto
{
    public class PatientRegisteredEventParams : EventParams
    {
        public int PatientAge { get; set; }
    }
}