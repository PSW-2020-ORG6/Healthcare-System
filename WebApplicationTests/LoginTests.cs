using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Repository.Generic;
using MicroServiceAccount.Backend.Service;
using Microsoft.IdentityModel.JsonWebTokens;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Xunit;

namespace WebApplicationTests
{
    public class LoginTests
    {
        String patientEmailTrue = "maddybarr@mail.com";
        String patientPasswordTrue = "123456";
        String adminEmailTrue = "a";
        String adminPasswordTrue = "b";
        Patient patientAccountTrue = new Patient("1", "maddybarr@mail.com", "123456", false);
        Admin adminAccountTrue = new Admin("1", "a", "b", true);

        [Fact]
        public void GetUserTypePatientTest()
        {
            var stubAdminRepository = new Mock<IAdminRepository>();
            var stubPatientRepository = new Mock<IPatientRepository>();
            UserService userService = new UserService(stubAdminRepository.Object, stubPatientRepository.Object);
            bool resultIsUserTypeCorrect;
            List<Claim> claimsPatient = new List<Claim>()
          {
            new Claim(JwtRegisteredClaimNames.Email,patientAccountTrue.Email.ToString()),
            new Claim(JwtRegisteredClaimNames.Typ,patientAccountTrue.IsAdmin.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub,patientAccountTrue.Id.ToString())
            };


            stubPatientRepository.Setup(m => m.GetPatientByUserNameAndPassword(patientEmailTrue, patientPasswordTrue)).Returns(patientAccountTrue);

            String resultUserType = userService.GetUserType(claimsPatient);
            if (resultUserType != "PATIENT")
            {
                resultIsUserTypeCorrect = false;
            }
            else
            {
                resultIsUserTypeCorrect = true;
            }
            Assert.True(resultIsUserTypeCorrect);
        }

        [Fact]
        public void GetUserTypeAdminTest()
        {
            var stubAdminRepository = new Mock<IAdminRepository>();
            var stubPatientRepository = new Mock<IPatientRepository>();
            UserService userService = new UserService(stubAdminRepository.Object, stubPatientRepository.Object);
            bool resultIsUserTypeCorrect;
            List<Claim> claimsAdmin = new List<Claim>()
          {
            new Claim(JwtRegisteredClaimNames.Email,adminAccountTrue.Email),
            new Claim(JwtRegisteredClaimNames.Typ,adminAccountTrue.IsAdmin.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub,adminAccountTrue.SerialNumber)
            };

            stubAdminRepository.Setup(m => m.GetAdminByUserNameAndPassword(adminEmailTrue, adminPasswordTrue)).Returns((Admin)adminAccountTrue);

            String resultUserType = userService.GetUserType(claimsAdmin);
            if (resultUserType == "ADMIN")
            {
                resultIsUserTypeCorrect = true;
            }
            else
            {
                resultIsUserTypeCorrect = false;
            }
            Assert.True(resultIsUserTypeCorrect);
        }

    }
}
