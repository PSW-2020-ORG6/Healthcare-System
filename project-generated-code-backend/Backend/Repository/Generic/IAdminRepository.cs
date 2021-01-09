using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Survey;
using HealthClinicBackend.Backend.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IAdminRepository :IGenericRepository<Admin>
    {
        Admin GetAdminByUserNameAndPassword(string email, string password);
    }
}
