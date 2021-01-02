﻿using System.Collections.Generic;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Blog;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class FeedbackService
    {
        private FeedbackRepository feedbackRepository;
        private FeedbackDto feedbackDTO = new FeedbackDto();
        public FeedbackService()
        {
            this.feedbackRepository = new FeedbackRepository();
        }
        /// <summary>
        ///calls method for get all feedback in feedback table
        ///</summary>
        ///<returns>
        ///list of feedbacks
        ///</returns>
        internal List<FeedbackDto> GetAllFeedbacks()
        {
            return feedbackDTO.ConvertListToFeedbackDTO(feedbackRepository.GetAllFeedbacks());
        }
        /// <summary>
        ///calls method for get approved feedbacks from feedback table
        ///</summary>
        ///<returns>
        ///list of approved feedbacks
        ///</returns>
        internal List<FeedbackDto> GetApprovedFeedbacks()
        {
            return feedbackDTO.ConvertListToFeedbackDTO(feedbackRepository.GetApprovedFeedbacks());
        }
        /// <summary>
        ///calls method for get disapproved feedback from feedback table
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        internal List<FeedbackDto> GetDisapprovedFeedbacks()
        {
            return feedbackDTO.ConvertListToFeedbackDTO(feedbackRepository.GetDisapprovedFeedbacks());
        }
        /// <summary>
        ///calls method for set na value of attribute Approved
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        ///<param name="feedback"> Feedback type object
        ///</param>>
        public void ApproveFeedback(FeedbackDto feedback)
        {
            feedbackRepository.ApproveFeedback(feedback);
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
            return feedbackRepository.AddNewFeedback(feedback);
        }
    }
}
