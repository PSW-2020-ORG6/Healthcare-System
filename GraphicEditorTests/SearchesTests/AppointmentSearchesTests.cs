using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using HealthClinicBackend.Backend.Service.SchedulingService;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace GraphicEditorTests
{
    public class AppointmentSearchesTests
    {
        private readonly Appointment appointment;
        private readonly List<Appointment> appointments;

        public AppointmentSearchesTests()
        {
            TimeInterval timeInterval = new TimeInterval(DateTime.Now, DateTime.Now);
            appointment = new Appointment("200001", "600001", "0002", timeInterval);
            appointments = new List<Appointment>
            {
                appointment
            };
        }

        [Fact]
        public void SearchAppointmentsByDate_AppointmentsFound_ReturnAppointments()
        {
            var stubAppointmentRepository = new Mock<IAppointmentRepository>();
            stubAppointmentRepository.Setup(a => a.GetAppointmentsByDate(appointment.TimeInterval.Start)).Returns(appointments);

            AppointmentService service = new AppointmentService(stubAppointmentRepository.Object);
            List<Appointment> foundAppointments = service.GetAppointmentsByDate(appointment.TimeInterval.Start);

            Assert.NotEmpty(foundAppointments);
        }

        [Fact]
        public void SearchAppointmentsByDate_AppointmentsNotFound_ReturnEmpty()
        {
            var stubAppointmentRepository = new Mock<IAppointmentRepository>();
            stubAppointmentRepository.Setup(a => a.GetAppointmentsByDate(DateTime.Today)).Returns(new List<Appointment>());

            AppointmentService service = new AppointmentService(stubAppointmentRepository.Object);
            List<Appointment> foundAppointments = service.GetAppointmentsByDate(DateTime.Today);

            Assert.Empty(foundAppointments);
        }

        [Fact]
        public void SearchAppointmentsByPhysicianSerialNumber_AppointmentsFound_ReturnAppointments()
        {
            var stubAppointmentRepository = new Mock<IAppointmentRepository>();
            stubAppointmentRepository.Setup(a => a.GetByPhysicianSerialNumber(appointment.PhysicianSerialNumber)).Returns(appointments);

            AppointmentService service = new AppointmentService(stubAppointmentRepository.Object);
            List<Appointment> foundAppointments = service.GetByPhysicianSerialNumber(appointment.PhysicianSerialNumber);

            Assert.NotEmpty(foundAppointments);
        }

        [Fact]
        public void SearchAppointmentsByPhysicianSerialNumber_AppointmentsNotFound_ReturnEmpty()
        {
            var stubAppointmentRepository = new Mock<IAppointmentRepository>();
            stubAppointmentRepository.Setup(a => a.GetByPhysicianSerialNumber("625261")).Returns(new List<Appointment>());

            AppointmentService service = new AppointmentService(stubAppointmentRepository.Object);
            List<Appointment> foundAppointments = service.GetByPhysicianSerialNumber("625261");

            Assert.Empty(foundAppointments);
        }


        [Fact]
        public void SearchAllAppointments_AppointmentsFound_ReturnAppointments()
        {
            var stubAppointmentRepository = new Mock<IAppointmentRepository>();
            stubAppointmentRepository.Setup(a => a.GetAll()).Returns(appointments);

            AppointmentService service = new AppointmentService(stubAppointmentRepository.Object);
            List<Appointment> foundAppointments = service.GetAll();

            Assert.NotEmpty(foundAppointments);
        }

        [Fact]
        public void SearchAllAppointments_AppointmentsNotFound_ReturnEmpty()
        {
            var stubAppointmentRepository = new Mock<IAppointmentRepository>();
            stubAppointmentRepository.Setup(a => a.GetAll()).Returns(new List<Appointment>());

            AppointmentService service = new AppointmentService(stubAppointmentRepository.Object);
            List<Appointment> foundAppointments = service.GetAll();

            Assert.Empty(foundAppointments);
        }
    }
}