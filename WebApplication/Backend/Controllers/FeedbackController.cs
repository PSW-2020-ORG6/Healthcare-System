using health_clinic_class_diagram.Backend.Dto;
using Microsoft.AspNetCore.Mvc;
using Model.Blog;
using System.Collections.Generic;
using WebApplication.Backend.Services;

namespace WebApplication.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
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

        ///Repovic Aleksa RA-52-2017
        /// <summary>
        ///calls method for adding new feedback in feedback table
        ///</summary>
        ///<returns>
        ///information about sucess in string format
        ///</returns>
        [HttpPost("add")]
        public IActionResult AddNewFeedbacк(FeedbackDTO feedbackDTO)
        {
            if (feedbackDTO.IsApprovalValid() && feedbackDTO.IsCorrectText())
            {
                feedbackService.AddNewFeedback(new Feedback(feedbackDTO));
                return Ok();
            }
            return BadRequest();

        }

        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///calls method for get approved feedbacks from feedback table
        ///</summary>
        ///<returns>
        ///list of approved feedbacks
        ///</returns>

        [HttpGet("approved")]
        public List<Feedback> GetApprovedFeedbacks()
        {
            return feedbackService.GetApprovedFeedbacks();
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///calls method for get disapproved feedbacks from feedback table
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        [HttpGet("disapproved")]
        public List<Feedback> GetDisapprovedFeedbacks()
        {
            return feedbackService.GetDisapprovedFeedbacks();
        }
        ///Marija Vucetic 
        /// <summary>
        ///calls method for set na value of attribute Approved
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        [HttpPut("approve")]
        public IActionResult ApproveFeedback(FeedbackDTO feedbackDTO)
        {
            if (feedbackDTO.IsApprovalValid() && feedbackDTO.IsCorrectText())
            {
                feedbackService.ApproveFeedback(feedbackDTO);
                return Ok();
            }
            return BadRequest();
        }
    }
}
