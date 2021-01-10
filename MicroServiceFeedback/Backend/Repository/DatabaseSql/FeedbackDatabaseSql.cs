using MicroServiceFeedback.Backend.Model;
using MicroServiceFeedback.Backend.Repository.DatabaseSql;
using MicroServiceFeedback.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace MicroServiceFeedback.Backend.Repository.DatabaseSql
{
    public class FeedbackDatabaseSql : GenericMsFeedbackDatabaseSql<Feedback>, IFeedbackRepository
    {
        public FeedbackDatabaseSql(MsFeedbackDbContext dbContext) : base(dbContext)
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
            DbContext.Feedback.Update(updateEntity);
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

        public Feedback GetById(string id)
        {
            return GetAll().Where(f => f.SerialNumber.Equals(id)).ToList()[0];
        }
    }
}