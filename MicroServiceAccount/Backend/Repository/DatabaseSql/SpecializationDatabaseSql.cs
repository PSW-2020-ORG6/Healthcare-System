using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace MicroServiceAccount.Backend.Repository.DatabaseSql
{
    public class SpecializationDatabaseSql : GenericMsAccountDatabaseSql<Specialization>, ISpecializationRepository
    {
        public SpecializationDatabaseSql(MsAccountDbContext dbContext) : base(dbContext)
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