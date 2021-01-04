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
using HealthClinicBackend.Backend.Repository.Generic;
using WebApplication;
using WebApplication.Backend.DTO;
using WebApplication.Backend.Services;
using Xunit;

namespace WebApplicationTests
{
    public class CreateAppointmentTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        List<Specialization> specializations = new List<Specialization>();
        List<TimeInterval> timeIntervals = new List<TimeInterval>();
        List<Appointment> appointements = new List<Appointment>();

        List<AppointmentWithRecommendationDTO> appointmentWithRecommendationDTO =
            new List<AppointmentWithRecommendationDTO>();

        TimeIntervalDTO timeIntervalDTO = new TimeIntervalDTO();
        private readonly WebApplicationFactory<Startup> webFactory;

        public CreateAppointmentTests(WebApplicationFactory<Startup> factory)
        {
            webFactory = factory;
            timeIntervals.Add(new TimeInterval
            {
                Id = "1234", Start = new DateTime(2020, 12, 11, 08, 00, 00),
                End = new DateTime(2020, 12, 11, 08, 20, 00)
            });
            timeIntervals.Add(new TimeInterval
            {
                Id = "1235", Start = new DateTime(2020, 12, 11, 08, 20, 00),
                End = new DateTime(2020, 12, 11, 08, 40, 00)
            });
            timeIntervals.Add(new TimeInterval
            {
                Id = "1235", Start = new DateTime(2020, 12, 11, 08, 40, 00),
                End = new DateTime(2020, 12, 11, 09, 00, 00)
            });
            appointements.Add(new Appointment(new Room("101", 101, new RoomType("Examination room 101")),
                new Physician("Gojko", "Simic", "600001"), new Patient("5", "Jelena", "Tanjic"),
                new TimeInterval(new DateTime(2021, 12, 5, 08, 00, 00), new DateTime(2021, 12, 5, 08, 00, 00)),
                new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")),
                new DateTime(2021, 12, 05, 08, 20, 00)));
            appointements.Add(new Appointment(new Room("102", 101, new RoomType("Examination room 102")),
                new Physician("Jana", "Jovic", "600002"), new Patient("5", "Jelena", "Tanjic"),
                new TimeInterval(new DateTime(2021, 12, 5, 08, 20, 00), new DateTime(2021, 12, 5, 08, 40, 00)),
                new ProcedureType("Operation on patient 0003", 60, new Specialization("Family doctor")),
                new DateTime(2021, 12, 05, 08, 20, 00)));
            appointmentWithRecommendationDTO.Add(new AppointmentWithRecommendationDTO("2021-12-22", "6001",
                timeIntervalDTO.ConvertListToTimeIntervalDTO(timeIntervals), "Gojko Simic"));
        }

        public static IEnumerable<object[]> AppointmentDate =>
            new List<object[]>
            {
                new object[] {"60001", "surgeon", "2020-12-25", HttpStatusCode.OK},
                new object[] {null, null, null, HttpStatusCode.BadRequest}
            };

        public static IEnumerable<object[]> Specialization =>
            new List<object[]>
            {
                new object[] {"60001", HttpStatusCode.OK},
                new object[] {null, HttpStatusCode.BadRequest}
            };

        [Fact]
        public void Find_specializations()
        {
            var specializationRepository = new Mock<ISpecializationRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();
            var patientRepository = new Mock<IPatientRepository>();

            specializations.Add(new Specialization {Name = "Neurologija"});
            specializations.Add(new Specialization {Name = "Oftalmologija"});
            specializationRepository.Setup(m => m.GetAll()).Returns(specializations);

            AppointmentService service = new AppointmentService(specializationRepository.Object,
                appointmentRepository.Object, physicianRepository.Object, patientRepository.Object);

            List<SpecializationDTO> searchEntityDTOs = service.GetAllSpecializations();

            Assert.NotNull(searchEntityDTOs);
        }

        [Fact]
        public void Find_TimeIntervals()
        {
            // TODO: check this test, I think it needs more stubs
            var specializationRepository = new Mock<ISpecializationRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();
            var patientRepository = new Mock<IPatientRepository>();

            appointmentRepository.Setup(m => m.GetAppointmentsByDate(It.IsAny<DateTime>())).Returns(appointements);

            AppointmentService service = new AppointmentService(specializationRepository.Object,
                appointmentRepository.Object, physicianRepository.Object, patientRepository.Object);

            List<TimeIntervalDTO> timeIntervals =
                service.GetAllAvailableAppointments("600001", "Neurologija", "20-12-05");

            Assert.NotNull(timeIntervals);
        }

