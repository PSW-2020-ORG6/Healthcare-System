using Microsoft.AspNetCore.Mvc;
using WebApplication.Backend.Services;

namespace WebApplication.Backend.Controllers
{
    [Route("feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService feedbackService;
        public FeedbackController()
        {
            this.feedbackService = new FeedbackService();
        }

    }
}
