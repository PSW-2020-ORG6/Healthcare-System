using Moq;
using System;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using WebApplication.Backend.Controllers;
using WebApplication.Backend.Services;
using Xunit;

namespace WebApplicationTests
{
    public class PatientRegistrationTests
    {
        private Patient patient = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com",
            new Address {Street = "Glavna 3"}, "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin",
            "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", "223345677", "", "", "female", "ana123", "image",
            false);

        [Fact]
        public void Patient_not_successfully_registered()
        {
            var patientRepository = new Mock<IPatientRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();

            patientRepository.Setup(m => m.IsPatientIdValid(patient.Id)).Returns(false);
            RegistrationService service = new RegistrationService(patientRepository.Object, physicianRepository.Object);

            bool addedPatient = service.RegisterPatient(patient);

            Assert.False(addedPatient);
            patientRepository.Verify(mock => mock.Save(It.IsAny<Patient>()), Times.Never);
        }

        [Fact]
        public void Patient_successfully_registered()
        {
            var patientRepository = new Mock<IPatientRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();

            patientRepository.Setup(m => m.IsPatientIdValid(patient.Id)).Returns(true);
            RegistrationService service = new RegistrationService(patientRepository.Object, physicianRepository.Object);

            bool addedPatient = service.RegisterPatient(patient);

            Assert.True(addedPatient);
            patientRepository.Verify(mock => mock.Save(It.IsAny<Patient>()), Times.Once);
        }

        [Fact]
        public void Confirm_registration()
        {
            var patientRepository = new Mock<IPatientRepository>();
            var physicianRepository = new Mock<IPhysicianRepository>();

            patientRepository.Setup(m => m.GetByJmbg(It.IsAny<string>()))
                .Returns(new Patient {SerialNumber = "123", Id = "123", EmailConfirmed = false});

            RegistrationService service = new RegistrationService(patientRepository.Object, physicianRepository.Object);
            bool patientUpdated = service.ConfirmEmailUpdate(patient.Id);

            Assert.True(patientUpdated);
            patientRepository.Verify(m => m.Update(new Patient()
                {SerialNumber = "123", Id = "123", EmailConfirmed = true}));
        }

        [Fact]
        public void Sending_Mail()
        {
            var registrationService = new Mock<RegistrationService>();
            var mailService = new Mock<IMailService>();
            mailService.Setup(a => a.SendEmail(patient));

            var controller = new RegistrationController(registrationService.Object, mailService.Object);

            controller.SendMail(patient);

            mailService.Verify(m => m.SendEmail(patient));
        }
    }
}