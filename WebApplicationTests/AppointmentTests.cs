using Model.Schedule;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Backend.Repositorys.Interfaces;
using Xunit;

namespace WebApplicationTests
{
    public class AppointmentTests
    {
        String patientIdTrue = "5";
        String patientIdFalse = "4ss";
        List<Appointment> appointments = new List<Appointment>();
        Appointment appointment = new Appointment(new Model.Hospital.Room("101", 101, new Model.Hospital.RoomType("Examination room 101")), new Model.Accounts.Physitian("Gojko", "Simic", "600001"), new Model.Accounts.Patient("5", "Jelena", "Tanjic"), new Model.Util.TimeInterval(new DateTime(1975, 11, 11), new DateTime(1975, 11, 11)), new ProcedureType("Operation on patient 0002", 50, new Model.Accounts.Specialization("Neurosurgeon")), true, new DateTime(1975, 11, 11));


        [Fact]
        public void Find_Appointments_By_PatientId_Success()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            bool result;
            appointments.Add(appointment);

            stubRepository.Setup(m => m.GetAllAppointmentByPatientId(patientIdTrue)).Returns(appointments);
            WebApplication.Backend.Services.AppointmentsService service = new WebApplication.Backend.Services.AppointmentsService(stubRepository.Object);
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
            WebApplication.Backend.Services.AppointmentsService service = new WebApplication.Backend.Services.AppointmentsService(stubRepository.Object);
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
