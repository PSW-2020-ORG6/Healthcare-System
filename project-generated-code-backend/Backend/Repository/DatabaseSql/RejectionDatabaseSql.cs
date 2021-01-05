using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RejectionDatabaseSql : GenericDatabaseSql<Rejection>, IRejectionRepository
    {
        public RejectionDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Rejection> GetAll()
        {
            return DbContext.Rejection.ToList();
        }

        public override void Save(Rejection newEntity)
        {
            DbContext.Rejection.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var rejection = DbContext.Rejection.Find(id);
            if (rejection == null) return;
            DbContext.Rejection.Remove(rejection);
            DbContext.SaveChanges();
        }

        public override void Update(Rejection updateEntity)
        {
            DbContext.Rejection.Update(updateEntity);
            DbContext.SaveChanges();
        }

        public override Rejection GetById(string id)
        {
            return DbContext.Rejection.Find(id);
        }
    }
}