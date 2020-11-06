using Microsoft.AspNetCore.Mvc;
using Model.Blog;
using System.Collections.Generic;
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

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///calls method for get all feedbacks from feedback table
        ///</summary>
        ///<returns>
        ///list of feedbacks
        ///</returns>
        [HttpGet("all")]
        public List<Feedback> GetAllFeedbacks()
        {
            return feedbackService.GetAllFeedbacks();
        }

        [HttpPost("add")]
        public string AddNewFeedbacк(Feedback feedback)
        {
            return feedbackService.AddNewFeedback(feedback);

        }

        [HttpGet("approved")]
        public List<Feedback> GetApprovedFeedbacks()
        {
            return feedbackService.GetApprovedFeedbacks();
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///calls method for get not approved feedbacks from feedback table
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        [HttpGet("noapproved")]
        public List<Feedback> GetNoApprovedFeedbacks()
        {
            return feedbackService.GetNoApprovedFeedbacks();
        }

    }
}
