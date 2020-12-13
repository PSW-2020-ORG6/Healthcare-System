using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class SpecializationDatabaseSql : GenericDatabaseSql<Specialization>, ISpecializationRepository
    {
        public override List<Specialization> GetAll()
        {
            return dbContext.Specialization.ToList();
        }

        public override Specialization GetById(string id)
        {
            return dbContext.Specialization.Find(id);
        }

        public List<Specialization> GetByName(string name)
        {
            return GetAll().Where(s => s.Name.Equals(name)).ToList();
        }
    }
}