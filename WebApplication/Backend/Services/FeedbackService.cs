using health_clinic_class_diagram.Backend.Dto;
using Model.Blog;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
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
            return feedbackRepository.GetFeedbacks("Select * from feedbacks");
        }
        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///calls method for get approved feedbacks from feedback table
        ///</summary>
        ///<returns>
        ///list of approved feedbacks
        ///</returns>
        internal List<Feedback> GetApprovedFeedbacks()
        {
            return feedbackRepository.GetFeedbacks("Select * from feedbacks where approved is true");
        }
        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///calls method for get disapproved feedback from feedback table
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        internal List<Feedback> GetNotApprovedFeedbacks()
        {

            return feedbackRepository.GetFeedbacks("Select * from feedbacks where approved is false");
        }
        public void DeleteFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }
        ///Marija Vucetic 
        /// <summary>
        ///calls method for set na value of attribute Approved
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        ///<param name="feedback"> Feedback type object
        ///</param>>
        public void EditFeedback(FeedbackDTO feedback)
        {
             feedbackRepository.SetFeedbackApprovedValue(feedback);
        }
        ///Repovic Aleksa RA-52-2017
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
