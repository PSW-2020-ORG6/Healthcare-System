using HealthClinicBackend.Backend.Model.Accounts;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Admin GetAdminByUserNameAndPassword(string email, string password);
    }
}
