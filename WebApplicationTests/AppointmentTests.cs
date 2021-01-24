using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Model.Util;
using MicroServiceAccount.Backend.Repository.Generic;
using MicroServiceAppointment.Backend.Dto;
using MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging;
using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Model.Hospital;
using MicroServiceAppointment.Backend.Repository.Generic;
using MicroServiceAppointment.Backend.Service;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using WebApplication;
using Xunit;

namespace AppointmentTests
{
    public class AppointmentTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webFactory;
        String appointmentSerialTrue = "69420";
        String appointmentSerialInactive = "69430";

        List<Appointment> appointments = new List<Appointment>();
        bool returnValue;
        private Appointment appointmentInactive = new Appointment()
        {
            Room = new Room("101", 101, new RoomType("Examination room 101")),
            Patient = new Patient("5", "Jelena", "Tanjic"),
            Physician = new Physician("Gojko", "Simic", new Specialization("Neurosurgeon")),
            TimeInterval = new TimeInterval(new DateTime(1975, 11, 11), new DateTime(1975, 11, 11)),
            ProcedureType = new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")),
            Active = false,
            Date = new DateTime(1975, 11, 11),
            SerialNumber = "69430"
        };

        private List<DateTime> datesMalicious = new List<DateTime>()
        {
            new DateTime(2020, 12, 1, 10, 45, 49),
            new DateTime(2021, 1, 20, 10, 45, 49),
            new DateTime(2021, 1, 21, 10, 45, 49)
        };

        private List<DateTime> datesNotMalicious = new List<DateTime>()
        {
            new DateTime(2020, 12, 1, 10, 45, 49),
            new DateTime(2020, 2, 20, 10, 45, 49),
            new DateTime(2020, 1, 21, 10, 45, 49)
        };

        List<AppointmentDto> appointmentsDto = new List<AppointmentDto>();

        AppointmentDto appointmentDTO = new AppointmentDto();

        private Appointment appointment = new Appointment()
        {
            Room = new Room("101", 101, new RoomType("Examination room 101")),
            Patient = new Patient("5", "Jelena", "Tanjic"),
            Physician = new Physician("Gojko", "Simic", new Specialization("Neurosurgeon")),
            TimeInterval = new TimeInterval(new DateTime(1975, 11, 11), new DateTime(1975, 11, 11)),
            ProcedureType = new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")),
            Active = true,
            Date = new DateTime(1975, 11, 11),
            SerialNumber = "69420"
        };

        private List<Appointment> appointmentsTestList = new List<Appointment>
        {
            new Appointment()
            {
                Room = new Room("101", 101, new RoomType("Examination room 101")),
                Patient = new Patient("5", "Jelena", "Tanjic"),
                Physician = new Physician("Gojko", "Simic", "600001"),
                TimeInterval = new TimeInterval(new DateTime(1975, 11, 11), new DateTime(1975, 11, 11)),
                ProcedureType = new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")),
                Active = true,
                Date = new DateTime(1975, 11, 11),
                SerialNumber = "694201",
                DateOfCanceling = "12/10/2020 10:47:28 PM"
            },
            new Appointment()
            {
                Room = new Room("101", 101, new RoomType("Examination room 101")),
                Patient = new Patient("5", "Jelena", "Tanjic"),
                Physician = new Physician("Gojko", "Simic", "600001"),
                TimeInterval = new TimeInterval(new DateTime(1975, 11, 11), new DateTime(1975, 11, 11)),
                ProcedureType = new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")),
                Active = true,
                Date = new DateTime(1975, 11, 11),
                SerialNumber = "694202",
                DateOfCanceling = "12/12/2020 10:47:28 PM"
            },
            new Appointment()
            {
                Room = new Room("101", 101, new RoomType("Examination room 101")),
                Patient = new Patient("5", "Jelena", "Tanjic"),
                Physician = new Physician("Gojko", "Simic", "600001"),
                TimeInterval = new TimeInterval(new DateTime(1975, 11, 11), new DateTime(1975, 11, 11)),
                ProcedureType = new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")),
                Active = true,
                Date = new DateTime(1975, 11, 11),
                SerialNumber = "694203",
                DateOfCanceling = "12/11/2020 10:47:28 PM"
            }
        };

