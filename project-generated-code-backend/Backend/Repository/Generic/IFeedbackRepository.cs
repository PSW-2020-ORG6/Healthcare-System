using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Blog;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        List<Feedback> GetApproved();
        List<Feedback> GetDisapproved();
    }
}