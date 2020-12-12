using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using Model.Accounts;
using Moq;
using System;
using System.Collections.Generic;
using WebApplication.Backend.DTO;
using WebApplication.Backend.Repositorys.Interfaces;
using WebApplication.Backend.Services;
using Xunit;

namespace WebApplicationTests
{
    public class CreateAppointmentTests
    {
        List<Specialization> specializations = new List<Specialization>();
        List<TimeInterval> timeIntervals = new List<TimeInterval>();
        List<Appointment> appointements = new List<Appointment>();

        public CreateAppointmentTests()
        {
            timeIntervals.Add(new TimeInterval { Id = "1234", Start = new DateTime(2020, 12, 11, 08, 00, 00), End = new DateTime(2020, 12, 11, 08, 20, 00) });
            timeIntervals.Add(new TimeInterval { Id = "1235", Start = new DateTime(2020, 12, 11, 08, 20, 00), End = new DateTime(2020, 12, 11, 08, 40, 00) });
            timeIntervals.Add(new TimeInterval { Id = "1235", Start = new DateTime(2020, 12, 11, 08, 40, 00), End = new DateTime(2020, 12, 11, 09, 00, 00) });
            appointements.Add(new Appointment(new Room("101", 101, new RoomType("Examination room 101")), new Physician("Gojko", "Simic", "600001"), new Patient("5", "Jelena", "Tanjic"), new TimeInterval(new DateTime(2020, 12, 5, 08, 00, 00), new DateTime(2020, 12, 5, 08, 00, 00)), new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")), new DateTime(2020, 12, 05, 08, 20, 00)));
            appointements.Add(new Appointment(new Room("102", 101, new RoomType("Examination room 102")), new Physician("Jana", "Jovic", "600002"), new Patient("5", "Jelena", "Tanjic"), new TimeInterval(new DateTime(2020, 12, 5, 08, 20, 00), new DateTime(2020, 12, 5, 08, 40, 00)), new ProcedureType("Operation on patient 0003", 60, new Specialization("Family doctor")), new DateTime(2020, 12, 05, 08, 20, 00)));
        }

        [Fact]
        public void Find_specializations()
        {
            var stubRepositorty = new Mock<ISpecializationRepository>();
            specializations.Add(new Specialization { Name = "Neurologija" });
            specializations.Add(new Specialization { Name = "Oftalmologija" });
            stubRepositorty.Setup(m => m.GetAllSpecializations()).Returns(specializations);
            AppointmentService appointmentService= new AppointmentService(stubRepositorty.Object);
            List<SpecializationDTO> searchEntityDTOs = appointmentService.GetAllSpecializations();
            Assert.NotNull(searchEntityDTOs);
        }

        [Fact]
        public void Find_TimeIntervals()
        {
            var stubRepositortyApointment = new Mock<IAppointmentRepository>();
            var stubRepositortyTimeInterval = new Mock<ITimeIntervalRepository>();      
            stubRepositortyApointment.Setup(m => m.GetAppointmentsByDate("20-12-05")).Returns(appointements);
            stubRepositortyTimeInterval.Setup(m => m.GetAllTimeIntervals()).Returns(timeIntervals);
            AppointmentService appointmentService = new AppointmentService(stubRepositortyApointment.Object, stubRepositortyTimeInterval.Object);
            List<TimeIntervalDTO> timeiIntervals = appointmentService.GetAllAvailableAppointments("600001", "Neurologija", "20-12-05");

            Assert.NotNull(timeiIntervals);
        }

        [Fact]
        public void Create_Appointment()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            Appointment appointment = new Appointment(new Room("101", 101, new RoomType("Examination room 101")), new Physician("Gojko", "Simic", "600001"), new Patient("5", "Jelena", "Tanjic"), new TimeInterval(new DateTime(2020, 12, 5, 08, 00, 00), new DateTime(2020, 12, 5, 08, 00, 00)), new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")), new DateTime(2020, 12, 05, 08, 20, 00));
            stubRepository.Setup(m => m.AddAppointment(appointment)).Returns(true);
            AppointmentService service = new AppointmentService(stubRepository.Object);
            bool appointmentAdded = service.AddAppointment(appointment);
            Assert.True(appointmentAdded);
        }
    }
}
