using Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    public class FeedbackService
    {
        private FeedbackRepository feedbackRepository;

        public FeedbackService()
        {
            this.feedbackRepository = new FeedbackDBSystem();
        }

        internal List<Feedback> GetAllFeedbacks()
        {
            return feedbackRepository.GetAll();
        }

        internal List<Feedback> GetApprovedFeedbacks(Boolean approved)
        {
            List<Feedback> allFeedbacks = feedbackRepository.GetAll();
            List<Feedback> approvedFeedbacks = new List<Feedback>();
            foreach (Feedback feedback in allFeedbacks)
            {
                if (approved == feedback.Approved)
                {
                    approvedFeedbacks.Add(feedback);
                }
            }
            return approvedFeedbacks;
        }

        public void DeleteFeedback(Feedback feedback)
        {
            feedbackRepository.Delete(feedback.SerialNumber);
        }

        public void EditFeedback(Feedback feedback)
        {
            feedbackRepository.Update(feedback);
        }

        public void NewFeedback(Feedback feedback)
        {
            feedbackRepository.Save(feedback);
        }

    }
}
