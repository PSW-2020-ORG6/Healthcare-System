using System.Collections.Generic;
using System.Linq;
using Backend.Repository;
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