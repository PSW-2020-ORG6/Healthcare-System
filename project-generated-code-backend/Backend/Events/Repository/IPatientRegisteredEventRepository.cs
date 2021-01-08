using HealthClinicBackend.Backend.Events.Model;

namespace HealthClinicBackend.Backend.Events.Repository
{
    public interface IPatientRegisteredEventRepository : IEventRepository<PatientRegisteredEvent>
    {
    }
}