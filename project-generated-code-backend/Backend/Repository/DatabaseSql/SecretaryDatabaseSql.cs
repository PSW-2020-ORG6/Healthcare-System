using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class SecretaryDatabaseSql : GenericDatabaseSql<Secretary>, ISecretaryRepository
    {
        public SecretaryDatabaseSql() : base()
        {
        }

        public SecretaryDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Secretary> GetAll()
        {
            return DbContext.Secretary.ToList();
        }
    }
}