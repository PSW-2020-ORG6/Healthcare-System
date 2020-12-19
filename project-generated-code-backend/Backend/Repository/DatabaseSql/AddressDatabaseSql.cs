using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class AddressDatabaseSql : GenericDatabaseSql<Address>, IAddressRepository
    {
        public AddressDatabaseSql(HealthCareSystemDbContext context) : base(context)
        {
        }

        public override List<Address> GetAll()
        {
            return dbContext.Address.ToList();
        }

        public override Address GetById(string id)
        {
            return dbContext.Address.Find(id);
        }

        public List<Address> GetAddressesByStreet(string street)
        {
            return GetAll().Where(a => a.Street.Equals(street)).ToList();
        }
    }
}