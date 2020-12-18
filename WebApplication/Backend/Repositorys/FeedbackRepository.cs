using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Blog;
using HealthClinicBackend.Backend.Repository.DatabaseSql;

namespace WebApplication.Backend.Repositorys
{
    /// <summary>
    /// This class does connection with MySQL database feedback table
    /// </summary>
    public class FeedbackRepository
    {
        private readonly FeedbackDatabaseSql _feedbackRepository;

        public FeedbackRepository()
        {
            _feedbackRepository = new FeedbackDatabaseSql();
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Get feedbacks from feedbacks table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///list of all feedbacks
        ///</returns>
        public List<Feedback> GetAllFeedbacks()
        {
            return _feedbackRepository.GetAll();
        }

        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///Get feedbacks from feedbacks table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///list of approved feedbacks
        ///</returns>
        public List<Feedback> GetApprovedFeedbacks()
        {
            return _feedbackRepository.GetApproved();
        }

        ///Tanja Drcelic RA124/2017 and Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///Get feedbacks from feedbacks table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///list of disapproved feedbacks
        ///</returns>
        public List<Feedback> GetDisapprovedFeedbacks()
        {
            return _feedbackRepository.GetDisapproved();
        }

        ////Vucetic Marija RA157/2017
        /// <summary>
        ///set value of atrribute Approved
        ///</summary>
        ///<returns>
        ///true if sucessful,else false
        ///</returns>
        ///<exception>
        ///if any exception occurs method will return null
        ///</exception>
        ///<param name="feedbackDto"> Feedback type object
        ///</param>
        internal void ApproveFeedback(FeedbackDto feedbackDto)
        {
            var feedback = new Feedback(feedbackDto) {Approved = true};
            _feedbackRepository.Update(feedback);
        }

        ////Repovic Aleksa RA52-2017
        /// <summary>
        ///Adds new row into feedbacks table
        ///</summary>
        ///<returns>
        ///true if sucessful,else false
        ///</returns>
        ///<exception>
        ///if any exception occurs method will return false
        ///</exception>
        ///<param name="feedback"> Feedback type object
        ///</param>
        internal bool AddNewFeedback(Feedback feedback)
        {
            _feedbackRepository.Save(feedback);
            return true;
        }
    }
}