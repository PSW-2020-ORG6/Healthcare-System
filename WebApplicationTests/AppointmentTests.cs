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

namespace WebApplicationTests
{
    public class AppointmentTests
    {
        String patientIdTrue = "5";
        String patientIdFalse = "4ss";
        List<Appointment> appointments = new List<Appointment>();

        private Appointment appointment = new Appointment()
        {
            Room = new Room("101", 101, new RoomType("Examination room 101")),
            Patient = new Patient("5", "Jelena", "Tanjic"),
            Physician = new Physician("Gojko", "Simic", "600001"),
            TimeInterval = new TimeInterval(new DateTime(1975, 11, 11), new DateTime(1975, 11, 11)),
            ProcedureType = new ProcedureType("Operation on patient 0002", 50, new Specialization("Neurosurgeon")),
            Active = true,
            Date = new DateTime(1975, 11, 11)
        };

        [Fact]
        public void Find_Appointments_By_PatientId_Success()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            bool result;
            appointments.Add(appointment);

            stubRepository.Setup(m => m.GetAllAppointmentByPatientId(patientIdTrue)).Returns(appointments);
            WebApplication.Backend.Services.AppointmentsService service =
                new WebApplication.Backend.Services.AppointmentsService(stubRepository.Object);
            appointments = service.GetAllAppointmentsByPatientId(patientIdTrue);
            if (appointments.Count == 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            Assert.True(result);
        }


        [Fact]
        public void Find_Appointments_By_PatientId_Failure()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            bool result;

            stubRepository.Setup(m => m.GetAllAppointmentByPatientId(patientIdFalse)).Returns(appointments);
            WebApplication.Backend.Services.AppointmentsService service =
                new WebApplication.Backend.Services.AppointmentsService(stubRepository.Object);
            appointments = service.GetAllAppointmentsByPatientId(patientIdFalse);
            if (appointments.Count != 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            Assert.False(result);
        }
    }
}