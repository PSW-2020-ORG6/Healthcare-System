using System.Collections.Generic;
using System.Linq;
using HCI_SIMS_PROJEKAT.Backend.Repository;
using Model.Util;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class CountryDatabaseSql: GenericDatabaseSql<Country>, ICountryRepository
    {
        public override List<Country> GetAll()
        {
            return dbContext.Country.ToList();
        }
    }
}