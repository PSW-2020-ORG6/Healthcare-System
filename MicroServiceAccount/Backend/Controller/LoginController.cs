using System.Linq;
using System.Security.Claims;
using HealthClinicBackend.Backend.Model.Accounts;
using MicroServiceAccount.Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MicroServiceAccount.Backend.Controllers
{
    [Route("loginMicroservice")]
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
            Account login = new Account()
            {
                Email = email,
                Password = password
            };
            var user =_userService.AuthenticateUser(login);
            if (user != null)
                return _userService.GenerateJSONWebToken(user);
            return null;
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

        //U svrhe testiranja
        [Authorize]
        [HttpGet("GetValue")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {
                "Value1","Value2","Value3"
            };
        }
    }
}

