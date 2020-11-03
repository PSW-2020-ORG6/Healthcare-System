using Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication.Backend.Repositorys
{
    public class FeedbackDBSystem : GenericDBSystem<Feedback>, FeedbackRepository
    {

        public List<Feedback> GetApprovedFeedbacks(Boolean approved)
        {
            throw new NotImplementedException();
        }
    }
}
