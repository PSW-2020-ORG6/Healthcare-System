using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class CountryDatabaseSql : GenericDatabaseSql<Country>, ICountryRepository
    {
        public override List<Country> GetAll()
        {
            return dbContext.Country.ToList();
        }
    }
}