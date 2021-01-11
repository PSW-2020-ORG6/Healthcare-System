using Moq;
using System;
using Xunit;
using MicroServiceAccount.Backend.Service;
using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Model.Util;
using MicroServiceAccount.Backend.Repository.Generic;
using MicroServiceAccount.Backend.Services.Interfaces;
using MicroServiceAccount.Backend.Controllers;

namespace WebApplicationTests
{
    public class PatientRegistrationTests
    {
        private Patient patient = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com",
            new Address { Street = "Glavna 3" }, "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin",
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
                .Returns(new Patient { SerialNumber = "123", Id = "123", EmailConfirmed = false });

            RegistrationService service = new RegistrationService(patientRepository.Object, physicianRepository.Object);
            bool patientUpdated = service.ConfirmEmailUpdate(patient.Id);

            Assert.True(patientUpdated);
            patientRepository.Verify(m => m.Update(new Patient()
            { SerialNumber = "123", Id = "123", EmailConfirmed = true }));
        }
    }
}