using MicroServiceFeedback.Backend.Model;
using System.Collections.Generic;

namespace MicroServiceFeedback.Backend.Repository.Generic
{
    public interface IFeedbackRepository : IGenericMsFeedbackRepository<Feedback>
    {
        List<Feedback> GetApproved();
        List<Feedback> GetDisapproved();
    }
}