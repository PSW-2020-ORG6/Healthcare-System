using Microsoft.AspNetCore.Mvc;


namespace WebApplication.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Microsoft.AspNetCore.Components.Route("patient")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly PatientService patientService;
        public UserController()
        {
            //this.patientService = new PatientService();
        }
        [HttpGet("advancedSearch")]
        public void GetAllFeedbacks()
        {
        }
    }
}
