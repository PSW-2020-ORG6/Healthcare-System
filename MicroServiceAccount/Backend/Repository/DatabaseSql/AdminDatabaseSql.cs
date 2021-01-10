using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Repository.DatabaseSql;
using MicroServiceAccount.Backend.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroServiceAccount.Backend.Repository
{
    public class AdminDatabaseSql : GenericMsAccountDatabaseSql<Admin>, IAdminRepository
    {
        public AdminDatabaseSql(MsAccountDbContext dbContext) : base(dbContext)
        {
        }

        public Admin GetAdminByUserNameAndPassword(string email, string password)
        {
            List<Admin> admins = GetAll().Where(admin => admin.Email.Equals(email) && admin.Password.Equals(password)).ToList();
            if (admins.Count == 0)
            {
                return null;
            }
            else
            {
                return admins[0];
            }

        }

        public override List<Admin> GetAll()
        {
            return DbContext.Admin.ToList();
        }


    }
}
