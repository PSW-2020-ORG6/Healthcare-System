using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using Xunit;

namespace GraphicEditorTests.RepositoryTests
{
    public class AppointmentRepositoryTests
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentRepositoryTests()
        {
            // Arrange
            _appointmentRepository = new AppointmentDatabaseSql();
        }

        [Fact]
        public void GetAppointmentBySerialNumber_AppointmentExists_ReturnAppointment()
        {
            // Act
            var appointment = _appointmentRepository.GetById("200001");

            // Assert
            Assert.NotNull(appointment);
            Assert.Equal("200001", appointment.SerialNumber);
        }

        [Fact]
        public void GetAppointmentBySerialNumber_AppointmentDoesntExist_ReturnNull()
        {
            // Act
            var appointment = _appointmentRepository.GetById("96");

            // Assert
            Assert.Null(appointment);
        }

        [Fact]
        public void GetAllAppointments_AppointmentsExist_ReturnAppointments()
        {
            // Act
            var appointments = _appointmentRepository.GetAll();

            // Assert
            Assert.NotEmpty(appointments);
            Assert.NotNull(appointments);
        }
    }
}
