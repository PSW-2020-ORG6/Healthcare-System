using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class SuperintendentDatabaseSql : GenericDatabaseSql<Superintendent>, ISuperintendentRepository
    {
        public SuperintendentDatabaseSql() : base()
        {
        }

        public SuperintendentDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Superintendent> GetAll()
        {
            return DbContext.Superintendent.ToList();
        }

    }
}