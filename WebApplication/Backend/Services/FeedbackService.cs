using System.Collections.Generic;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Blog;
using HealthClinicBackend.Backend.Repository.Generic;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class does connection with repository
    /// </summary>
    public class FeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
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
            return _feedbackRepository.GetAll();
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
            return _feedbackRepository.GetApproved();
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///calls method for get disapproved feedback from feedback table
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        internal List<Feedback> GetDisapprovedFeedbacks()
        {
            return _feedbackRepository.GetDisapproved();
        }

        ///Marija Vucetic 
        /// <summary>
        ///calls method for set na value of attribute Approved
        ///</summary>
        ///<returns>
        ///list of not approved feedbacks
        ///</returns>
        ///<param name="feedbackDto"> Feedback type object
        ///</param>>
        public void ApproveFeedback(FeedbackDto feedbackDto)
        {
            var feedback = new Feedback(feedbackDto) {Approved = true};
            _feedbackRepository.Update(feedback);
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
            _feedbackRepository.Save(feedback);
            return true;
        }
    }
}