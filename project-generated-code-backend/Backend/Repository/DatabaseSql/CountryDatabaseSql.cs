using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class CountryDatabaseSql : GenericDatabaseSql<Country>, ICountryRepository
    {
        public CountryDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Country> GetAll()
        {
            return DbContext.Country.ToList();
        }
    }
}