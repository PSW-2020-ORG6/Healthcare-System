using System.Collections.Generic;
using System.Linq;
using MicroServiceAccount.Backend.Model.Util;
using MicroServiceAccount.Backend.Repository.Generic;

namespace MicroServiceAccount.Backend.Repository.DatabaseSql
{
    public class AddressDatabaseSql : GenericMsAccountDatabaseSql<Address>, IAddressRepository
    {
        public AddressDatabaseSql(MsAccountDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Address> GetAll()
        {
            return DbContext.Address.ToList();
        }

        public override Address GetById(string id)
        {
            return DbContext.Address.Find(id);
        }

        public List<Address> GetAddressesByStreet(string street)
        {
            return GetAll().Where(a => a.Street.Equals(street)).ToList();
        }

    }
}