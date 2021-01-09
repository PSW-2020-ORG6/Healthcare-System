using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using MicroServiceAccount.Backend.Model;
using HealthClinicBackend.Backend.Model.Accounts;
using MicroServiceAccount.Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MicroServiceAccount.Backend.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration configuration;
        private readonly UserService _userService;
        public LoginController(IConfiguration configuration,UserService userService)
        {
            this.configuration = configuration;
            _userService = userService;
        }

        [HttpGet("login/{email}/{password}")]
        public string Login(string email, string password)
        {
            Account login = new Account();
            login.Email = email;
            login.Password = password;

            string response=null;
            var user = _userService.AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = _userService.GenerateJSONWebToken(user);
                response = tokenString;
            }

            return response;
        }
        
        [Authorize]
        [HttpGet("GetUserType")]
        public string GetUserType()
        {
            return _userService.GetUserType((HttpContext.User.Identity as ClaimsIdentity).Claims.ToList());
        }

        [Authorize]
        [HttpGet("GetUserId")]
        public string GetUserId()
        {
            return _userService.GetUserId((HttpContext.User.Identity as ClaimsIdentity).Claims.ToList());
        }

        
    }
}

