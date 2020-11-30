using Backend.Dto;
using Model.Accounts;
using Model.Util;
using Moq;
using System;
using WebApplication.Backend.Controllers;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Services;
using Xunit;

namespace WebApplicationTests
{
    public class PatientRegistrationTest
    {
        [Fact]
        public void Patient_not_succesfully_registrate()
        {
            var stubRepository = new Mock<IRegistrationRepository>();
            IRegistrationRepository r = new RegistrationRepository();
            Patient patient = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", new Address { Street = "Glavna 3" }, "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", "223345677", "", "", "female", "ana123", "image", false);
            stubRepository.Setup(m => m.addPatient(patient)).Returns(false);
            RegistrationService service = new RegistrationService(stubRepository.Object);

            bool addedPatient = service.RegisterPatient(patient);

            Assert.False(addedPatient);
        }

        [Fact]
        public void Patient_succesfully_registrate()
        {
            var stubRepository = new Mock<IRegistrationRepository>();
            Patient patient = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", new Address { Street = "Glavna 3" }, "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", "223345677", "", "", "female", "ana123", "image", false);
            stubRepository.Setup(m => m.addPatient(patient)).Returns(true);
            RegistrationService service = new RegistrationService(stubRepository.Object);

            bool addedPatient = service.RegisterPatient(patient);

            Assert.True(addedPatient);
        }


        [Fact]
        public void JmbgIsValidTest()
        {
            var stubRepository = new Mock<IRegistrationRepository>();
            IRegistrationRepository r = new RegistrationRepository();
            Patient p = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", new Address { Street = "Glavna 3" }, "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", "223345677", "", "", "female", "ana123", "image", false);
            stubRepository.Setup(m => m.GetPatientIdById("123")).Returns(p.Id);
            RegistrationService service = new RegistrationService(stubRepository.Object);

            bool hasPatient = service.IsJMBGValid("1234");

            Assert.True(hasPatient);
        }

        [Fact]
        public void JmbgIsNotValidTest()
        {
            var stubRepository = new Mock<IRegistrationRepository>();
            IRegistrationRepository r = new RegistrationRepository();
            Patient p = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", new Address { Street="Glavna 3"}, "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", "223345677", "", "", "female", "ana123", "image", false);
            stubRepository.Setup(m => m.GetPatientIdById("1234")).Returns(p.Id);
            RegistrationService service = new RegistrationService(stubRepository.Object);

            bool hasPatient = service.IsJMBGValid("1234");

            Assert.False(hasPatient);
        }

        [Fact]
        public void ConfirmRegistrationTest()
        {
            var mockRepository = new Mock<IRegistrationRepository>();
            Patient patient = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", new Address { Street = "Glavna 3" }, "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", "223345677", "", "", "female", "ana123", "image", false);
            mockRepository.Setup(m => m.ConfirmgEmailUpdate(patient.Id)).Returns(true);
            RegistrationService service = new RegistrationService(mockRepository.Object);

            bool patientUpdated = service.ConfirmgEmailUpdate(patient.Id);

            Assert.True(patientUpdated);

        }

        [Fact]
        public void SendingMailTest()
        {
            var mockMailService = new Mock<IMailService>();
            var mockController = new Mock<RegistrationController>();
            var controller = new RegistrationController(mockMailService.Object);
            PatientDTO patientDTO = new PatientDTO("21", "Ana", "Anic", "12341112211", DateTime.Now, "0643342345", "ana@gmail.com", new Address { Street = "Glavna 3" }, "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", "223345677", "", "", "female", "ana123", "image", false, false);
            Patient patient = new Patient(patientDTO);
            controller.RegisterPatient(patientDTO);
            mockMailService.Verify(m => m.SendEmailAsync(patient));
        }
    }
}
