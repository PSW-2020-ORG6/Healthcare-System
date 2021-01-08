using HealthClinicBackend.Backend.Events.EventLogging;

namespace HealthClinicBackend.Backend.Events.PatientRegisteredEventLogging
{
    public interface IPatientRegisteredEventRepository : IEventRepository<PatientRegisteredEvent>
    {
    }
}