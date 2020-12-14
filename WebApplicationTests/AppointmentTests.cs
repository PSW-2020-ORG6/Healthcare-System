﻿using Model.Accounts;
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

        String appointmentSerialTrue = "69420";
        String appointmentSerialFalse = "0408";

        List<Appointment> appointments = new List<Appointment>();

        bool returnValue;

        private Appointment appointment = new Appointment()
        {
            Room = new Room("101", 101, new RoomType("Examination room 101")),
            Patient = new Patient("5", "Jelena", "Tanjic"),
            Physician = new Physician("Gojko", "Simic", "600001"),
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

        public void Patient_is_not_malicious()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            stubRepository.Setup(m => m.IsUserMalicious(patientIdTrue)).Returns(false);
            WebApplication.Backend.Services.AppointmentsService service =
                new WebApplication.Backend.Services.AppointmentsService(stubRepository.Object);
            returnValue = service.IsUserMalicious(patientIdTrue);

            Assert.False(returnValue);
        }


    }
}