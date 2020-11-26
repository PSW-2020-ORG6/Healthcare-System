using Model.Accounts;
using Moq;
using System;
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
            Patient patient = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", "Glavna 3", "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", "223345677", "", "", "female", "ana123", "image", false);
            stubRepository.Setup(m => m.addPatient(patient)).Returns(false);
            RegistrationService service = new RegistrationService(stubRepository.Object);

            bool addedPatient = service.RegisterPatient(patient);

            Assert.False(addedPatient);
        }

        [Fact]
        public void Patient_succesfully_registrate()
        {
            var stubRepository = new Mock<IRegistrationRepository>();
            Patient patient = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", "Glavna 3", "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", "223345677", "", "", "female", "ana123", "image", false);
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
            Patient p = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", "Glavna 3", "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", "223345677", "", "", "female", "ana123", "image", false);
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
            Patient p = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", "Glavna 3", "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", "223345677", "", "", "female", "ana123", "image", false);
            stubRepository.Setup(m => m.GetPatientIdById("1234")).Returns(p.Id);
            RegistrationService service = new RegistrationService(stubRepository.Object);

            bool hasPatient = service.IsJMBGValid("1234");

            Assert.False(hasPatient);
        }
    }
}
