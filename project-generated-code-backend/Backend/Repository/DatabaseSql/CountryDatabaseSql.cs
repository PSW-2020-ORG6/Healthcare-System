using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class CountryDatabaseSql : GenericDatabaseSql<Country>, ICountryRepository
    {
        public CountryDatabaseSql(HealthCareSystemDbContext context) : base(context)
        {
        }

        public override List<Country> GetAll()
        {
            return dbContext.Country.ToList();
        }
    }
}