//using HealthClinicBackend.Backend.Model.Accounts;
//using HealthClinicBackend.Backend.Model.Survey;
//using HealthClinicBackend.Backend.Repository.DatabaseSql;
//using HealthClinicBackend.Backend.Repository.Generic;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using WebApplication.Backend.Repositorys.Interfaces;

//namespace HealthClinicBackend.Backend.Repository
//{
//    public class AdminDatabaseSql : GenericDatabaseSql<Admin>, IAdminRepository
//    {
//        public AdminDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
//        {
//        }

//        public Admin GetAdminByUserNameAndPassword(string email, string password)
//        {
//            List<Admin> admins = GetAll().Where(admin => admin.Email.Equals(email) && admin.Password.Equals(password)).ToList();
//            if (admins.Count == 0)
//            {
//                return null;
//            }
//            else
//            {
//                return admins[0];
//            }

//        }

//        public override List<Admin> GetAll()
//        {
//            return DbContext.Admin.ToList();
//        }


//    }
//}
