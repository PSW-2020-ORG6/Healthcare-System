using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class SpecializationDatabaseSql : GenericDatabaseSql<Specialization>, ISpecializationRepository
    {
        public SpecializationDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Specialization> GetAll()
        {
            return DbContext.Specialization.ToList();
        }

        public override Specialization GetById(string id)
        {
            return DbContext.Specialization.Find(id);
        }

        public List<Specialization> GetByName(string name)
        {
            return GetAll().Where(s => s.Name.Equals(name)).ToList();
        }
    }
}