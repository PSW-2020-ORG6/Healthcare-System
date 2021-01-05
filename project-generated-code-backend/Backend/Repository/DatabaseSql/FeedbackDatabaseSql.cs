using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Blog;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class FeedbackDatabaseSql : GenericDatabaseSql<Feedback>, IFeedbackRepository
    {
        public FeedbackDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Feedback> GetAll()
        {
            return DbContext.Feedback.ToList();
        }

        public override void Save(Feedback newEntity)
        {
            DbContext.Feedback.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Update(Feedback updateEntity)
        {
            DbContext.Feedback.Add(updateEntity);
            DbContext.SaveChanges();
        }

        public List<Feedback> GetApproved()
        {
            return GetAll().Where(f => f.Approved).ToList();
        }

        public List<Feedback> GetDisapproved()
        {
            return GetAll().Where(f => !f.Approved).ToList();
        }
    }
}