        [Fact]
        public void Create_Appointment()
        {
            var specializationRepository = new Mock<ISpecializationRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();
            var patientRepository = new Mock<IPatientRepository>();

            AppointmentService service = new AppointmentService(specializationRepository.Object,
                appointmentRepository.Object, physicianRepository.Object, patientRepository.Object);

            Appointment appointment = new Appointment(new Room("101", 101, new RoomType("Examination room 101")),
                new Physician("Gojko", "Simic", "600001"), new Patient("5", "Jelena", "Tanjic"),
                new TimeInterval(new DateTime(2020, 12, 5, 08, 00, 00), new DateTime(2020, 12, 5, 08, 00, 00)),
                new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")),
                new DateTime(2020, 12, 05, 08, 20, 00));
            bool appointmentAdded = service.AddAppointment(appointment);

            Assert.True(appointmentAdded);
            appointmentRepository.Verify(mock => mock.Update(appointment));
        }

        [Fact]
        public void Create_Appointment_With_Recommendation()
        {
            var specializationRepository = new Mock<ISpecializationRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();
            var patientRepository = new Mock<IPatientRepository>();

            appointmentRepository.Setup(m => m.GetAppointmentsByDate(It.IsAny<DateTime>())).Returns(appointements);

            AppointmentService service = new AppointmentService(specializationRepository.Object,
                appointmentRepository.Object, physicianRepository.Object, patientRepository.Object);

            List<TimeIntervalDTO> timeiIntervals =
                service.GetAllAvailableAppointments("600001", "Neurologija", "20-12-05");

            Assert.NotNull(timeiIntervals);
        }

        [Fact]
        public void Get_all_appointment()
        {
            var specializationRepository = new Mock<ISpecializationRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();
            var patientRepository = new Mock<IPatientRepository>();

            appointmentRepository.Setup(m => m.GetAppointmentsByDate(It.IsAny<DateTime>())).Returns(appointements);

            AppointmentService service = new AppointmentService(specializationRepository.Object,
                appointmentRepository.Object, physicianRepository.Object, patientRepository.Object);

            List<TimeIntervalDTO> result =
                service.GetAllAvailableAppointments("600001", "ophthalmologist", "2021-12-5");

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_all_appointment_date()
        {
            var specializationRepository = new Mock<ISpecializationRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();
            var patientRepository = new Mock<IPatientRepository>();

            appointmentRepository.Setup(a => a.GetAppointmentsByDate(It.IsAny<DateTime>())).Returns(appointements);

            AppointmentService service = new AppointmentService(specializationRepository.Object,
                appointmentRepository.Object, physicianRepository.Object, patientRepository.Object);

            var result = service.AppointmentRecomendation("600001", "ophthalmologist",
                new string[2] {"2021-12-5", "2021-12-23"});

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_all_appointment_physician()
        {
            var specializationRepository = new Mock<ISpecializationRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();
            var patientRepository = new Mock<IPatientRepository>();

            appointmentRepository.Setup(a => a.GetAppointmentsByDate(It.IsAny<DateTime>())).Returns(appointements);

            AppointmentService service = new AppointmentService(specializationRepository.Object,
                appointmentRepository.Object, physicianRepository.Object, patientRepository.Object);

            var result = service.AppointmentRecomendation("600001", "ophthalmologist",
                new string[2] {"2021-12-5", "2021-12-23"});

            Assert.NotNull(result);
        }

        [Theory]
        [MemberData(nameof(Specialization))]
        public async void Get_specializtions(string specialization, HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/appointment/specializations/" + specialization);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(AppointmentDate))]
        public async void Get_available_appointment(string id, string spec, string date,
            HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/appointment/GetAllAvailableAppointments/" + id + "/" + spec + "/" + date);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(AppointmentDate))]
        public async void Get_available_appointment_with_recommandation_physician(string id, string spec, string date,
            HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync(
                    "/#/appointment/appointmentsWithPhysicianPriority/" + id + "/" + spec + "/" + date);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(AppointmentDate))]
        public async void Get_available_appointment_with_recommandation_date(string id, string spec, string date,
            HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();
            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/appointment/appointmentsWithReccomendation/" + id + "/" + spec + "/" + date);
            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }
    }
}