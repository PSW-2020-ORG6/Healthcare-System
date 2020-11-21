using Model.Schedule;

namespace HealthClinic.Message
{
    internal class StartExamMessage
    {
        public Appointment Appointment { get; internal set; }
    }
}