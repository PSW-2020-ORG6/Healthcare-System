using Model.Blog;
using System;
using System.Collections.Generic;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    public class FeedbackService
    {

        private FeedbackRepository feedbackRepository;
        public FeedbackService()
        {
            this.feedbackRepository = new FeedbackRepository();

        }

        internal Feedback GetFeedbackById(string id)
        {
            throw new NotImplementedException();
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///calls method for get all feedback in feedback table
        ///</summary>
        ///<returns>
        ///list of feedbacks
        ///</returns>
        internal List<Feedback> GetAllFeedbacks()
        {
            return feedbackRepository.GetAllFeedbacks();
        }

        internal List<Feedback> GetApprovedFeedbacks()
        {

            List<Feedback> allFeedbacks = feedbackRepository.GetAllFeedbacks();
            List<Feedback> approvedFeedbacks = new List<Feedback>();
            foreach (Feedback feedback in allFeedbacks)
            {
                if (feedback.Approved)
                {
                    approvedFeedbacks.Add(feedback);
                }
            }
            return approvedFeedbacks;
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///calls method for get not approved feedback from feedback table
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        internal List<Feedback> GetNoApprovedFeedbacks()
        {

            List<Feedback> allFeedbacks = feedbackRepository.GetAllFeedbacks();
            List<Feedback> approvedFeedbacks = new List<Feedback>();
            foreach (Feedback feedback in allFeedbacks)
            {
                if (!feedback.Approved)
                {
                    approvedFeedbacks.Add(feedback);
                }
            }
            return approvedFeedbacks;
        }

        public void DeleteFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public void EditFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public string AddNewFeedback(Feedback feedback)
        {
            return feedbackRepository.AddNewFeedback(feedback);
        }

    }
}
