using HealthClinicBackend.Backend.Model.Blog;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        List<Feedback> GetApproved();
        List<Feedback> GetDisapproved();
    }
}