using Model.Accounts;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using WebApplication.Backend.Repositorys.Interfaces;
using Xunit;
using WebApplication.Backend.DTO;
using WebApplication.Backend.Services;

namespace WebApplicationTests
{
    public class AppointmentTests
    {
        String patientIdTrue = "5";
        String patientIdFalse = "4ss";

        String appointmentSerialTrue = "69420";
        String appointmentSerialFalse = "0408";

        List<Appointment> appointments = new List<Appointment>();
        

        bool returnValue;
        private List<DateTime> dates = new List<DateTime>() {
            new DateTime(2020,12,1,10,45,49),
            new DateTime(2020,12,11,10,45,49),
            new DateTime(2020,12,9,10,45,49)
        };

        List<AppointmentDTO> appointmentsDto = new List<AppointmentDTO>();

        AppointmentDTO appointmentDTO =new AppointmentDTO();

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
            Date = new DateTime(1975, 11, 11)
        };
        private Appointment appointment1 = new Appointment()
        {
            Room = new Room("102", 102, new RoomType("Examination room 102")),
            Patient = new Patient("4", "Mika", "Mikic"),
            Physician = new Physician("Hari", "Haler",new Specialization("Neurosurgeon")),
            TimeInterval = new TimeInterval(new DateTime(1975, 11, 11), new DateTime(1975, 11, 11)),
            ProcedureType = new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")),
            Active = true,
            Date = new DateTime(1975, 11, 11)
        };

        [Fact]
        public void Find_Appointments_By_PatientId_Success()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            appointments.Add(appointment);
            appointments.Add(appointment1);
            appointmentsDto = appointmentDTO.ConvertListToAppointmentDTO(appointments);

            stubRepository.Setup(m => m.GetAllAppointmentByPatientId(patientIdTrue)).Returns(appointments);
            AppointmentService service =new AppointmentService(stubRepository.Object);
            appointmentsDto = service.GetAllAppointmentsByPatientId(patientIdTrue);
       
            Assert.NotEmpty(appointmentsDto);
        }


        [Fact]
        public void Find_Appointments_By_PatientId_Failure()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            appointmentsDto = appointmentDTO.ConvertListToAppointmentDTO(appointments);


            stubRepository.Setup(m => m.GetAllAppointmentByPatientId(patientIdFalse)).Returns(appointments);
            AppointmentService service =new AppointmentService(stubRepository.Object);
            appointmentsDto = service.GetAllAppointmentsByPatientId(patientIdFalse);

            Assert.Empty(appointmentsDto);
        }

        [Fact]
        public void Appointment_canceling_sucess()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            stubRepository.Setup(m => m.CancelAppointment(appointmentSerialTrue)).Returns(true);
            WebApplication.Backend.Services.AppointmentsService service =
                new WebApplication.Backend.Services.AppointmentsService(stubRepository.Object);
            returnValue = service.CancelAppointment(appointmentSerialTrue);

            Assert.True(returnValue);
        }

        [Fact]
        public void Appointment_canceling_failure()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            stubRepository.Setup(m => m.CancelAppointment(appointmentSerialFalse)).Returns(false);
            WebApplication.Backend.Services.AppointmentsService service =
                new WebApplication.Backend.Services.AppointmentsService(stubRepository.Object);
            returnValue = service.CancelAppointment(appointmentSerialTrue);

            Assert.False(returnValue);
        }

        [Fact]
        public void User_is_malicious()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            stubRepository.Setup(m => m.GetCancelingDates("0002")).Returns(dates);       
            WebApplication.Backend.Services.AppointmentsService service =
                new WebApplication.Backend.Services.AppointmentsService(stubRepository.Object);
            returnValue = service.IsUserMalicious("0002");

            Assert.True(returnValue);
        }

        [Fact]
        public void User_is_not_malicious()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            stubRepository.Setup(m => m.GetCancelingDates(patientIdFalse)).Returns(new List<DateTime>());
            WebApplication.Backend.Services.AppointmentsService service =
                new WebApplication.Backend.Services.AppointmentsService(stubRepository.Object);
            returnValue = service.IsUserMalicious(patientIdFalse);

            Assert.False(returnValue);
        }

    }
}