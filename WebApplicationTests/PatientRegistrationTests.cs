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
    public class PatientRegistrationTests
    {
        private Patient patient = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", new Address { Street = "Glavna 3" }, "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", "223345677", "", "", "female", "ana123", "image", false);

        [Fact]
        public void Patient_not_succesfully_registrate()
        {
            var stubRepository = new Mock<IRegistrationRepository>();
            stubRepository.Setup(m => m.IsPatientIdValid(patient.Id)).Returns(false);
            stubRepository.Setup(m => m.AddPatient(patient)).Returns(false);
            RegistrationService service = new RegistrationService(stubRepository.Object);

            bool addedPatient = service.RegisterPatient(patient);

            Assert.False(addedPatient);
        }

        [Fact]
        public void Patient_succesfully_registrate()
        {
            var stubRepository = new Mock<IRegistrationRepository>();
            stubRepository.Setup(m => m.IsPatientIdValid(patient.Id)).Returns(true);
            stubRepository.Setup(m => m.AddPatient(patient)).Returns(true);
            RegistrationService service = new RegistrationService(stubRepository.Object);

            bool addedPatient = service.RegisterPatient(patient);

            Assert.True(addedPatient);
        }

        [Fact]
        public void Confirm_registration()
        {
            var mockRepository = new Mock<IRegistrationRepository>();
            mockRepository.Setup(m => m.ConfirmEmailUpdate(patient.Id)).Returns(true);
            RegistrationService service = new RegistrationService(mockRepository.Object);

            bool patientUpdated = service.ConfirmEmailUpdate(patient.Id);

            Assert.True(patientUpdated);
        }

        [Fact]
        public void Sending_Mail()
        {
            var mockMailService = new Mock<IMailService>();
            mockMailService.Setup(a => a.SendEmail(patient));
            var controller = new RegistrationController(mockMailService.Object);
            controller.SendMail(patient);
            mockMailService.Verify(m => m.SendEmail(patient));
        }
    }
}
