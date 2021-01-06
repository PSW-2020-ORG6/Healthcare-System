using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Services
{
    public class UserService
    {
        private readonly IAdminRepository _adminRepository;
        private IPatientRepository _patientRepository;
        
        public UserService(IAdminRepository adminRepository,IPatientRepository patientRepository)
        {
            _adminRepository = adminRepository;
            _patientRepository=patientRepository;
        }

       

        public Account LogIn(string email, string password)
        {
            
            Admin admin = _adminRepository.GetAdminByUserNameAndPassword(email,password);
            Patient patient = _patientRepository.GetPatientByUserNameAndPassword(email,password);

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
            {
                return "PATIENT";
            }
            else
            {
                return "ADMIN";
            }
        }
        public string GetUserId(List<Claim>claims)
        {
            return claims[2].Value.ToString();
        }
    }
}
