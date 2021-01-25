namespace HealthClinicBackend.Backend.Events.PatientRegisteredEventLogging
{
    public class PatientAppointmentEvent : EventLogging.Event
    {
        public int TransitionsFromTwoToOneStep { get; set; }
        public int TransitionsFromThreeToTwoStep { get; set; }
        public int TransitionsFromFourToThreeStep { get; set; }
        public string SchedulingDuration { get; set; }
        public bool IsAppointmentScheduled { get; set; }
        public string ChoosenPhysician { get; set; }
        public string ChoosenSpecialization { get; set; }


    }
}
