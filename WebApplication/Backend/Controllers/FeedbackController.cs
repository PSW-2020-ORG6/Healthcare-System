using Microsoft.AspNetCore.Mvc;
using Model.Blog;
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

        [HttpPost("add")]
        public string AddNewFeedbacк(Feedback feedback)
        {
            return feedbackService.AddNewFeedback(feedback);

        }

    }
}
