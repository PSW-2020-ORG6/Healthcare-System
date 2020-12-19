using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Blog;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class FeedbackDatabaseSql : GenericDatabaseSql<Feedback>, IFeedbackRepository
    {
        public FeedbackDatabaseSql(HealthCareSystemDbContext context) : base(context)
        {
        }

        public override List<Feedback> GetAll()
        {
            return dbContext.Feedback.ToList();
        }

        public override void Save(Feedback newEntity)
        {
            dbContext.Feedback.Add(newEntity);
            dbContext.SaveChanges();
        }

        public override void Update(Feedback updateEntity)
        {
            dbContext.Feedback.Add(updateEntity);
            dbContext.SaveChanges();
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