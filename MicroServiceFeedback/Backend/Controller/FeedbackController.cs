using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using MicroServiceFeedback.Backend.Dto;
using MicroServiceFeedback.Backend.Model;
using MicroServiceFeedback.Backend.Service;

namespace MicroServiceFeedback.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("feedbackMicroservice")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _feedbackService;

        public FeedbackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        /// <summary>
        ///calls method for get all feedbacks from feedback table
        ///</summary>
        ///<returns>
        ///list of feedbacks
        ///</returns>
        ///      
        [Authorize]
        [HttpGet("all")]
        public List<FeedbackDto> GetAllFeedbacks()
        {
            return _feedbackService.GetAllFeedbacks();
        }

        /// <summary>
        ///calls method for adding new feedback in feedback table
        ///</summary>
        ///<returns>
        ///information about sucess in string format
        ///</returns>
        ///
        [Authorize]
        [HttpPost("add")]
        public IActionResult AddNewFeedbacк(FeedbackDto feedbackDTO)
        {
            if (feedbackDTO.IsApprovalValid() && feedbackDTO.IsCorrectText())
            {
                _feedbackService.AddNewFeedback(new Feedback(feedbackDTO));
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        ///calls method for get approved feedbacks from feedback table
        ///</summary>
        ///<returns>
        ///list of approved feedbacks
        ///</returns>
        [Authorize]
        [HttpGet("approved")]
        public List<FeedbackDto> GetApprovedFeedbacks()
        {
            return _feedbackService.GetApprovedFeedbacks();
        }

        /// <summary>
        ///calls method for get disapproved feedbacks from feedback table
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        [Authorize]
        [HttpGet("disapproved")]
        public List<FeedbackDto> GetDisapprovedFeedbacks()
        {
            return _feedbackService.GetDisapprovedFeedbacks();
        }

        /// <summary>
        ///calls method for set na value of attribute Approved
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
         [Authorize]

        [HttpPut("approve")]
        public IActionResult ChangeStatusFeedback(FeedbackDto feedbackDTO)
        {
            if (feedbackDTO.IsApprovalValid() && feedbackDTO.IsCorrectText())
            {
                _feedbackService.ChangeStatusFeedback(feedbackDTO);
                return Ok();
            }
            return BadRequest();
        }
    }
}