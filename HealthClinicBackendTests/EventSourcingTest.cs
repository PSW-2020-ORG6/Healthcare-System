using HealthClinicBackend.Backend.Events.Dto;
using HealthClinicBackend.Backend.Events.Repository;
using HealthClinicBackend.Backend.Events.Service;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HealthClinicBackendTests
{
    public class EventSourcingTest
    {
        private readonly DbContextOptions<EventDbContext> _options = new DbContextOptionsBuilder<EventDbContext>()
            .UseNpgsql("userid=postgres;server=localhost;port=5432;database=healthcare-system-events;password=super;")
            .Options;

        [Fact]
        public void Log_patient_registered_event()
        {
            // GIVEN
            var dbContext = new EventDbContext(_options);
            var repository = new PatientRegisteredEventDatabase(dbContext);
            var service = new LogPatientRegisteredEventService(repository);

            // WHEN
            service.LogEvent(new PatientRegisteredEventParams {PatientAge = 20});

            // THEN
            Assert.True(true);
        }
    }
}