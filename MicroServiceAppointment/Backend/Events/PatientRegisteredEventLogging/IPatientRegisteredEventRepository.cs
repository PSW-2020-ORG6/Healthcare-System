using MicroServiceAppointment.Backend.Events.EventLogging;

namespace MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging
{
    public interface IPatientRegisteredEventRepository : IEventRepository<PatientRegisteredEvent>
    {
    }
}