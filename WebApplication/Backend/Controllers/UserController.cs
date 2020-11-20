using Microsoft.AspNetCore.Mvc;


namespace WebApplication.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly PatientService patientService;
        public UserController()
        {
            //this.patientService = new PatientService();
        }
        [HttpPost("advancedSearch")]
        public void GetAllFeedbacks(string advancedSearch,bool approximate, string date)
        {
        }
    }
}
