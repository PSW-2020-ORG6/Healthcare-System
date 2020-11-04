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

        internal List<Feedback> GetAllFeedbacks()
        {
            throw new NotImplementedException();
        }


        internal Feedback GetFeedbackById(string id)
        {
            throw new NotImplementedException();
        }

        internal List<Feedback> GetApprovedFeedbacks()
        {
            throw new NotImplementedException();
        }

        public void DeleteFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public void EditFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public void NewFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }

    }
}
