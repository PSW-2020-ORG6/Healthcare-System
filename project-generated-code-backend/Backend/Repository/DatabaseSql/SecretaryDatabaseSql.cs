using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class SecretaryDatabaseSql: GenericDatabaseSql<Secretary>, ISecretaryRepository
    {
        public override List<Secretary> GetAll()
        {
            return dbContext.Secretary.ToList();
        }
    }
}