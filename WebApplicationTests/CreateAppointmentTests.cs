using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using WebApplication;
using WebApplication.Backend.Controllers;
using WebApplication.Backend.DTO;
using WebApplication.Backend.Repositorys.Interfaces;
using WebApplication.Backend.Services;
using Xunit;

namespace WebApplicationTests
{
    public class CreateAppointmentTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        List<Specialization> specializations = new List<Specialization>();
        List<TimeInterval> timeIntervals = new List<TimeInterval>();
        List<Appointment> appointements = new List<Appointment>();
        List<AppointmentWithRecommendationDTO> appointmentWithRecommendationDTO = new List<AppointmentWithRecommendationDTO>();
        TimeIntervalDTO timeIntervalDTO = new TimeIntervalDTO();
        private readonly WebApplicationFactory<Startup> webFactory;

        public CreateAppointmentTests(WebApplicationFactory<Startup> factory)
        {
            webFactory = factory;
            timeIntervals.Add(new TimeInterval { Id = "1234", Start = new DateTime(2020, 12, 11, 08, 00, 00), End = new DateTime(2020, 12, 11, 08, 20, 00) });
            timeIntervals.Add(new TimeInterval { Id = "1235", Start = new DateTime(2020, 12, 11, 08, 20, 00), End = new DateTime(2020, 12, 11, 08, 40, 00) });
            timeIntervals.Add(new TimeInterval { Id = "1235", Start = new DateTime(2020, 12, 11, 08, 40, 00), End = new DateTime(2020, 12, 11, 09, 00, 00) });
            appointements.Add(new Appointment(new Room("101", 101, new RoomType("Examination room 101")), new Physician("Gojko", "Simic", "600001"), new Patient("5", "Jelena", "Tanjic"), new TimeInterval(new DateTime(2021, 12, 5, 08, 00, 00), new DateTime(2021, 12, 5, 08, 00, 00)), new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")), new DateTime(2021, 12, 05, 08, 20, 00)));
            appointements.Add(new Appointment(new Room("102", 101, new RoomType("Examination room 102")), new Physician("Jana", "Jovic", "600002"), new Patient("5", "Jelena", "Tanjic"), new TimeInterval(new DateTime(2021, 12, 5, 08, 20, 00), new DateTime(2021, 12, 5, 08, 40, 00)), new ProcedureType("Operation on patient 0003", 60, new Specialization("Family doctor")), new DateTime(2021, 12, 05, 08, 20, 00)));
            appointmentWithRecommendationDTO.Add(new AppointmentWithRecommendationDTO("2021-12-22", "6001", timeIntervalDTO.ConvertListToTimeIntervalDTO(timeIntervals), "Gojko Simic"));
        }

        public static IEnumerable<object[]> AppointmentDate =>
            new List<object[]>
            {
                    new object[] { "60001","surgeon","2020-12-25" ,HttpStatusCode.OK },
                    new object[] { null,null,null,HttpStatusCode.BadRequest }
            };

        public static IEnumerable<object[]> Specialization =>
            new List<object[]>
            {
                        new object[] { "60001" ,HttpStatusCode.OK },
                        new object[] { null,HttpStatusCode.BadRequest }
            };

        [Fact]
        public void Find_specializations()
        {
            var stubRepositorty = new Mock<ISpecializationRepository>();
            specializations.Add(new Specialization { Name = "Neurologija" });
            specializations.Add(new Specialization { Name = "Oftalmologija" });
            stubRepositorty.Setup(m => m.GetAllSpecializations()).Returns(specializations);
            AppointmentService appointmentService = new AppointmentService(stubRepositorty.Object);

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

        [Fact]
        public void Create_Appointment_With_Recommendation()
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
        public void Get_all_appointment()
        {
            var mockAppointmentRepository = new Mock<IAppointmentRepository>();
            mockAppointmentRepository.Setup(a => a.GetAppointmentsByDate("2021-12-5")).Returns(appointements);
            
            var service = new AppointmentService(mockAppointmentRepository.Object);
            List<TimeIntervalDTO> result = service.GetAllAvailableAppointments("600001", "ophthalmologist", "2021-12-5");

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_all_appointment_date()
        {
            var mockAppointmentRepository = new Mock<IAppointmentRepository>();
            mockAppointmentRepository.Setup(a => a.GetAppointmentsByDate("2021-12-5")).Returns(appointements);
            mockAppointmentRepository.Setup(a => a.GetAppointmentsByDate("2021-12-23")).Returns(appointements);

            var service = new AppointmentService(mockAppointmentRepository.Object);
            List<AppointmentWithRecommendationDTO> result = service.AppointmentRecomendation("600001", "ophthalmologist", new string[2] { "2021-12-5", "2021-12-23" });

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_all_appointment_physician()
        {
            var mockAppointmentRepository = new Mock<IAppointmentRepository>();
            mockAppointmentRepository.Setup(a => a.GetAppointmentsByDate("2021-12-5")).Returns(appointements);
            mockAppointmentRepository.Setup(a => a.GetAppointmentsByDate("2021-12-23")).Returns(appointements);

            var service = new AppointmentService(mockAppointmentRepository.Object);
            List<AppointmentWithRecommendationDTO> result = service.AppointmentRecomendationWithPhysicianPriority("600001", "ophthalmologist", new string[2] { "2021-12-5", "2021-12-23" });

            Assert.NotNull(result);
        }

        [Theory]
        [MemberData(nameof(Specialization))]
        public async void Get_specializtions(string specialization, HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage = await client.GetAsync("/#/appointment/specializations/" + specialization);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(AppointmentDate))]
        public async void Get_available_appointment(string id, string spec, string date, HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage = await client.GetAsync("/#/appointment/GetAllAvailableAppointments/" + id + "/" + spec + "/" + date);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(AppointmentDate))]
        public async void Get_available_appointment_with_recommandation_physician(string id, string spec, string date, HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage = await client.GetAsync("/#/appointment/appointmentsWithPhysicianPriority/" + id + "/" + spec + "/" + date);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(AppointmentDate))]
        public async void Get_available_appointment_with_recommandation_date(string id, string spec, string date, HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("/#/appointment/appointmentsWithReccomendation/" + id + "/" + spec + "/" + date);
            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }
    }
}
