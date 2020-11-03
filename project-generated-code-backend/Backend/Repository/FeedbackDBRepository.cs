using Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinic_class_diagram.Backend.Repository
{
    public class FeedbackDBRepository : GenericDBSystem<Feedback>, FeedbackRepository
    {

        public List<Feedback> GetApprovedFeedbacks(Boolean approved)
        {
            throw new NotImplementedException();
        }
    }
}
