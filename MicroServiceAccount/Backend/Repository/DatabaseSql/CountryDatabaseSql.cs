using System.Collections.Generic;
using System.Linq;
using MicroServiceAccount.Backend.Repository.Generic;
using MicroServiceAccount.Backend.Repository.DatabaseSql;
using MicroServiceAccount.Backend.Model.Util;

namespace MicroServiceAccount.Backend.Repository.DatabaseSql
{
    public class CountryDatabaseSql : GenericMsAccountDatabaseSql<Country>, ICountryRepository
    {
        public CountryDatabaseSql(MsAccountDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Country> GetAll()
        {
            return DbContext.Country.ToList();
        }
    }
}