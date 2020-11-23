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
        public void Test1()
        {
            var mockRepository = new Mock<IRegistrationRepository>();
            //mockRepository.Setup(m => )
            RegistrationService service = new RegistrationService(new RegistrationRepository());

           // bool l = service.RegisterPatient(new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", "Glavna 3", "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", 223345677, "", "", "female", "ana123", false));
           // bool l = service.RegisterPatient(new Patient("4", "Ana", "Anic", "143", DateTime.Now, "0643342345", "ana@gmail.com", "Glavna 3", "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", 223345677, "", "", "female", "ana123", false));

            //Assert.False(l);
        }

        [Fact]
        public void Test2()
        {
            RegistrationService service = new RegistrationService(new RegistrationRepository());

            // bool l = service.RegisterPatient(new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", "Glavna 3", "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", 223345677, "", "", "female", "ana123", false));
           // bool l = service.RegisterPatient(new Patient("4", "Ana", "Anic", "143", DateTime.Now, "0643342345", "ana@gmail.com", "Glavna 3", "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", 223345677, "", "", "female", "ana123", false));

           // Assert.False(l);
        }


        [Fact]
        public void JmbgIsValidTest()
        {
            var stubRepository = new Mock<IRegistrationRepository>();
            var patient = new Patient();
            IRegistrationRepository r = new RegistrationRepository();
            Patient p = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", "Glavna 3", "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", 223345677, "", "", "female", "ana123", "image", false);
            stubRepository.Setup(m => m.GetPatientIdById("123")).Returns(p.Id);
            RegistrationService service = new RegistrationService(stubRepository.Object);

            bool hasPatient = service.IsJMBGValid("1234");

            Assert.True(hasPatient);
        }

        [Fact]
        public void JmbgIsNotValidTest()
        {
            var stubRepository = new Mock<IRegistrationRepository>();
            var patient = new Patient();
            IRegistrationRepository r = new RegistrationRepository();
            Patient p = new Patient("2", "Ana", "Anic", "1234", DateTime.Now, "0643342345", "ana@gmail.com", "Glavna 3", "Jovan", "Beograd", "Savski venac", "Srbija", "Srpsko", "Srbin", "Doktor", "Ruma", "Ruma", "Srbija", "employed", "merried", 223345677, "", "", "female", "ana123", "image", false);
            stubRepository.Setup(m => m.GetPatientIdById("1234")).Returns(p.Id);
            RegistrationService service = new RegistrationService(stubRepository.Object);

            bool hasPatient = service.IsJMBGValid("1234");

            Assert.False(hasPatient);
        }
    }
}