        private Appointment appointment1 = new Appointment()
        {
            Room = new Room("102", 102, new RoomType("Examination room 102")),
            Patient = new Patient("4", "Mika", "Mikic"),
            Physician = new Physician("Hari", "Haler", new Specialization("Neurosurgeon")),
            TimeInterval = new TimeInterval(new DateTime(1975, 11, 11), new DateTime(1975, 11, 11)),
            ProcedureType = new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")),
            Active = true,
            Date = new DateTime(1975, 11, 11)
        };

        [Fact]
        public void Appointment_canceling_success()
        {
            var specializationRepository = new Mock<ISpecializationRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();
            var patientRepository = new Mock<IPatientRepository>();
            var addressRepository = new Mock<IAddressRepository>();

            appointmentRepository.Setup(m => m.GetById("69420")).Returns(appointment);

            AppointmentService service = new AppointmentService(specializationRepository.Object,
                appointmentRepository.Object, physicianRepository.Object, patientRepository.Object, addressRepository.Object);

            returnValue = service.CancelAppointment(appointmentSerialTrue);

            Assert.True(returnValue);
            appointmentRepository.Verify(mock => mock.Update(It.IsAny<Appointment>()));
        }
        [Fact]
        public void Appointment_canceling_failure()
        {
            var specializationRepository = new Mock<ISpecializationRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();
            var patientRepository = new Mock<IPatientRepository>();
            var addressRepository = new Mock<IAddressRepository>();

            appointmentRepository.Setup(m => m.GetById(appointmentSerialInactive)).Returns(appointmentInactive);

            AppointmentService service = new AppointmentService(specializationRepository.Object,
                appointmentRepository.Object, physicianRepository.Object, patientRepository.Object, addressRepository.Object);

            returnValue = service.CancelAppointment(appointmentSerialInactive);

            Assert.False(returnValue);
        }

        [Fact]
        public void User_is_malicious()
        {
            var specializationRepository = new Mock<ISpecializationRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();
            var patientRepository = new Mock<IPatientRepository>();
            var addressRepository = new Mock<IAddressRepository>();


            appointmentRepository.Setup(m => m.GetByPatientIdCanceledDates("0002")).Returns(datesMalicious);

            AppointmentService service = new AppointmentService(specializationRepository.Object,
                appointmentRepository.Object, physicianRepository.Object, patientRepository.Object, addressRepository.Object);

            returnValue = service.IsUserMalicious("0002");

            Assert.True(returnValue);
        }

        [Fact]
        public void User_is_not_malicious()
        {
            var specializationRepository = new Mock<ISpecializationRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();
            var patientRepository = new Mock<IPatientRepository>();
            var addressRepository = new Mock<IAddressRepository>();


            appointmentRepository.Setup(m => m.GetByPatientIdCanceledDates("0002")).Returns(datesNotMalicious);

            AppointmentService service = new AppointmentService(specializationRepository.Object,
                appointmentRepository.Object, physicianRepository.Object, patientRepository.Object, addressRepository.Object);

            returnValue = service.IsUserMalicious("0002");

            Assert.False(returnValue);
        }

        public AppointmentTests(WebApplicationFactory<Startup> factory)
        {
            webFactory = factory;
        }

        public static IEnumerable<object[]> Appointment =>
            new List<object[]>
            {
                new object[] {"1", HttpStatusCode.OK},
                new object[] {null, HttpStatusCode.BadRequest}
            };

        [Theory]
        [MemberData(nameof(Appointment))]
        public async void Find_Appointments_By_PatientId(string id, HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/appointment/allAppointmentsByPatientId/" + id);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }
        
        [Theory]
        [MemberData(nameof(Appointment))]
        public async void Find_PastAppointments_By_PatientId_Failure(string id, HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/appointment/allAppointmentsByPatientIdPast/" + id);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(Appointment))]
        public async void Find_AppointmentsWithSurvey_By_PatientId(string id, HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/appointment/allAppointmentsWithSurvey/" + id);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }

        [Theory]
        [MemberData(nameof(Appointment))]
        public async void Find_AppointmentsWithoutSurvey_By_PatientId(string id, HttpStatusCode exceptedStatusCode)
        {
            HttpClient client = webFactory.CreateClient();

            HttpResponseMessage responseMessage =
                await client.GetAsync("/#/appointment/allAppointmentsWithoutSurvey/" + id);

            responseMessage.StatusCode.CompareTo(exceptedStatusCode);
        }
    }
}