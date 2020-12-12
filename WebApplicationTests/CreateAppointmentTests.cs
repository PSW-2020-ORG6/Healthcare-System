using Backend.Dto;
using Model.Accounts;
using Model.Schedule;
using Model.Util;
using Moq;
using System;
using System.Collections.Generic;
using WebApplication.Backend.DTO;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Services;
using Xunit;

namespace WebApplicationTests
{
    public class CreateAppointmentTests
    {
        List<Specialization> specializations = new List<Specialization>();
        List<TimeInterval> timeIntervals = new List<TimeInterval>();
        List<Appointment> appointements = new List<Appointment>();

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
            timeIntervals.Add(new TimeInterval { Id = "1234", Start = new DateTime(2020, 12, 11, 08, 00, 00), End = new DateTime(2020, 12, 11, 08, 20, 00) });
            timeIntervals.Add(new TimeInterval { Id = "1235", Start = new DateTime(2020, 12, 11, 08, 20, 00), End = new DateTime(2020, 12, 11, 08, 40, 00) });
            timeIntervals.Add(new TimeInterval { Id = "1235", Start = new DateTime(2020, 12, 11, 08, 40, 00), End = new DateTime(2020, 12, 11, 09, 00, 00) });
            appointements.Add(new Appointment(new Model.Hospital.Room("101", 101, new Model.Hospital.RoomType("Examination room 101")), new Model.Accounts.Physitian("Gojko", "Simic", "600001"), new Model.Accounts.Patient("5", "Jelena", "Tanjic"), new Model.Util.TimeInterval(new DateTime(2020, 12, 5, 08, 00, 00), new DateTime(2020, 12, 5, 08, 00, 00)), new ProcedureType("Operation on patient 0002", 50, new Model.Accounts.Specialization("Neurosurgeon")), new DateTime(2020, 12, 05, 08, 20, 00)));
            appointements.Add( new Appointment(new Model.Hospital.Room("102", 101, new Model.Hospital.RoomType("Examination room 102")), new Model.Accounts.Physitian("Jana", "Jovic", "600002"), new Model.Accounts.Patient("5", "Jelena", "Tanjic"), new Model.Util.TimeInterval(new DateTime(2020, 12, 5, 08, 20, 00), new DateTime(2020, 12, 5, 08, 40, 00)), new ProcedureType("Operation on patient 0003", 60, new Model.Accounts.Specialization("Family doctor")), new DateTime(2020, 12, 20, 08, 20, 00)));

            stubRepositortyApointment.Setup(m => m.GetAppointmentsByDate("20-12-05")).Returns(appointements);
            stubRepositortyTimeInterval.Setup(m => m.GetAllTimeIntervals()).Returns(timeIntervals);
            AppointmentService appointmentService = new AppointmentService(stubRepositortyApointment.Object, stubRepositortyTimeInterval.Object);
            List<TimeInterval> timeiIntervals = appointmentService.GetAllAvailableAppointments("600001",  "Neurologija" , "20-12-05");
         
            Assert.NotNull(timeiIntervals);
        }

        [Fact]
        public void Create_Appointment()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            Appointment appointment = new Appointment(new Model.Hospital.Room("101", 101, new Model.Hospital.RoomType("Examination room 101")), new Model.Accounts.Physitian("Gojko", "Simic", "600001"), new Model.Accounts.Patient("5", "Jelena", "Tanjic"), new Model.Util.TimeInterval(new DateTime(2020, 12, 5, 08, 00, 00), new DateTime(2020, 12, 5, 08, 00, 00)), new ProcedureType("Operation on patient 0002", 50, new Model.Accounts.Specialization("Neurosurgeon")), new DateTime(2020, 12, 05, 08, 20, 00));
            stubRepository.Setup(m=>m.AddAppointment(appointment)).Returns(true);
            AppointmentService service = new AppointmentService(stubRepository.Object);
            bool appointmentAdded  = service.AddAppointment(appointment);
            Assert.True(appointmentAdded);
        }
    }
}
