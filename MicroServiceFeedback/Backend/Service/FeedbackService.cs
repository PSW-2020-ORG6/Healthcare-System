using MicroServiceFeedback.Backend.Dto;
using MicroServiceFeedback.Backend.Model;
using MicroServiceFeedback.Backend.Repository.Generic;
using System;
using System.Collections.Generic;

namespace MicroServiceFeedback.Backend.Service
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class FeedbackService
    {

        private readonly IFeedbackRepository _feedbackRepository;
        private FeedbackDto feedbackDTO = new FeedbackDto();

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        /// <summary>
        ///calls method for get all feedback in feedback table
        ///</summary>
        ///<returns>
        ///list of feedbacks
        ///</returns>
        internal List<FeedbackDto> GetAllFeedbacks()
        {
            return feedbackDTO.ConvertListToFeedbackDTO(_feedbackRepository.GetAll());
        }

        /// <summary>
        ///calls method for get approved feedbacks from feedback table
        ///</summary>
        ///<returns>
        ///list of approved feedbacks
        ///</returns>
        internal List<FeedbackDto> GetApprovedFeedbacks()
        {
            return feedbackDTO.ConvertListToFeedbackDTO(_feedbackRepository.GetApproved());
        }

        /// <summary>
        ///calls method for get disapproved feedback from feedback table
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        internal List<FeedbackDto> GetDisapprovedFeedbacks()
        {
            return feedbackDTO.ConvertListToFeedbackDTO(_feedbackRepository.GetDisapproved());
        }

        /// <summary>
        ///calls method for set na value of attribute Approved
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        ///<param name="feedback"> Feedback type object
        ///</param>>
        public void ChangeStatusFeedback(FeedbackDto feedback)
        {
            var fb = _feedbackRepository.GetById(feedback.SerialNumber);
            if (!fb.Approved)
                fb.Approved = true;
            else
                fb.Approved = false;
            _feedbackRepository.Update(fb);
        }

        /// <summary>
        ///calls method for adding new row in feedbacks table
        ///</summary>
        ///<returns>
        ///true or false depending on sucess
        ///</returns>
        ///<param name="feedback"> Feedback type object
        ///</param>>
        public bool AddNewFeedback(Feedback feedback)
        {
            _feedbackRepository.Save(feedback);
            return true;
        }
    }
}