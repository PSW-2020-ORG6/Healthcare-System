using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Repository.Generic;
//using HealthClinicBackend.Backend.Model.Accounts;
//using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceAccount.Backend.Service
{
    public class UserService
    {
        private readonly IAdminRepository _adminRepository;
        private IPatientRepository _patientRepository;
        private IConfiguration configuration;

        public UserService(IAdminRepository adminRepository, IPatientRepository patientRepository, IConfiguration configuration)
        {
            _adminRepository = adminRepository;
            _patientRepository = patientRepository;
            this.configuration = configuration;
        }

        public Account LogIn(string email, string password)
        {
            Admin admin = _adminRepository.GetAdminByUserNameAndPassword(email, password);
            Patient patient = _patientRepository.GetPatientByUserNameAndPassword(email, password);

            if (admin == null && patient == null)
                return null;
            else if (patient != null)
                return patient;
            else
                return admin;
        }
        public string GetUserType(List<Claim> claims)
        {
            if (claims[1].Value == "False")           
                return "PATIENT";           
            else
                return "ADMIN";
        }
        public string GetUserId(List<Claim>claims)
        {
            return claims[2].Value.ToString();
        }
        public Account AuthenticateUser(Account login)
        {
            return LogIn(login.Email, login.Password);
        }

        public string GenerateJSONWebToken(Account userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Email,userInfo.Email),
            new Claim(JwtRegisteredClaimNames.Typ,userInfo.IsAdmin.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub,userInfo.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken
                (
                    issuer: configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
