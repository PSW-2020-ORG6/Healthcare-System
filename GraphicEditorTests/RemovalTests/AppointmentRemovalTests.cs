using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.SchedulingService;
using Moq;
using System;
using Xunit;

namespace GraphicEditorTests.RemovalTests
{
    public class AppointmentRemovalTests
    {
        private readonly Appointment appointment;

        public AppointmentRemovalTests()
        {
            TimeInterval timeInterval = new TimeInterval(DateTime.Now, DateTime.Now);
            appointment = new Appointment("200001", "600001", "0002", timeInterval);
        }

        [Fact]
        public void CancelAppointment_AppointmentRemoved_VerifyAction()
        {
            var stubAppointmentRepository = new Mock<IAppointmentRepository>();
            stubAppointmentRepository.Setup(a => a.Delete(It.IsAny<string>()));

            AppointmentService service = new AppointmentService(stubAppointmentRepository.Object);
            service.DeleteAppointment(appointment);

            stubAppointmentRepository.Verify(a => a.Delete(appointment.SerialNumber));
        }
    }
}
